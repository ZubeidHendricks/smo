using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NPOMS.Domain.Entities;
using NPOMS.Domain.ResourceParameters;
using NPOMS.Repository.Interfaces.Budget;
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
        private IProgrammeBudgetRepository _programmeBudgetRepository;

        #endregion

        #region Constructors

        public DenodoController(
			ILogger<DenodoController> logger,
			IDenodoService denodoService,
            IProgrammeBudgetRepository programmeBudgetRepository
            )
		{
			_logger = logger;
			_denodoService = denodoService;  
            _programmeBudgetRepository = programmeBudgetRepository;
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

        [HttpGet("filteredBudgets/department/{department}/year/{year}", Name = "GetDenodoFilteredBudgets")]
        public async Task<IActionResult> GetDenodoFilteredBudgets(int department, int year)
        {
            try
            {
                var results = await this._denodoService.GetFilteredBudgets(department, $"{year}/{year + 1}");
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetDenodoBudgets action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("add-budgetAdjustment/adjustmentAmount/{adjustmentAmount}/id/{id}", Name = "AddBudgetAdjustmentAmount")]
        public async Task<IActionResult> AddBudgetAdjustmentAmount( string adjustmentAmount, int id)
        {
           // var model = _programmeBudgetRepository.GetProgrammeBudgetById(id);
            
            var result = await this._denodoService.Update(adjustmentAmount, id, base.GetUserIdentifier());
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
