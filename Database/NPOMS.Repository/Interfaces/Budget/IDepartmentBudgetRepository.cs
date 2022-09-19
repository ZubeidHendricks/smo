using NPOMS.Domain.Budget;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Budget
{
	public interface IDepartmentBudgetRepository : IBaseRepository<DepartmentBudget>
	{
		Task<IEnumerable<DepartmentBudget>> GetDepartmentBudgetsByIds(int departmentId, int financialYearId);
	}
}
