using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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

		#endregion

		#region Constructors

		public IndicatorController(
			ILogger<IndicatorController> logger,
			IIndicatorService indicatorService
			)
		{
			_logger = logger;
			_indicatorService = indicatorService;
		}

		#endregion

		#region Methods

		[HttpGet("activityId/{activityId}", Name = "GetTargetsByActivityId")]
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

		[HttpPost("workplan", Name = "ManageTarget")]
		public async Task<IActionResult> ManageTarget([FromBody] WorkplanTarget model)
		{
			try
			{
				var target = await _indicatorService.GetTargetByIds(model);

				if (target == null)
					await _indicatorService.CreateTarget(model, base.GetUserIdentifier());
				else
					await _indicatorService.UpdateTarget(model, base.GetUserIdentifier());

				return Ok();
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside ManageTarget action: {ex.Message} Inner Exception: {ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		#endregion
	}
}
