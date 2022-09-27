using NPOMS.Domain.Budget;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Services.Interfaces
{
	public interface IBudgetService
	{
		Task<IEnumerable<DepartmentBudget>> GetDepartmentBudgetsByIds(int departmentId, int financialYearId);

		Task Create(DepartmentBudget model, string userIdentifier);

		Task Update(DepartmentBudget model, string userIdentifier);

		Task<IEnumerable<DirectorateBudget>> GetDirectorateBudgetsByIds(int departmentId, int financialYearId);

		Task Create(DirectorateBudget model, string userIdentifier);

		Task Update(DirectorateBudget model, string userIdentifier);

		Task<IEnumerable<ProgrammeBudget>> GetProgrammeBudgetsByIds(int departmentId, int financialYearId);

		Task<ProgrammeBudget> GetProgrammeBudgetByProgrammeId(int programmeId, int financialYearId);

		Task Create(ProgrammeBudget model, string userIdentifier);

		Task Update(ProgrammeBudget model, string userIdentifier);
	}
}
