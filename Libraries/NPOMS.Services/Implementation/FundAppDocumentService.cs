using AutoMapper;
using Azure.Identity;
using Azure.Storage.Files.DataLake;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Logging;
using NPOMS.Domain.Core;
using NPOMS.Domain.Entities;
using NPOMS.Domain.Enumerations;
using NPOMS.Domain.ResourceParameters;
using NPOMS.Repository.Interfaces.Core;
using NPOMS.Repository.Interfaces.Entities;
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
	public class FundAppDocumentService : IFundAppDocumentService
	{
		#region Fields

		private IMapper _mapper;
		private ILogger<DocumentStoreService> _logger;
		private IFundAppDocumentRepository _fundAppDocumentRepository;
		private readonly BlobStorageSettings _blobStorageSettings;
		private IUserRepository _userRepository;

		#endregion

		#region Constructorrs

		public FundAppDocumentService(
			IMapper mapper,
			ILogger<DocumentStoreService> logger,
            IFundAppDocumentRepository fundAppDocumentRepository,
			BlobStorageSettings blobStorageSettings,
			IUserRepository userRepository
			)
		{
			_mapper = mapper;
			_logger = logger;
			_fundAppDocumentRepository = fundAppDocumentRepository;
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

					var entity = new FundAppDocuments()
					{
				
						Name = fileName,
						FileSize = GetBytesReadable(file.Length),
						CreatedUserId = loggedInUser.Id,
						CreatedDateTime = DateTime.Now,
						IsActive = true,
					};

					await UploadFile(file, resourceId);
					await _fundAppDocumentRepository.CreateFundAppDcoument(entity);
				}
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside CreateDocument action: {ex.Message} Inner Exception: { ex.InnerException}");
				throw;
			}
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

        public Task<IEnumerable<FundAppDocuments>> GetFundAppDocumentsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<FundAppDocuments>> GetFundAppDocumentByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task CreateFundAppDocument(FundAppDocuments sp)
        {
            throw new NotImplementedException();
        }

        public Task DeleteFundAppDocument(FundAppDocuments sp)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
