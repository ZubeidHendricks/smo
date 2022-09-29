using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NPOMS.Domain.Entities;
using NPOMS.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace NPOMS.API.Controllers
{
	[Route("api/admin")]
	[ApiController]
	public class AdminController : ExternalBaseController
	{
		#region Fields

		private ILogger<AdminController> _logger;
		private IAdminService _adminService;

		#endregion

		#region Constructors

		public AdminController(
			ILogger<AdminController> logger,
			IAdminService adminService
			)
		{
			_logger = logger;
			_adminService = adminService;
		}

		#endregion

		#region Methods

		[HttpGet("compliant-cycle/departmentId/{departmentId}/financialYearId/{financialYearId}", Name = "GetCompliantCyclesByIds")]
		public async Task<IActionResult> GetCompliantCyclesByIds(int departmentId, int financialYearId)
		{
			try
			{
				var results = await _adminService.GetCompliantCyclesByIds(departmentId, financialYearId);
				return Ok(results);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside GetAllComplianGetCompliantCyclesByIdstCycles action: {ex.Message} Inner Exception: {ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpPost("compliant-cycle", Name = "CreateCompliantCycle")]
		public async Task<IActionResult> CreateCompliantCycle([FromBody] CompliantCycle model)
		{
			try
			{
				await _adminService.Create(model, base.GetUserIdentifier());
				return Ok(model);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside CreateCompliantCycle action: {ex.Message} Inner Exception: {ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpPut("compliant-cycle", Name = "UpdateCompliantCycle")]
		public async Task<IActionResult> UpdateCompliantCycle([FromBody] CompliantCycle model)
		{
			try
			{
				await _adminService.Update(model, base.GetUserIdentifier());
				return Ok(model);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside UpdateCompliantCycle action: {ex.Message} Inner Exception: {ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpGet("payment-schedule/departmentId/{departmentId}/financialYearId/{financialYearId}", Name = "GetPaymentSchedulesByIds")]
		public async Task<IActionResult> GetPaymentSchedulesByIds(int departmentId, int financialYearId)
		{
			try
			{
				var results = await _adminService.GetPaymentSchedulesByIds(departmentId, financialYearId);
				return Ok(results);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside GetPaymentSchedulesByIds action: {ex.Message} Inner Exception: {ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpPost("payment-schedule", Name = "CreatePaymentSchedule")]
		public async Task<IActionResult> CreatePaymentSchedule([FromBody] PaymentSchedule model)
		{
			try
			{
				await _adminService.Create(model, base.GetUserIdentifier());
				return Ok(model);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside CreatePaymentSchedule action: {ex.Message} Inner Exception: {ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpPut("payment-schedule", Name = "UpdatePaymentSchedule")]
		public async Task<IActionResult> UpdatePaymentSchedule([FromBody] PaymentSchedule model)
		{
			try
			{
				await _adminService.Update(model, base.GetUserIdentifier());
				return Ok(model);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside UpdatePaymentSchedule action: {ex.Message} Inner Exception: {ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		#endregion
	}
}
