using NPOMS.Domain.Budget;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Budget
{
	public interface IDirectorateBudgetRepository : IBaseRepository<DirectorateBudget>
	{
		Task<IEnumerable<DirectorateBudget>> GetDirectorateBudgetsByIds(int departmentId, int financialYearId);
	}
}
