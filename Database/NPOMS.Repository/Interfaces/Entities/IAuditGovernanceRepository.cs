using NPOMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
    public interface IAuditGovernanceRepository : IBaseRepository<GovernanceAudit>
    {
        Task<GovernanceAudit> GetById(int id);
        Task<IEnumerable<GovernanceAudit>> GetByNpoId(int npoId);

        Task<GovernanceAudit> GetByIds(int financialYearId, int applicationTypeId);

        Task CreateEntity(GovernanceAudit model);

        Task UpdateEntity(GovernanceAudit model, int currentUserId);

        Task UpdateEntityQC(GovernanceAudit model, int currentUserId);
    }
}
