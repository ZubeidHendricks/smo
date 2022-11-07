using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Indicator;
using NPOMS.Repository.Interfaces.Indicator;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Indicator
{
	public class WorkplanActualRepository : BaseRepository<WorkplanActual>, IWorkplanActualRepository
	{
		#region Constructors

		public WorkplanActualRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{

		}

		#endregion

		#region Methods

		public async Task<IEnumerable<WorkplanActual>> GetByActivityId(int activityId)
		{
			return await FindByCondition(x => x.ActivityId.Equals(activityId))
							.Include(x => x.FrequencyPeriod).AsNoTracking().ToListAsync();
		}

		public async Task<IEnumerable<WorkplanActual>> GetByIds(List<int> activityIds, int financialYearId, int frequencyPeriodId)
		{
			return await FindByCondition(x => activityIds.Contains(x.ActivityId) && 
											  x.FinancialYearId.Equals(financialYearId) &&
											  x.FrequencyPeriodId.Equals(frequencyPeriodId))
										.AsNoTracking().ToListAsync();
		}

		public async Task<WorkplanActual> GetByIds(WorkplanActual model)
		{
			return await FindByCondition(x => x.ActivityId.Equals(model.ActivityId) &&
											  x.FinancialYearId.Equals(model.FinancialYearId) &&
											  x.FrequencyPeriodId.Equals(model.FrequencyPeriodId))
								.AsNoTracking().FirstOrDefaultAsync();
		}

		#endregion
	}
}
