using NPOMS.Domain.Entities;
using NPOMS.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Services.Interfaces
{
    public interface IIncomeAndExpenditureService
    {
        Task<IEnumerable<IncomeAndExpenditureReport>> GetIncomeReports();

        Task<IncomeAndExpenditureReport> GetIncomeReportById(int id);

        Task<IEnumerable<IncomeAndExpenditureReport>> GetIncomeReportByPeriodId(int applicationPeriodId);

        Task<IEnumerable<IncomeAndExpenditureReport>> GetIncomeReportByNpoId(int npoId);

        Task<IncomeAndExpenditureReport> GetByIds(int financialYearId, int applicationTypeId);

        Task CreateIncomeReportEntity(IncomeAndExpenditureReport model, string userIdentifier);

        Task UpdateIncomeReportEntity(IncomeAndExpenditureReport model, string currentUserId);
        Task UpdateIncomeReportEntityQC(IncomeAndExpenditureReport model, int currentUserId);
        Task UpdateIncomeReportStatus(BaseCompleteViewModel model, string v);
    }
}
