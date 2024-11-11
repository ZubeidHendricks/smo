using NPOMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
    public interface IIndicatorReportRepository : IBaseRepository<IndicatorReport>
    {
        Task<IEnumerable<IndicatorReport>> GetEntities();

        Task<IndicatorReport> GetById(int id);

        Task<IEnumerable<IndicatorReport>> GetByPeriodId( int applicationPeriodId);

        Task<IEnumerable<IndicatorReport>> GetByNpoId(int npoId);

        Task<IndicatorReport> GetByIds( int financialYearId, int applicationTypeId);

        Task CreateEntity(IndicatorReport model);

        Task UpdateEntity(IndicatorReport model, int currentUserId);
        Task UpdateEntityQC(IndicatorReport model, int currentUserId);
        Task<IEnumerable<IndicatorReport>> UpdateIndicatorReportStatus(int applicationId, int finYear, int quarterId, int id);
    }
}
