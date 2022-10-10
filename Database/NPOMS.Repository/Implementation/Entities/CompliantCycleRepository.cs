using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Entities;
using NPOMS.Repository.Interfaces.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Entities
{
	public class CompliantCycleRepository : BaseRepository<CompliantCycle>, ICompliantCycleRepository
	{
		#region Constructors

		public CompliantCycleRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{

		}

		#endregion

		#region Methods

		public async Task<IEnumerable<CompliantCycle>> GetCompliantCyclesByIds(int departmentId, int financialYearId)
		{
			return await FindByCondition(x => x.DepartmentId.Equals(departmentId) && 
										 x.FinancialYearId.Equals(financialYearId) && 
										 x.IsActive)
							.OrderBy(x => x.CompliantCycleRuleId).ToListAsync();
		}

		#endregion
	}
}
