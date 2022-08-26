using NPOMS.Domain.Indicator;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Indicator
{
	public interface IWorkplanActualRepository : IBaseRepository<WorkplanActual>
	{
		Task<IEnumerable<WorkplanActual>> GetByActivityId(int activityId);

		Task<WorkplanActual> GetByIds(WorkplanActual model);
	}
}
