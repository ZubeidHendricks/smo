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
    public class ProjectInformationRepository : BaseRepository<ProjectInformation>, IProjectInformationRepository
    {
        public ProjectInformationRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async  Task CreateEntity(ProjectInformation model)
        {
            await CreateAsync(model);
        }

        public async Task<ProjectInformation> GetById(int id)
        {
            return await FindByCondition(x => x.Id.Equals(id)).Include(x => x.InitiatedQuestion).Include(x => x.PurposeQuestion).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ProjectInformation>> GetEntities(int applicationId)
        {
            return await FindByCondition(x => x.ApplicationId.Equals(applicationId))
                .Include(x => x.IsActive).AsNoTracking().ToListAsync();
        }

        public async Task UpdateEntity(ProjectInformation model, int currentUserId)
        {
            var oldEntity = await this.RepositoryContext.ProjectInformations.FindAsync(model.Id);
            await UpdateAsync(oldEntity, model, true, currentUserId);
        }
    }
}
