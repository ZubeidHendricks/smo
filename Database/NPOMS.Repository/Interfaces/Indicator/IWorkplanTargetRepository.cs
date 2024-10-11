using NPOMS.Domain.Indicator;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Indicator
{
	public interface IWorkplanTargetRepository : IBaseRepository<WorkplanTarget>
	{
		Task<IEnumerable<WorkplanTarget>> GetByActivityId(int activityId);

		Task<WorkplanTarget> GetByIds(WorkplanTarget model);
        Task<IEnumerable<WorkplanTarget>> GetTargetsByActivityIds(List<int> activityIds);
    }
}
