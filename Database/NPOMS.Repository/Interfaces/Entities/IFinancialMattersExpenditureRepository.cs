using NPOMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
    public interface IFinancialMattersExpenditureRepository : IBaseRepository<FinancialMattersExpenditure>
    {
        Task<FinancialMattersExpenditure> DeleteById(int id);
        Task<IEnumerable<FinancialMattersExpenditure>> GetByNpoProfileIdAsync(int npoProfileId);

        Task<FinancialMattersExpenditure> GetById(int id);

	}
}
