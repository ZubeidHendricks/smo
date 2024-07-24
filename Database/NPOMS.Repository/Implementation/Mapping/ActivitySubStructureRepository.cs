using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Mapping;
using NPOMS.Repository.Interfaces.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Mapping
{
    public class ActivitySubStructureRepository : BaseRepository<ActivitySubStructure>, IActivitySubStructureRepository
    {
        #region Constructors

        public ActivitySubStructureRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

        #endregion

        #region Methods

        public async Task<ActivitySubStructure> GetByModel(ActivitySubStructure model)
        {
            return await FindByCondition(x => x.ActivityId.Equals(model.ActivityId) && x.Name.Equals(model.Name) &&
                                              x.MunicipalityId.Equals(model.MunicipalityId))
                                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ActivitySubStructure>> GetByActivityId(int activityId, bool isActive)
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
