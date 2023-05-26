using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Mapping;
using NPOMS.Repository.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Entities
{
    public class ProjectImplementationSubPlaceRepository : BaseRepository<ProjectImplementationSubPlace>, IProjectImplementationSubPlaceRepository
    {
        public ProjectImplementationSubPlaceRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

        #region Methods

        public async Task<ProjectImplementationSubPlace> GetById(int id, int implementationId)
        {
            return await FindByCondition(x => x.SubPlaceId.Equals(id) && x.ImplementationId.Equals(implementationId))
                .Include(i => i.Implementation).FirstOrDefaultAsync();

        }

        public async Task<IEnumerable<ProjectImplementationSubPlace>> GetImplementationSubPlaceByImplementationId(int implementationId)
        {
            return await FindByCondition(x => x.ImplementationId.Equals(implementationId) && x.IsActive)
                .Include(x => x.SubPlace).ToListAsync();
        }

        public async Task<IEnumerable<ProjectImplementationSubPlace>> GetAllImplementationSubPlaceByImplementationId(int implementationId)
        {
            return await FindByCondition(x => x.ImplementationId.Equals(implementationId))
                .Include(x => x.SubPlace).ToListAsync();
        }

        #endregion
    }


}
