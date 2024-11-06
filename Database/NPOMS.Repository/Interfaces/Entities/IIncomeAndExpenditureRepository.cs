using NPOMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
    public interface IIncomeAndExpenditureRepository : IBaseRepository<IncomeAndExpenditureReport>
    {
        Task<IEnumerable<IncomeAndExpenditureReport>> GetEntities();

        Task<IncomeAndExpenditureReport> GetById(int id);

        Task<IEnumerable<IncomeAndExpenditureReport>> GetByPeriodId(int applicationPeriodId);

        Task<IEnumerable<IncomeAndExpenditureReport>> GetByNpoId(int npoId);

        Task<IncomeAndExpenditureReport> GetByIds(int financialYearId, int applicationTypeId);

        Task CreateEntity(IncomeAndExpenditureReport model);

        Task UpdateEntity(IncomeAndExpenditureReport model, int currentUserId);
        Task UpdateEntityQC(IncomeAndExpenditureReport model, int currentUserId);
        Task<IEnumerable<IncomeAndExpenditureReport>> UpdateIncomeReportStatus(int applicationId, int finYear, int quarterId, int id);
    }
}
