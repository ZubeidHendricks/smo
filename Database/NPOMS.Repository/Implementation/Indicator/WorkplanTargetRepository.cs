using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Indicator;
using NPOMS.Repository.Interfaces.Indicator;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Indicator
{
	public class WorkplanTargetRepository : BaseRepository<WorkplanTarget>, IWorkplanTargetRepository
	{
		#region Constructors

		public WorkplanTargetRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{

		}

		#endregion

		#region Methods

		public async Task<IEnumerable<WorkplanTarget>> GetByActivityId(int activityId)
		{
			return await FindByCondition(x => x.ActivityId.Equals(activityId)).AsNoTracking().ToListAsync();
		}

		public async Task<WorkplanTarget> GetByIds(WorkplanTarget model)
		{
			return await FindByCondition(x => x.ActivityId.Equals(model.ActivityId) && 
										x.FinancialYearId.Equals(model.FinancialYearId) && 
										x.FrequencyId.Equals(model.FrequencyId))
					.AsNoTracking().FirstOrDefaultAsync();
		}

		#endregion
	}
}
