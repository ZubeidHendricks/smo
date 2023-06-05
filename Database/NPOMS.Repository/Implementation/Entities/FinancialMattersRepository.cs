using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Core;
using NPOMS.Domain.Entities;
using NPOMS.Repository.Interfaces;
using NPOMS.Repository.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Entities
{
    public class FinancialMattersRepository : BaseRepository<FinancialMatters>, IFinancialMattersRepository
    {
        public FinancialMattersRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

        public async Task<IEnumerable<FinancialMatters>> GetByFundingApplicationIdAsync(int fundingApplicationId)
        {
            return await FindByCondition(x => x.FundingApplicationDetailId.Equals(fundingApplicationId)).OrderBy(x => x.CreatedDateTime).AsNoTracking().ToListAsync();
        } 
        public async Task<FinancialMatters> GetById(int id)
        {
            return await FindByCondition(x => x.Id.Equals(id)).FirstOrDefaultAsync();
        }


        public async Task DeleteFinancialMattersByIdAsync(int id)
        {
            var model = FindByCondition(x => x.Id.Equals(id)).FirstOrDefault();
            await DeleteAsync(model);
        }
    }

}
