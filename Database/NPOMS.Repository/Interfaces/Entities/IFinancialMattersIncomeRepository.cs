using NPOMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
    public interface IFinancialMattersIncomeRepository : IBaseRepository<FinancialMattersIncome>
    {
        Task<FinancialMattersIncome> DeleteById(int id);
        Task<IEnumerable<FinancialMattersIncome>> GetByNpoProfileIdAsync(int npoProfileId);

        Task<FinancialMattersIncome> GetById(int id);

	}
}
