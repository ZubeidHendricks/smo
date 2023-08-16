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
    public class FinancialMattersIncomeRepository : BaseRepository<FinancialMattersIncome>, IFinancialMattersIncomeRepository
    {
        public FinancialMattersIncomeRepository(RepositoryContext repositoryContext)
           : base(repositoryContext)
        {

        }
        public async Task<IEnumerable<FinancialMattersIncome>> GetByNpoProfileIdAsync(int fundingApplicationId)
        {
            return await FindByCondition(x => x.npoProfileId.Equals(fundingApplicationId) && x.IsActive).OrderBy(x => x.CreatedDateTime).AsNoTracking().ToListAsync();
        }
        public async Task<FinancialMattersIncome> GetById(int id)
        {
            return await FindByCondition(x => x.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task<FinancialMattersIncome> DeleteById(int id)
        {
            var model = await FindByCondition(x => x.Id.Equals(id)).FirstOrDefaultAsync();
            await DeleteAsync(model);
            return model;
        }

        private Task<FinancialMattersIncome> DeleteAsync(Task<FinancialMattersIncome> model)
        {
            throw new NotImplementedException();
        }
        
    }
}
