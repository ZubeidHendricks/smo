using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NPOMS.Domain.ResourceParameters;
using NPOMS.Services.DenodoAPI.Interfaces;
using System;
using System.Threading.Tasks;

namespace NPOMS.API.Controllers
{
	[Route("api/denodo")]
	[ApiController]
	public class DenodoController : ExternalBaseController
	{
		#region Fields

		private ILogger<DenodoController> _logger;
		private IDenodoService _denodoService;

		#endregion

		#region Constructors

		public DenodoController(
			ILogger<DenodoController> logger,
			IDenodoService denodoService
			)
		{
			_logger = logger;
			_denodoService = denodoService;
		}

		#endregion

		#region Methods

		[HttpGet(Name = "GetDenodoFacilities")]
		public async Task<IActionResult> GetDenodoFacilities([FromQuery] DenodoFacilityResourceParameters denodoFacilityResourceParameters)
		{
			try
			{
				var results = await this._denodoService.Get(denodoFacilityResourceParameters);
				return Ok(results);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside GetDenodoFacilities action: {ex.Message} Inner Exception: { ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		#endregion
	}
}
