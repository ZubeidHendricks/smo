using NPOMS.Domain.Entities;

namespace NPOMS.Repository.Interfaces.Entities
{
    public interface IAuditIndicatorRepository : IBaseRepository<IndicatorReportAudit>
    {
        Task<IndicatorReportAudit> GetById(int id);
        Task<IEnumerable<IndicatorReportAudit>> GetByNpoId(int npoId);

        Task<IndicatorReportAudit> GetByIds(int financialYearId, int applicationTypeId);

        Task CreateEntity(IndicatorReportAudit model);

        Task UpdateEntity(IndicatorReportAudit model, int currentUserId);

        Task UpdateEntityQC(IndicatorReportAudit model, int currentUserId);
    }
}
