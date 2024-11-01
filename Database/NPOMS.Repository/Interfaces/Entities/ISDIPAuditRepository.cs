using NPOMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
    public interface ISDIPAuditRepository : IBaseRepository<SDIPReportAudit>
    {
        Task<SDIPReportAudit> GetById(int id);
        Task<IEnumerable<SDIPReportAudit>> GetByNpoId(int npoId);

        Task<SDIPReportAudit> GetByIds(int financialYearId, int applicationTypeId);

        Task CreateEntity(SDIPReportAudit model);

        Task UpdateEntity(SDIPReportAudit model, int currentUserId);

        Task UpdateEntityQC(SDIPReportAudit model, int currentUserId);
    }
}
