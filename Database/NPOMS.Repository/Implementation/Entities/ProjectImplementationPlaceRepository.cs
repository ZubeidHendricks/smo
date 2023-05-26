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
    public class ProjectImplementationPlaceRepository : BaseRepository<ProjectImplementationPlace>, IProjectImplementationPlaceRepository
    {
        public ProjectImplementationPlaceRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

        #region Methods

        public async Task<ProjectImplementationPlace> GetById(int id, int implId)
        {
            var region = await FindByCondition(x => x.PlaceId.Equals(id) && x.ImplementationId.Equals(implId)).Include(i => i.Implementation).FirstOrDefaultAsync();
            return region;
        }

        public async Task<IEnumerable<ProjectImplementationPlace>> GetImplementationPlaceByImplementationId(int implementationId)
        {
            return await FindByCondition(x => x.ImplementationId.Equals(implementationId) && x.IsActive)
                .Include(x => x.Place).ToListAsync();
        }

        public async Task<IEnumerable<ProjectImplementationPlace>> GetAllImplementationPlaceByImplementationId(int geographicalDetailId)
        {
            return await FindByCondition(x => x.ImplementationId.Equals(geographicalDetailId))
                .Include(x => x.Place).ToListAsync();
        }

        #endregion
    }

}
