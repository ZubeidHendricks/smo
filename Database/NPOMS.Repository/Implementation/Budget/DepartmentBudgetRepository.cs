using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Budget;
using NPOMS.Repository.Interfaces.Budget;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Budget
{
	public class DepartmentBudgetRepository : BaseRepository<DepartmentBudget>, IDepartmentBudgetRepository
	{
		#region Constructors

		public DepartmentBudgetRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{

		}

		#endregion

		#region Methods

		public async Task<IEnumerable<DepartmentBudget>> GetDepartmentBudgetsByIds(int departmentId, int financialYearId)
		{
			return await FindByCondition(x => x.DepartmentId.Equals(departmentId) && x.FinancialYearId.Equals(financialYearId) && x.IsActive)
							.AsNoTracking().ToListAsync();
		}

		#endregion
	}
}
