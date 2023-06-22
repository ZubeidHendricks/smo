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
    public class FinancialMattersExpenditureRepository : BaseRepository<FinancialMattersExpenditure>, IFinancialMattersExpenditureRepository
    {
        public FinancialMattersExpenditureRepository(RepositoryContext repositoryContext)
           : base(repositoryContext)
        {

        }
        public async Task<IEnumerable<FinancialMattersExpenditure>> GetByNpoProfileIdAsync(int fundingApplicationId)
        {
            return await FindByCondition(x => x.npoProfileId.Equals(fundingApplicationId)).OrderBy(x => x.CreatedDateTime).AsNoTracking().ToListAsync();
        }
        public async Task<FinancialMattersExpenditure> GetById(int id)
        {
            return await FindByCondition(x => x.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task<FinancialMattersExpenditure> DeleteById(int id)
        {
            var model = await FindByCondition(x => x.Id.Equals(id)).FirstOrDefaultAsync();
            await DeleteAsync(model);
            return model;
        }

        private Task<FinancialMattersExpenditure> DeleteAsync(Task<FinancialMattersExpenditure> model)
        {
            throw new NotImplementedException();
        }
        
    }
}
