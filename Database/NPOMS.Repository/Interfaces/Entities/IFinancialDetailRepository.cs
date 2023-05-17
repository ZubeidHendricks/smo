using NPOMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
    public interface IFinancialDetailRepository :IBaseRepository<FinancialDetail>
    {
        Task<IEnumerable<FinancialDetail>> GetEntities(int applicationId);

        Task CreateEntity(FinancialDetail model);

        Task UpdateEntity(FinancialDetail model, int currentUserId);
        Task<FinancialDetail> GetById(int id);
    }
}
