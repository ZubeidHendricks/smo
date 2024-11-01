using NPOMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
    public interface IIncomeAuditRepository : IBaseRepository<IncomeReportAudit>
    {
        Task<IncomeReportAudit> GetById(int id);
        Task<IEnumerable<IncomeReportAudit>> GetByNpoId(int npoId);

        Task<IncomeReportAudit> GetByIds(int financialYearId, int applicationTypeId);

        Task CreateEntity(IncomeReportAudit model);

        Task UpdateEntity(IncomeReportAudit model, int currentUserId);

        Task UpdateEntityQC(IncomeReportAudit model, int currentUserId);
    }
}
