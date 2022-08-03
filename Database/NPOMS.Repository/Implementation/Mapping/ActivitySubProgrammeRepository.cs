using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Mapping;
using NPOMS.Repository.Interfaces.Mapping;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Mapping
{
	public class ActivitySubProgrammeRepository : BaseRepository<ActivitySubProgramme>, IActivitySubProgrammeRepository
	{
		#region Constructors

		public ActivitySubProgrammeRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{

		}

		#endregion

		#region Methods

		public async Task<ActivitySubProgramme> GetByModel(ActivitySubProgramme model)
		{
			return await FindByCondition(x => x.ActivityId.Equals(model.ActivityId) &&
											  x.SubProgrammeId.Equals(model.SubProgrammeId))
								.FirstOrDefaultAsync();
		}

		public async Task<IEnumerable<ActivitySubProgramme>> GetByActivityId(int activityId, bool isActive)
		{
			if (isActive)
			{
				return await FindByCondition(x => x.ActivityId.Equals(activityId) && x.IsActive.Equals(isActive)).AsNoTracking().ToListAsync();
			}
			else
			{
				// If IsActive is false, return all mappings
				return await FindByCondition(x => x.ActivityId.Equals(activityId)).AsNoTracking().ToListAsync();
			}
		}

		#endregion
	}
}
