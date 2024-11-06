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
    public class AuditGovernanceRepository : BaseRepository<GovernanceAudit>, IAuditGovernanceRepository
    {
        public AuditGovernanceRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task CreateEntity(GovernanceAudit model)
        {
            await CreateAsync(model);
        }

        public async Task<GovernanceAudit> GetById(int id)
        {
            return await FindByCondition(x => x.Id.Equals(id)).AsNoTracking().FirstOrDefaultAsync();
        }

        public Task<GovernanceAudit> GetByIds(int financialYearId, int applicationTypeId)
        {
            throw new NotImplementedException();
        }

        public async  Task<IEnumerable<GovernanceAudit>> GetByNpoId(int npoId)
        {
            return null;
        }

        public async Task UpdateEntity(GovernanceAudit model, int currentUserId)
        {
            await UpdateAsync(null, model, false, currentUserId);
        }

        public async Task UpdateEntityQC(GovernanceAudit model, int currentUserId)
        {
            throw new NotImplementedException();
        }
    }
}
