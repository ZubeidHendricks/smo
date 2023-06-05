using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Core;
using NPOMS.Domain.Entities;
using NPOMS.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
    public interface IFinancialMattersRepository : IBaseRepository<FinancialMatters>
    {
		Task<IEnumerable<FinancialMatters>> GetByFundingApplicationIdAsync(int fundingApplicationId);

        Task<FinancialMatters> GetById(int id);
        Task DeleteFinancialMattersByIdAsync(int id);
    }
}
