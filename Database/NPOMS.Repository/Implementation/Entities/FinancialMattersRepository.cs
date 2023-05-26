using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Core;
using NPOMS.Domain.Entities;
using NPOMS.Repository.Interfaces;
using NPOMS.Repository.Interfaces.Entities;
using System;
using System.Collections.Generic;
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
        public async Task<FinancialMatters> GetById(int id)
        {
            return await FindByCondition(x => x.Id.Equals(id)).FirstOrDefaultAsync();
        }
    }

}
