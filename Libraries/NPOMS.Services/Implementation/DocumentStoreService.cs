using AutoMapper;
using Azure.Identity;
using Azure.Storage.Files.DataLake;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Logging;
using NPOMS.Domain.Core;
using NPOMS.Domain.Enumerations;
using NPOMS.Domain.ResourceParameters;
using NPOMS.Repository.Interfaces.Core;
using NPOMS.Services.Extensions;
using NPOMS.Services.Helpers.Paging;
using NPOMS.Services.Interfaces;
using NPOMS.Services.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace NPOMS.Services.Implementation
{
	public class DocumentStoreService : IDocumentStoreService
	{
		#region Fields

		private IMapper _mapper;
		private ILogger<DocumentStoreService> _logger;
		private IDocumentStoreRepository _documentStoreRepository;
		private readonly BlobStorageSettings _blobStorageSettings;
		private IUserRepository _userRepository;

		#endregion

		#region Constructorrs

		public DocumentStoreService(
			IMapper mapper,
			ILogger<DocumentStoreService> logger,
			IDocumentStoreRepository documentStoreRepository,
			BlobStorageSettings blobStorageSettings,
			IUserRepository userRepository
			)
		{
			_mapper = mapper;
			_logger = logger;
			_documentStoreRepository = documentStoreRepository;
			_blobStorageSettings = blobStorageSettings;
			_userRepository = userRepository;
		}

		#endregion

		#region Methods

		public async Task<List<string>> BrowseFiles(int? pageSize = 5)
		{
			var files = new List<string>();
			var client = new DefaultAzureCredential();
			var dataLakeServiceClient = new DataLakeServiceClient(new Uri(_blobStorageSettings.DataLakesEndPoint), client);

			var fileSystemClient = dataLakeServiceClient.GetFileSystemClient(_blobStorageSettings.BlobContainer);
			var directoryClient = fileSystemClient.GetDirectoryClient($"{_blobStorageSettings.SubFolderPath}");
			var paths = directoryClient.GetPaths();

			foreach (var path in paths)
			{
				files.Add(path.Name);
				if (files.Count > pageSize)
				{
					break;
				}
			}

			return files;
		}

		public async Task Create(IFormCollection form, string userIdentifier)
		{
			try
			{
				var viewModel = JsonSerializer.Deserialize<DocumentStoreViewModel>(form["documentStoreViewModel"].ToString());

				if (viewModel == null)
					throw new ArgumentNullException(nameof(viewModel));

				if (form.Files.Count < 1)
					throw new ArgumentNullException(nameof(form.Files));

				foreach (var file in form.Files)
				{
					var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
					FileInfo fi = new FileInfo(fileName);

					Guid obj = Guid.NewGuid();

					var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);
					var resourceId = string.Format("D-{0}-{1}{2}", viewModel.EntityId, obj.ToString(), fi.Extension);

					var entity = new DocumentStore()
					{
						DocumentTypeId = viewModel.DocumentTypeId == 0 ? null : viewModel.DocumentTypeId,
						EntityTypeId = viewModel.EntityTypeId,
						EntityId = viewModel.EntityId,
						Entity = viewModel.Entity,
						Name = fileName,
						ResourceId = resourceId,
						FileSize = GetBytesReadable(file.Length),
						CreatedUserId = loggedInUser.Id,
						CreatedDateTime = DateTime.Now,
						IsActive = true,
						RefNo = viewModel.RefNo
					};

					await UploadFile(file, resourceId);
					await _documentStoreRepository.CreateEntity(entity);
				}
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside CreateDocument action: {ex.Message} Inner Exception: { ex.InnerException}");
				throw;
			}
		}

		public async Task Delete(string resourceId, string userIdentifier)
		{
			try
			{
				var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);
				var entity = _documentStoreRepository.GetEntities().Where(x => x.ResourceId == resourceId).FirstOrDefault();

				if (entity == null)
					throw new ArgumentNullException(nameof(entity));

				entity.IsActive = false;
				entity.UpdatedUserId = loggedInUser.Id;
				entity.UpdatedDateTime = DateTime.Now;

				await _documentStoreRepository.UpdateEntity(entity, loggedInUser.Id);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside DeleteDocument action: {ex.Message} Inner Exception: { ex.InnerException}");
				throw;
			}
		}

		public async Task<FileStreamResult> Download(string resourceId)
		{
			try
			{
				var entity = _documentStoreRepository.GetEntities().Where(x => x.ResourceId == resourceId).FirstOrDefault();

				if (entity == null)
					throw new ArgumentNullException(resourceId, "The record associated with file does not exist anymore.");

				return await DownloadFile(entity.ResourceId);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside DownloadDocument action: {ex.Message} Inner Exception: { ex.InnerException}");
				throw;
			}
		}

		public async Task<PagedList<DocumentStoreViewModel>> Get(DocumentStoreResourceParameters documentStoreResourceParameters)
		{
			try
			{
				List<DocumentStoreViewModel> viewModel = new List<DocumentStoreViewModel>();
				if (documentStoreResourceParameters == null)
				{
					throw new ArgumentNullException(nameof(documentStoreResourceParameters));
				}

				var query = _documentStoreRepository.GetEntities();

				if (Enum.IsDefined(typeof(EntityTypeEnum), documentStoreResourceParameters.EntityType))
				{
					int entityTypeId = (int)documentStoreResourceParameters.EntityType;
					query = query.Where(x => x.EntityTypeId == entityTypeId);
				}

				query = query.Where(x => x.EntityId == documentStoreResourceParameters.EntityId);

				var pageList = await PagedList<DocumentStore>.Create(query, documentStoreResourceParameters.PageNumber, documentStoreResourceParameters.PageSize);
				var viewModelItems = _mapper.Map<List<DocumentStoreViewModel>>(pageList.Items);

				return PagedList<DocumentStoreViewModel>.CreateForView(viewModelItems, documentStoreResourceParameters.PageNumber, documentStoreResourceParameters.PageSize);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside GetDocuments action: {ex.Message} Inner Exception: { ex.InnerException}");
				throw;
			}
		}

		public async Task Update(DocumentStore model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.UpdatedUserId = loggedInUser.Id;
			model.UpdatedDateTime = DateTime.Now;

			await _documentStoreRepository.UpdateEntity(model, loggedInUser.Id);
		}

		private string GetBytesReadable(long i)
		{
			// Get absolute value
			long absolute_i = (i < 0 ? -i : i);
			// Determine the suffix and readable value
			string suffix;
			double readable;
			if (absolute_i >= 0x1000000000000000) // Exabyte
			{
				suffix = "EB";
				readable = (i >> 50);
			}
			else if (absolute_i >= 0x4000000000000) // Petabyte
			{
				suffix = "PB";
				readable = (i >> 40);
			}
			else if (absolute_i >= 0x10000000000) // Terabyte
			{
				suffix = "TB";
				readable = (i >> 30);
			}
			else if (absolute_i >= 0x40000000) // Gigabyte
			{
				suffix = "GB";
				readable = (i >> 20);
			}
			else if (absolute_i >= 0x100000) // Megabyte
			{
				suffix = "MB";
				readable = (i >> 10);
			}
			else if (absolute_i >= 0x400) // Kilobyte
			{
				suffix = "KB";
				readable = i;
			}
			else
			{
				return i.ToString("0 B"); // Byte
			}
			// Divide by 1024 to get fractional value
			readable = (readable / 1024);
			// Return formatted number with suffix
			return readable.ToString("0.### ") + suffix;
		}

		private async Task UploadFile(IFormFile file, string resourceId)
		{
			using (var stream = file.OpenReadStream())
			{
				var client = new DefaultAzureCredential();

				var dataLakeServiceClient = new DataLakeServiceClient(new Uri(_blobStorageSettings.DataLakesEndPoint), client);

				var fileSystemClient = dataLakeServiceClient.GetFileSystemClient(_blobStorageSettings.BlobContainer);
				var directoryClient = fileSystemClient.GetDirectoryClient($"{ _blobStorageSettings.SubFolderPath }");
				var fileClient = directoryClient.GetFileClient(resourceId);

				await fileClient.UploadAsync(stream);
			}
		}

		private async Task DeleteFile(string resourceId)
		{
			var client = new DefaultAzureCredential();

			var dataLakeServiceClient = new DataLakeServiceClient(new Uri(_blobStorageSettings.DataLakesEndPoint), client);

			var fileSystemClient = dataLakeServiceClient.GetFileSystemClient(_blobStorageSettings.BlobContainer);
			var directoryClient = fileSystemClient.GetDirectoryClient($"{_blobStorageSettings.SubFolderPath}");
			var fileClient = directoryClient.GetFileClient(resourceId);

			await fileClient.DeleteIfExistsAsync();
		}

		private async Task<FileStreamResult> DownloadFile(string resourceId)
		{
			var client = new DefaultAzureCredential();

			var dataLakeServiceClient = new DataLakeServiceClient(new Uri(_blobStorageSettings.DataLakesEndPoint), client);

			var fileSystemClient = dataLakeServiceClient.GetFileSystemClient(_blobStorageSettings.BlobContainer);
			var directoryClient = fileSystemClient.GetDirectoryClient($"{_blobStorageSettings.SubFolderPath}");
			var fileClient = directoryClient.GetFileClient(resourceId);

			var provider = new FileExtensionContentTypeProvider();
			if (!provider.TryGetContentType(resourceId, out var contentType))
			{
				contentType = "application/octet-stream";
			}

			var stream = await fileClient.OpenReadAsync();

			FileStreamResult fileResult = new FileStreamResult(stream, contentType);
			fileResult.FileDownloadName = resourceId;

			return fileResult;
		}

		#endregion
	}
}
