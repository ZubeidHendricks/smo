using NPOMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
    public interface IPreviousYearFinanceRepository : IBaseRepository<PreviousYearFinance>
    {
        Task<PreviousYearFinance> DeleteById(int id);
        Task<IEnumerable<PreviousYearFinance>> GetByNpoProfileIdAsync(int npoProfileId);
    }
}
