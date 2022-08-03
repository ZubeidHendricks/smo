using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NPOMS.Services.Interfaces;
using NPOMS.Services.PowerBI;
using NPOMS.Services.PowerBI.Models;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace NPOMS.API.Controllers
{
	[Route("api/powerbi")]
	[ApiController]
	public class PowerBIController : ExternalBaseController
	{
		#region Fields

		private ILogger<PowerBIController> _logger;
		private IEmbeddedReportService _embeddedReportService;
		private PbiEmbedService _pbiEmbedService;

		#endregion

		#region Constructors

		public PowerBIController(
			ILogger<PowerBIController> logger,
			IEmbeddedReportService embeddedReportService,
			PbiEmbedService pbiEmbedService
			)
		{
			_logger = logger;
			_embeddedReportService = embeddedReportService;
			_pbiEmbedService = pbiEmbedService;
		}

		#endregion

		#region Methods

		[HttpGet(Name = "GetAllReports")]
		public async Task<IActionResult> Get()
		{
			try
			{
				var reports = await _embeddedReportService.GetEmbeddedReports();
				return Ok(reports);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside GetAllReports action: {ex.Message} Inner Exception: {ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpGet("{id}", Name = "GetEmbeddedReport")]
		public async Task<IActionResult> GetEmbedInfo(int id)
		{
			try
			{
				EmbedParams embedParams = _pbiEmbedService.GetEmbedParams(id);
				var returnValue = JsonSerializer.Serialize<EmbedParams>(embedParams);

				return Ok(returnValue);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside GetEmbeddedReport action: {ex.Message} Inner Exception: { ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		#endregion
	}
}
