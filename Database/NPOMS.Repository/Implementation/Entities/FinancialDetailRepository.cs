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
    public class FinancialDetailRepository : BaseRepository<FinancialDetail>, IFinancialDetailRepository
    {
        public FinancialDetailRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task CreateEntity(FinancialDetail model)
        {
			await CreateAsync(model);
        }

        public async Task<FinancialDetail> GetById(int id)
        {
            return await FindByCondition(x => x.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<FinancialDetail>> GetEntities(int applicationId)
        {
            return await FindByCondition(x => x.ApplicationId.Equals(applicationId))
                .AsNoTracking().ToListAsync();
        }

        public async Task UpdateEntity(FinancialDetail model, int currentUserId)
        {

            //var oldEntity = await this.RepositoryContext.FinancialDetails.FindAsync(model.Id);
            //await UpdateAsync(oldEntity, model, true, currentUserId);
            throw new NotImplementedException();
        }
    }
}
