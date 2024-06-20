using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NPOMS.Domain.Entities;
using NPOMS.Domain.ResourceParameters;
using NPOMS.Repository.Interfaces.Core;
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
				var results = await this._denodoService.Get(denodoFacilityResourceParameters, base.GetUserIdentifier());
				return Ok(results);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside GetDenodoFacilities action: {ex.Message} Inner Exception: { ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

        [HttpGet("budgets/department/{department}/year/{year}", Name = "GetDenodoBudgets")]
        public async Task<IActionResult> GetDenodoBudgets(string department, int year)
        {
            try
            {
                var results = await this._denodoService.GetBudgets(department, $"{year}/{year + 1}", base.GetUserIdentifier());
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetDenodoBudgets action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("budgets/department/{department}/year/{year}/responsibilitylowestlevelcode/{responsibilitylowestlevelcode}/objectivelowestlevelcode/{objectivelowestlevelcode}", Name = "GetDenodoFilteredBudgets")]
        public async Task<IActionResult> GetDenodoFilteredBudgets(string department, int year, string responsibilitylowestlevelcode, string objectivelowestlevelcode)
        {
            try
            {
                var results = await this._denodoService.GetBudgets(department, $"{year}/{year + 1}", responsibilitylowestlevelcode, objectivelowestlevelcode, base.GetUserIdentifier());
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetDenodoBudgets action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("add-budgetAdjustment/responsibilityCode/{responsibilityCode}/objectiveCode/{objectiveCode}/amount/{amount}", Name = "AddBudgetAdjustmentAmount")]
        public async Task<IActionResult> AddBudgetAdjustmentAmount( string responsibilityCode, string objectiveCode, decimal amount)
        {
            var result = await this._denodoService.Create(responsibilityCode, objectiveCode, amount);
            return Ok(result);
        }

        [HttpPost("import-budget/department/{department}/year/{year}", Name = "ImportBudget")]
        public async Task<IActionResult> ImportBudget(string department, int year)
        {
            var result = await this._denodoService.ImportBudget(department, $"{year}/{year + 1}", base.GetUserIdentifier());
            return Ok(result);
        }

        #endregion
    }
}
