using NPOMS.Domain.Mapping;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Mapping
{
	public interface IActivityFacilityListRepository : IBaseRepository<ActivityFacilityList>
	{
		Task<ActivityFacilityList> GetByModel(ActivityFacilityList model);

		Task<IEnumerable<ActivityFacilityList>> GetByActivityId(int activityId, bool isActive);
	}
}
