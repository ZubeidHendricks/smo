﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NPOMS.Domain.ResourceParameters;
using NPOMS.Repository.Interfaces.Budget;
using NPOMS.Services.DenodoAPI.Interfaces;
using System;
using System.Linq;
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
                var results = await this._denodoService.GetFilteredBudgets(department, $"{year}/{year + 1}", base.GetUserIdentifier());
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetDenodoBudgets action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("departmentBudgetSummary/department/{department}/year/{year}", Name = "GetDepartmentBudgetsSummary")]
        public async Task<IActionResult> GetDepartmentBudgetsSummary(int department, int year)
        {
            try
            {
                var results = await this._denodoService.GetDepartmentBudgetsSummary(department, $"{year}/{year + 1}", base.GetUserIdentifier());

                var query = from p in results
                            group p by p.ProgrammeId into g
                            select new
                            {
                                Id = g.First().Id,
                                DepartmentId = g.First().DepartmentId,
                                FinancialYearId = g.First().FinancialYearId,
                                SubProgrammeTypeId = g.First().SubProgrammeId,
                                ProgrammeId = g.First().ProgrammeId,
                                IsActive = g.First().IsActive,
                                CreatedUserId = g.First().CreatedUserId,
                                CreatedDateTime = g.First().CreatedDateTime,
                                UpdatedUserId = g.First().UpdatedUserId,
                                UpdatedDateTime = g.First().UpdatedDateTime,
                                OriginalBudgetAmount = g.Sum(p => p.OriginalBudgetAmount),
                                AdjustedBudgetAmount = g.Sum(p => p.AdjustedBudgetAmount),
                                ProvisionalBudgetAmount = g.Sum(p => p.ProvisionalBudgetAmount),
                                DepartmentName = g.First().DepartmentName,
                                ObjectiveCode = g.First().ObjectiveCode,
                                ProgrammeName = g.First().ProgrammeName,
                                ResponsibilityCode = g.First().ResponsibilityCode,
                                SubProgrammeId = g.First().SubProgrammeId,
                                SubProgrammeName = g.First().SubProgrammeName,
                                SubProgrammeTypeName = g.First().SubProgrammeTypeName
                            };

                return Ok(query);
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
            var result = await this._denodoService.Update(adjustmentAmount, id, base.GetUserIdentifier());
            return Ok(result);
        }

        [HttpPut("add-provisionalAmount/provisionalAmount/{provisionalAmount}/id/{id}", Name = "AddBudgetProvisionalAmount")]
        public async Task<IActionResult> AddBudgetProvisionalAmount(string provisionalAmount, int id)
        {
            var result = await this._denodoService.ProvisionalAmountUpdate(provisionalAmount, id, base.GetUserIdentifier());
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
