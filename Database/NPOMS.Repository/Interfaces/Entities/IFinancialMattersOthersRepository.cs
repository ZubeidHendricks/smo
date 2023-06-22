using NPOMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
    public interface IFinancialMattersOthersRepository : IBaseRepository<FinancialMattersOthers>
    {
        Task<FinancialMattersOthers> DeleteById(int id);
        Task<IEnumerable<FinancialMattersOthers>> GetByNpoProfileIdAsync(int npoProfileId);
    }
}
