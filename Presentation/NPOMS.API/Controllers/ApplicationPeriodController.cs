using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NPOMS.Domain.Entities;
using NPOMS.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace NPOMS.API.Controllers
{
	[Route("api/application-periods")]
	[ApiController]
	public class ApplicationPeriodController : ExternalBaseController
	{
		#region Fields

		private ILogger<ApplicationPeriodController> _logger;
		private IApplicationPeriodService _applicationPeriodService;

		#endregion

		#region Constructors

		public ApplicationPeriodController(
			ILogger<ApplicationPeriodController> logger,
			IApplicationPeriodService applicationPeriodService
			)
		{
			_logger = logger;
			_applicationPeriodService = applicationPeriodService;
		}

		#endregion

		#region Methods

		[HttpGet(Name = "GetAllApplicationPeriods")]
		public async Task<IActionResult> GetAllApplicationPeriods()
		{
			try
			{
				var results = await _applicationPeriodService.Get();
				return Ok(results);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside GetAllApplicationPeriods action: {ex.Message} Inner Exception: { ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpGet("applicationPeriodId/{applicationPeriodId}", Name = "GetApplicationPeriodById")]
		public async Task<IActionResult> GetApplicationPeriodById(int applicationPeriodId)
		{
			try
			{
				var results = await _applicationPeriodService.GetById(applicationPeriodId);
				return Ok(results);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside GetApplicationPeriodById action: {ex.Message} Inner Exception: { ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpPost(Name = "CreateApplicationPeriod")]
		public async Task<IActionResult> CreateApplicationPeriod([FromBody] ApplicationPeriod model)
		{
			try
			{
				ClearObjects(model);

				await _applicationPeriodService.Create(model, base.GetUserIdentifier());
				return Ok(model);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside CreateApplicationPeriod action: {ex.Message} Inner Exception: { ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpPut(Name = "UpdateApplicationPeriod")]
		public async Task<IActionResult> UpdateApplicationPeriod([FromBody] ApplicationPeriod model)
		{
			try
			{
				ClearObjects(model);

				await _applicationPeriodService.Update(model, base.GetUserIdentifier());
				return Ok(model);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside UpdateApplicationPeriod action: {ex.Message} Inner Exception: { ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		private static void ClearObjects(ApplicationPeriod model)
		{
			model.Department = null;
			model.Programme = null;
			model.SubProgramme = null;
			model.FinancialYear = null;
			model.ApplicationType = null;
		}

		#endregion
	}
}
