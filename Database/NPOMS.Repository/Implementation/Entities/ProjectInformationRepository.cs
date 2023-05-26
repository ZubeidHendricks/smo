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

        public async Task<ProjectInformation> GetById(int? id)
        {
            var info = await FindByCondition(x => x.Id.Equals(id)).FirstOrDefaultAsync();
            return info;
        }

        public async Task UpdateEntity(ProjectInformation model, int currentUserId)
        {
            var oldEntity = await this.RepositoryContext.ProjectInformations.FindAsync(model.Id);
            await UpdateAsync(oldEntity, model, true, currentUserId);
        }
    }
}
