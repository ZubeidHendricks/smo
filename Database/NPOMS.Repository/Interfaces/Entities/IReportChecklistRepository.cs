using NPOMS.Domain.Entities;

namespace NPOMS.Repository.Interfaces.Entities
{
    public interface IReportChecklistRepository : IBaseRepository<ReportChecklist>
    {

        Task<IEnumerable<ReportChecklist>> GetEntities();

        Task<ReportChecklist> GetById(int id);

        Task<ReportChecklist> GetByPeriodIdAndqtrId(int applicationPeriodId, int qterId);
    }
}
