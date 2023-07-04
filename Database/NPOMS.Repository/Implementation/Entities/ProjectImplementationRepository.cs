using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Entities;
using NPOMS.Repository.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Entities
{
    public class ProjectImplementationRepository : BaseRepository<ProjectImplementation>, IProjectImplementationRepository
    {
        public ProjectImplementationRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }


        public async Task<ProjectImplementation> DeleteById(int id)
        {
            var model = await FindByCondition(x => x.Id.Equals(id)).FirstOrDefaultAsync();
            await DeleteAsync(model);
            return model;
        }

        public async Task<IEnumerable<ProjectImplementation>> GetAllByNpoProfileId(int npoProfileId)
        {
            //throw new NotImplementedException();

            return await FindByCondition(x => x.NpoProfileId.Equals(npoProfileId))
                            .AsNoTracking().ToListAsync();
        }



        public async Task<ProjectImplementation> GetById(int id)
        {
            return await FindByCondition(x => x.Id.Equals(id)).Include(x => x.ImplementationPlaces)
               .Include(x => x.ImplementationSubPlaces).FirstOrDefaultAsync();

        }
    }
}
