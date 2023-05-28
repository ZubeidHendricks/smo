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
    public class MonitoringEvaluationRepository : BaseRepository<MonitoringEvaluation>,IMonitoringEvaluationRepository
    {
        public MonitoringEvaluationRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task CreateEntity(MonitoringEvaluation model)
        {
            await CreateAsync(model);

        }

        public async Task<MonitoringEvaluation> GetById(int? id)
        {
            //return await FindByCondition(x => x.Id.Equals(id)).Include(x => x.MonEvalDescription).AsNoTracking().FirstOrDefaultAsync();
            return await FindByCondition(x => x.Id.Equals(id)).FirstOrDefaultAsync();

        }


        public async Task<IEnumerable<MonitoringEvaluation>> GetEntities(int applicationId)
        {
            return await FindByCondition(x => x.ApplicationId.Equals(applicationId))
                        .Include(x => x.IsActive).AsNoTracking().ToListAsync();
        }

        public async Task UpdateEntity(MonitoringEvaluation model, int currentUserId)
        {
            var oldEntity = await this.RepositoryContext.MonitoringEvaluations.FindAsync(model.Id);
            await UpdateAsync(oldEntity, model, true, currentUserId);
        }
    }
}
