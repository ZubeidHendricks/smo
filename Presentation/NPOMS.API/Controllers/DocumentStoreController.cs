using Azure.Identity;
using Azure.Storage.Files.DataLake;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NPOMS.Domain.Core;
using NPOMS.Domain.Entities;
using NPOMS.Domain.Enumerations;
using NPOMS.Domain.ResourceParameters;
using NPOMS.Repository.Interfaces.Entities;
using NPOMS.Services.Extensions;
using NPOMS.Services.Interfaces;
using System;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace NPOMS.API.Controllers
{
	[Route("api/documentstore")]
	[ApiController]
	public class DocumentStoreController : ExternalBaseController
	{
		#region Fields

		private ILogger<DocumentStoreController> _logger;
        private IDocumentStoreService _documentStoreService;

        private IFundAppDocumentService _documentStore1Service;
        private IFundAppDocumentRepository _fundAppDocumentRepository;
        private dtoBlobConfig _blobConfiguration;
        private IFundingApplicationDetailsRepository _fundingApplicationDetailsRepository;


        #endregion

        #region Constructors

        public DocumentStoreController(
			ILogger<DocumentStoreController> logger,
			IDocumentStoreService documentStoreService,
            IFundAppDocumentRepository fundAppDocumentRepository,
            IFundingApplicationDetailsRepository fundingApplicationDetailsRepository,
			dtoBlobConfig blobConfiguration
            )
		{
			_logger = logger;
			_documentStoreService = documentStoreService;
            _fundAppDocumentRepository = fundAppDocumentRepository;
            _fundingApplicationDetailsRepository = fundingApplicationDetailsRepository;
			_blobConfiguration = blobConfiguration;
		}

		#endregion

		#region Methods

		[HttpGet(Name = "BrowseBlobContainer")]
		public async Task<IActionResult> GetAll([FromQuery] int? pageSize)
		{
			try
			{
				var files = await _documentStoreService.BrowseFiles(pageSize);
				return Ok(files);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

        //[HttpPost("UploadDocuments", Name = "UploadDocuments"), DisableRequestSizeLimit]
        ////[RequestSizeLimit(209715200)]
        //public async Task<IActionResult> UploadDocuments(int id, int userId)
        //{
        //    try
        //    {
        //        var indicatorsCaptureDetails = await _fundingApplicationDetailsRepository.GetById(id);
        //        var userAdmission = await _fundAppDocumentRepository.GetFundAppDocumentByIdAsync(id);
 
        //        var files = Request.Form.Files;

        //        if (files.Any(f => f.Length == 0))
        //        {
        //            return BadRequest();
        //        }

        //        foreach (var file in files)
        //        {
        //            var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
        //            FileInfo fi = new FileInfo(fileName);

        //            Guid obj = Guid.NewGuid();

        //            var dviNumberGuid = string.Format("{0}-{1}{2}", indicatorsCaptureDetails.ApplicationDetailId, obj.ToString(), fi.Extension);
        //            FundAppDocuments dad = new FundAppDocuments();
        //            dad.FundingApplicationDetailId = indicatorsCaptureDetails.ApplicationDetailId;
        //            dad.Name = fileName;
        //            dad.IsActive = true;
        //            //dad.Url = dviNumberGuid;
        //            dad.CreatedBy = userId;
        //            dad.DateCreated = DateTime.Now;
        //            dad.FileSize = GetBytesReadable(file.Length);

        //            //string srcPathToUpload = string.Format(dviNumberGuid);

        //            //using (var stream = file.OpenReadStream())
        //            //{
        //            //    string srcPathToUpload = string.Format(dviNumberGuid);
        //            //    await BlobService.DocumentsUploadFile(srcPathToUpload, stream, _azureBlobStorage);
        //            //}

        //            using (var stream = file.OpenReadStream())
        //            {
        //                var client = new ChainedTokenCredential(new VisualStudioCredential(), new ManagedIdentityCredential());

        //                var dataLakeServiceClient =
        //                                            new DataLakeServiceClient
        //                                            (new Uri(_blobConfiguration.DataLakesEndPoint), client);


        //                var fileSystemClient = dataLakeServiceClient.GetFileSystemClient(_blobConfiguration.BlobContainer);
        //                var directoryClient = fileSystemClient.GetDirectoryClient($"{_blobConfiguration.FolderPath01}");
        //                var fileClient = directoryClient.GetFileClient(dviNumberGuid);

        //                await fileClient.UploadAsync(stream);
        //            }

        //            await _fundAppDocumentRepository.CreateAsync(dad);
        //        }

        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Something went wrong inside UploadDocument action: {ex.Message}");
        //        return StatusCode(500, "Internal server error");
        //    }
        //}


        // Returns the human-readable file size for an arbitrary, 64-bit file size 
        // The default format is "0.### XB", e.g. "4.2 KB" or "1.434 GB"
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


        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> UploadToDocumentStore()
		{
			try
			{
				var files = Request.Form.Files;

				if (Request.Form.Files.Any(f => f.Length == 0))
				{
					return BadRequest();
				}

				var viewModel = Request.Form["documentStoreViewModel"];
				if (viewModel.Count < 1)
				{
					return BadRequest();
				}

				await _documentStoreService.Create(Request.Form, base.GetUserIdentifier());
				return Ok();
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside UploadToDocumentStore action: {ex.Message} Inner Exception: { ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpGet("entitytypes/{entityType}/entities/{entityId}", Name = "GetFromDocumentStore")]
		public async Task<IActionResult> GetFromDocumentStore(EntityTypeEnum entityType, int entityId, [FromQuery] DocumentStoreResourceParameters documentStoreResourceParameters)
		{
			try
			{
				documentStoreResourceParameters.EntityType = entityType;
				documentStoreResourceParameters.EntityId = entityId;

				var viewModel = await this._documentStoreService.Get(documentStoreResourceParameters);
				return Ok(viewModel);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside GetFromDocumentStore action: {ex.Message} Inner Exception: { ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpDelete("{resourceId}", Name = "DeleteFromDocumentStore")]
		public async Task<IActionResult> DeleteFromDocumentStore(string resourceId)
		{
			try
			{
				await this._documentStoreService.Delete(resourceId, base.GetUserIdentifier());
				return Ok();
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside DeleteFromDocumentStore action: {ex.Message} Inner Exception: { ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpGet("{resourceId}", Name = "GetFileFromDocumentStore")]
		public async Task<IActionResult> GetFileFromDocumentStore(string resourceId)
		{
			try
			{
				var file = await this._documentStoreService.Download(resourceId);
				return file;
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside GetFileFromDocumentStore action: {ex.Message} Inner Exception: { ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpPut(Name = "UpdateDocumentMetadata")]
		public async Task<IActionResult> UpdateDocumentMetadata([FromBody] DocumentStore model)
		{
			try
			{
				await _documentStoreService.Update(model, base.GetUserIdentifier());
				return Ok(model);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside UpdateDocumentMetadata action: {ex.Message} Inner Exception: { ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		#endregion
	}
}
