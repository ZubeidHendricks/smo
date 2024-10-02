using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Mapping;
using NPOMS.Repository.Interfaces.Mapping;

namespace NPOMS.Repository.Implementation.Mapping
{
    public class ActivityAreaRepository : BaseRepository<ActivityArea>, IActivityAreaRepository
    {
        #region Constructors

        public ActivityAreaRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

        #endregion

        #region Methods

        public async Task<ActivityArea> GetByModel(ActivityArea model)
        {
            return await FindByCondition(x => x.ActivityId.Equals(model.ActivityId) &&
                                              x.DemographicDistrictId.Equals(model.DemographicDistrictId) &&
                                              x.Name.Equals(model.Name))
                                        .FirstOrDefaultAsync();
        }


        public async Task<IEnumerable<ActivityArea>> GetByActivityId(int activityId, bool isActive)
        {
            if (isActive)
            {
                return await FindByCondition(x => x.ActivityId.Equals(activityId) && x.IsActive.Equals(isActive)).AsNoTracking().ToListAsync();
            }
            else
            {
                return await FindByCondition(x => x.ActivityId.Equals(activityId)).AsNoTracking().ToListAsync();
            }
        }

        #endregion
    }
}
