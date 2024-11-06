using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NPOMS.Domain.Mapping;
using NPOMS.Repository.Interfaces.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Mapping
{
    public class ActivitySubDistrictRepository : BaseRepository<ActivitySubDistrict>, IActivitySubDistrictRepository
    {
        #region Constructors

        public ActivitySubDistrictRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

        #endregion

        #region Methods

        //public async Task<ActivitySubDistrict> GetByModel(ActivitySubDistrict model)
        //{
        //    return await FindByCondition(x => x.ActivityId.Equals(model.ActivityId) && x.SubstructureId.Equals(model.SubstructureId) &&
        //                                      x.SubstructureId.Equals(model.SubstructureId))
        //                        .FirstOrDefaultAsync();
        //}

        //public async Task<ActivitySubDistrict> GetByModel(ActivitySubDistrict model)
        //{
        //    return await FindByCondition(x => x.ActivityId.Equals(model.ActivityId) &&
        //                                      (string.IsNullOrEmpty(model.SubstructureId.ToString())
        //                                          ? x.AreaId.Equals(model.AreaId)
        //                                          : x.SubstructureId.Equals(model.SubstructureId)))
        //                                .FirstOrDefaultAsync();
        //}

        public async Task<ActivitySubDistrict> GetByModel(ActivitySubDistrict model)
        {
            return await FindByCondition(x => x.ActivityId.Equals(model.ActivityId) &&
                                              x.Name.Equals(model.Name) &&
                                              (model.SubstructureId == 0
                                                  ? x.AreaId.Equals(model.AreaId)
                                                  : x.SubstructureId.Equals(model.SubstructureId)))
                                        .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ActivitySubDistrict>> GetByActivityId(int activityId, bool isActive)
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
