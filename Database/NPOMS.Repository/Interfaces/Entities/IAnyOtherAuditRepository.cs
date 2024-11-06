using NPOMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
    public interface IAnyOtherAuditRepository : IBaseRepository<AnyOtherReportAudit>
    {

        Task<AnyOtherReportAudit> GetById(int id);
        Task<IEnumerable<AnyOtherReportAudit>> GetByNpoId(int npoId);

        Task<AnyOtherReportAudit> GetByIds(int financialYearId, int applicationTypeId);

        Task CreateEntity(AnyOtherReportAudit model);

        Task UpdateEntity(AnyOtherReportAudit model, int currentUserId);

        Task UpdateEntityQC(AnyOtherReportAudit model, int currentUserId);
    }
}
