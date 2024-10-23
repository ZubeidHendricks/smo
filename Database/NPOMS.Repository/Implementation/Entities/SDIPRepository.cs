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
    public class SDIPRepository : BaseRepository<SDIPReport>, ISDIPRepository
    {
        public SDIPRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task CreateEntity(SDIPReport model)
        {
            await CreateAsync(model);
        }

        public async Task<SDIPReport> GetById(int id)
        {
            return await FindByCondition(x => x.Id.Equals(id)).AsNoTracking().FirstOrDefaultAsync();
        }

        public async  Task<SDIPReport> GetByIds(int financialYearId, int applicationTypeId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SDIPReport>> GetByNpoId(int npoId)
        {
            return null;
        }

        public async Task<IEnumerable<SDIPReport>> GetByPeriodId(int applicationPeriodId)
        {
            return await FindByCondition(x => x.ApplicationId == applicationPeriodId && x.IsActive)
                        .Include(x => x.Status)
                        .AsNoTracking()
                        .ToListAsync();
        }

        public async Task<IEnumerable<SDIPReport>> GetEntities()
        {
            return await FindByCondition(x => x.IsActive).Include(x => x.Status).AsNoTracking().ToListAsync();
        }

        public async Task UpdateEntity(SDIPReport model, int currentUserId)
        {
            await UpdateAsync(null, model, false, currentUserId);
        }
    }
}
