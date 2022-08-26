using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NPOMS.Domain.Enumerations;
using NPOMS.Domain.Indicator;
using NPOMS.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace NPOMS.API.Controllers
{
	[Route("api/indicators")]
	[ApiController]
	public class IndicatorController : ExternalBaseController
	{
		#region Fields

		private ILogger<IndicatorController> _logger;
		private IIndicatorService _indicatorService;
		private IDropdownService _dropdownService;

		#endregion

		#region Constructors

		public IndicatorController(
			ILogger<IndicatorController> logger,
			IIndicatorService indicatorService,
			IDropdownService dropdownService
			)
		{
			_logger = logger;
			_indicatorService = indicatorService;
			_dropdownService = dropdownService;
		}

		#endregion

		#region Methods

		[HttpGet("workplan-target/activityId/{activityId}", Name = "GetTargetsByActivityId")]
		public async Task<IActionResult> GetTargetsByActivityId(int activityId)
		{
			try
			{
				var results = await _indicatorService.GetTargetsByActivityId(activityId);
				return Ok(results);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside GetTargetsByActivityId action: {ex.Message} Inner Exception: {ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpPost("workplan-target", Name = "ManageTarget")]
		public async Task<IActionResult> ManageTarget([FromBody] WorkplanTarget model)
		{
			try
			{
				var target = await _indicatorService.GetTargetByIds(model);

				if (target == null)
					await _indicatorService.CreateTarget(model, base.GetUserIdentifier());
				else
					await _indicatorService.UpdateTarget(model, base.GetUserIdentifier());

				await CreateWorkplanActual(model);
				return Ok();
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside ManageTarget action: {ex.Message} Inner Exception: {ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		/// <summary>
		/// Create Workplan Actual placeholders based on the captured workplan targets
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		private async Task CreateWorkplanActual(WorkplanTarget model)
		{
			// Only return active frequency periods by frequency Id
			var frequencyPeriods = await _dropdownService.GetFrequencyPeriodsByFrequencyId(model.FrequencyId);

			foreach (var period in frequencyPeriods)
			{
				var workplanActual = new WorkplanActual
				{
					ActivityId = model.ActivityId,
					FinancialYearId = model.FinancialYearId,
					FrequencyPeriodId = period.Id,
					StatusId = (int)StatusEnum.New,
					WorkplanTargetId = model.Id
				};

				var workplanActualExists = await _indicatorService.GetActualsByIds(workplanActual);

				if (workplanActualExists == null)
					await _indicatorService.CreateActual(workplanActual, base.GetUserIdentifier());
			}
		}

		[HttpGet("workplan-actual/activityId/{activityId}", Name = "GetActualsByActivityId")]
		public async Task<IActionResult> GetActualsByActivityId(int activityId)
		{
			try
			{
				var results = await _indicatorService.GetActualsByActivityId(activityId);
				return Ok(results);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside GetActualsByActivityId action: {ex.Message} Inner Exception: {ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpPut("workplan-actual", Name = "UpdateActual")]
		public async Task<IActionResult> UpdateActual([FromBody] WorkplanActual model)
		{
			try
			{
				await _indicatorService.UpdateActual(model, base.GetUserIdentifier());
				return Ok(model);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside UpdateActual action: {ex.Message} Inner Exception: {ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		#endregion
	}
}
