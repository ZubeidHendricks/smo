using NPOMS.Domain.Entities;
using NPOMS.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Services.Interfaces
{
    public interface IGovernanceService
    {
        Task<IEnumerable<GovernanceReport>> GetGovernanceReports();

        Task<GovernanceReport> GetGovernanceById(int id);

        Task<IEnumerable<GovernanceReport>> GetGovernanceReportByPeriodId(int applicationPeriodId);

        Task<IEnumerable<GovernanceReport>> GetGovernanceReportByNpoId(int npoId);

        Task<GovernanceReport> GetByIds(int financialYearId, int applicationTypeId);

        Task CreateGovernanceReportEntity(GovernanceReport model, string userIdentifier);

        Task UpdateGovernanceReportEntity(GovernanceReport model, string currentUserId);
        Task UpdateGovernanceReportEntityQC(GovernanceReport model, int currentUserId);
        Task CompleteGovernanceReportPost(BaseCompleteViewModel model, string userIdentifier);
    }
}
