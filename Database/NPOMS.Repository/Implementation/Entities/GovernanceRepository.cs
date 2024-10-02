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
    public class GovernanceRepository : BaseRepository<GovernanceReport>, IGovernanceRepository
    {
        public GovernanceRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task CreateEntity(GovernanceReport model)
        {
            await CreateAsync(model);
        }

        public async Task<GovernanceReport> GetById(int id)
        {
            return await FindByCondition(x => x.Id.Equals(id)).AsNoTracking().FirstOrDefaultAsync();
        }

        public Task<GovernanceReport> GetByIds(int financialYearId, int applicationTypeId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<GovernanceReport>> GetByNpoId(int npoId)
        {
            return null;
           // return await FindByCondition(x => x.Id.Equals(npoId)).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<GovernanceReport>> GetByPeriodId(int applicationPeriodId)
        {
            return await FindByCondition(x => x.ApplicationId == applicationPeriodId && x.IsActive)
                          .AsNoTracking()
                          .ToListAsync();
        }

        public async Task<IEnumerable<GovernanceReport>> GetEntities()
        {
            return await FindByCondition(x => x.IsActive).AsNoTracking().ToListAsync();
        }

        public async Task UpdateEntity(GovernanceReport model, int currentUserId)
        {
            await UpdateAsync(null, model, false, currentUserId);
        }
    }
}
