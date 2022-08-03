using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Mapping;
using NPOMS.Repository.Interfaces.Mapping;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Mapping
{
	public class ActivityFacilityListRepository : BaseRepository<ActivityFacilityList>, IActivityFacilityListRepository
	{
		#region Constructors

		public ActivityFacilityListRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{

		}

		#endregion

		#region Methods

		public async Task<ActivityFacilityList> GetByModel(ActivityFacilityList model)
		{
			return await FindByCondition(x => x.ActivityId.Equals(model.ActivityId) &&
											  x.FacilityListId.Equals(model.FacilityListId))
								.FirstOrDefaultAsync();
		}

		public async Task<IEnumerable<ActivityFacilityList>> GetByActivityId(int activityId, bool isActive)
		{
			if (isActive)
			{
				return await FindByCondition(x => x.ActivityId.Equals(activityId) && x.IsActive.Equals(isActive)).Include(x => x.FacilityList).AsNoTracking().ToListAsync();
			}
			else
			{
				// If IsActive is false, return all mappings
				return await FindByCondition(x => x.ActivityId.Equals(activityId)).Include(x => x.FacilityList).AsNoTracking().ToListAsync();
			}
		}

		#endregion
	}
}
