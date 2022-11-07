using NPOMS.Domain.Indicator;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Indicator
{
	public interface IWorkplanActualRepository : IBaseRepository<WorkplanActual>
	{
		Task<IEnumerable<WorkplanActual>> GetByActivityId(int activityId);

		/// <summary>
		/// Get WorkplanActuals by ActivityIds, FinancialYearId and FrequencyPeriodId
		/// </summary>
		/// <param name="activityIds"></param>
		/// <param name="financialYearId"></param>
		/// <param name="frequencyPeriodId"></param>
		/// <returns></returns>
		Task<IEnumerable<WorkplanActual>> GetByIds(List<int> activityIds, int financialYearId, int frequencyPeriodId);

		Task<WorkplanActual> GetByIds(WorkplanActual model);
	}
}
