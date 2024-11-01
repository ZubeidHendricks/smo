using NPOMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
    public interface IGovernanceRepository : IBaseRepository<GovernanceReport>
    {
        Task<IEnumerable<GovernanceReport>> GetEntities();

        Task<GovernanceReport> GetById(int id);

        Task<IEnumerable<GovernanceReport>> GetByPeriodId(int applicationPeriodId);

        Task<IEnumerable<GovernanceReport>> GetByNpoId(int npoId);

        Task<GovernanceReport> GetByIds(int financialYearId, int applicationTypeId);

        Task CreateEntity(GovernanceReport model);

        Task UpdateEntity(GovernanceReport model, int currentUserId);

        Task<IEnumerable<GovernanceReport>> GetByCompleteGovernanceReportPost(int applicationId, int finYear, int quarterId, int id);
        Task<IEnumerable<GovernanceReport>> CompleteGovernanceReportPost(int applicationId, int financialId, int quarterId, int currentUserId);

    }
}
