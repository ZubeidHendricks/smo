using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NPOMS.Domain.Budget;
using NPOMS.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace NPOMS.API.Controllers
{
	[Route("api/budgets")]
	[ApiController]
	public class BudgetController : ExternalBaseController
	{
		#region Fields

		private ILogger<BudgetController> _logger;
		private IBudgetService _budgetService;

		#endregion

		#region Constructors

		public BudgetController(
			ILogger<BudgetController> logger,
			IBudgetService budgetService)
		{
			_logger = logger;
			_budgetService = budgetService;
		}

		#endregion

		#region Methods

		[HttpGet("department-budgets/departmentId/{departmentId}/financialYearId/{financialYearId}", Name = "GetDepartmentBudgetsByIds")]
		public async Task<IActionResult> GetDepartmentBudgetsByIds(int departmentId, int financialYearId)
		{
			try
			{
				var results = await _budgetService.GetDepartmentBudgetsByIds(departmentId, financialYearId);
				return Ok(results);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside GetDepartmentBudgetsByIds action: {ex.Message} Inner Exception: {ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpPost("department-budgets", Name = "CreateDepartmentBudget")]
		public async Task<IActionResult> CreateDepartmentBudget([FromBody] DepartmentBudget model)
		{
			try
			{
				await _budgetService.Create(model, base.GetUserIdentifier());
				return Ok(model);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside CreateDepartmentBudget action: {ex.Message} Inner Exception: {ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpPut("department-budgets", Name = "UpdateDepartmentBudget")]
		public async Task<IActionResult> UpdateDepartmentBudget([FromBody] DepartmentBudget model)
		{
			try
			{
				await _budgetService.Update(model, base.GetUserIdentifier());
				return Ok(model);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside UpdateDepartmentBudget action: {ex.Message} Inner Exception: {ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpGet("directorate-budgets/departmentId/{departmentId}/financialYearId/{financialYearId}", Name = "GetDirectorateBudgetsByIds")]
		public async Task<IActionResult> GetDirectorateBudgetsByIds(int departmentId, int financialYearId)
		{
			try
			{
				var results = await _budgetService.GetDirectorateBudgetsByIds(departmentId, financialYearId);
				return Ok(results);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside GetDirectorateBudgetsByIds action: {ex.Message} Inner Exception: {ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpPost("directorate-budgets", Name = "CreateDirectorateBudget")]
		public async Task<IActionResult> CreateDirectorateBudget([FromBody] DirectorateBudget model)
		{
			try
			{
				await _budgetService.Create(model, base.GetUserIdentifier());
				return Ok(model);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside CreateDirectorateBudget action: {ex.Message} Inner Exception: {ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpPut("directorate-budgets", Name = "UpdateDirectorateBudget")]
		public async Task<IActionResult> UpdateDirectorateBudget([FromBody] DirectorateBudget model)
		{
			try
			{
				await _budgetService.Update(model, base.GetUserIdentifier());
				return Ok(model);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside UpdateDirectorateBudget action: {ex.Message} Inner Exception: {ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpGet("programme-budgets/departmentId/{departmentId}/financialYearId/{financialYearId}", Name = "GetProgrammeBudgetsByIds")]
		public async Task<IActionResult> GetProgrammeBudgetsByIds(int departmentId, int financialYearId)
		{
			try
			{
				var results = await _budgetService.GetProgrammeBudgetsByIds(departmentId, financialYearId);
				return Ok(results);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside GetProgrammeBudgetsByIds action: {ex.Message} Inner Exception: {ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpPost("programme-budgets", Name = "CreateProgrammeBudget")]
		public async Task<IActionResult> CreateProgrammeBudget([FromBody] ProgrammeBudget model)
		{
			try
			{
				await _budgetService.Create(model, base.GetUserIdentifier());
				return Ok(model);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside CreateProgrammeBudget action: {ex.Message} Inner Exception: {ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpPut("programme-budgets", Name = "UpdateProgrammeBudget")]
		public async Task<IActionResult> UpdateProgrammeBudget([FromBody] ProgrammeBudget model)
		{
			try
			{
				await _budgetService.Update(model, base.GetUserIdentifier());
				return Ok(model);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside UpdateProgrammeBudget action: {ex.Message} Inner Exception: {ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		#endregion
	}
}
