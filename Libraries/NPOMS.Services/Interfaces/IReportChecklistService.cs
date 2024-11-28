using NPOMS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Services.Interfaces
{
    public  interface IReportChecklistService
    {
        Task<IEnumerable<ReportChecklist>> GetEntities();


        Task<ReportChecklist> GetByPeriodIdAndqtrId(int applicationPeriodId,  int qtrId);

        Task CreateEntity(ReportChecklist model, string userIdentifier);

        Task UpdateEntity(ReportChecklist model, string currentUserId);

        Task CreateAudit(ReportChecklist audit, string currentUderId);
    }
}
