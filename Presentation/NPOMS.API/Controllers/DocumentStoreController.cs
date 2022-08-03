using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NPOMS.Domain.Core;
using NPOMS.Domain.Enumerations;
using NPOMS.Domain.ResourceParameters;
using NPOMS.Services.Interfaces;
using System;
using System.Linq;
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

		#endregion

		#region Constructors

		public DocumentStoreController(
			ILogger<DocumentStoreController> logger,
			IDocumentStoreService documentStoreService
			)
		{
			_logger = logger;
			_documentStoreService = documentStoreService;
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
