using NPOMS.Domain.Entities;
using NPOMS.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Services.Interfaces
{
    public interface ISDIPService 
    {
        Task<IEnumerable<SDIPReport>> GetSDIPReports();

        Task<SDIPReport> GetSDIPReportById(int id);

        Task<IEnumerable<SDIPReport>> GetSDIPReportByPeriodId(int applicationPeriodId);

        Task<IEnumerable<SDIPReport>> GetSDIPReportByNpoId(int npoId);

        Task<SDIPReport> GetByIds(int financialYearId, int applicationTypeId);

        Task CreateSDIPReportEntity(SDIPReport model, string userIdentifier);

        Task UpdateSDIPReportEntity(SDIPReport model, string currentUserId);
        Task UpdateSDIPStatus(BaseCompleteViewModel model, string userIdentifier);
    }
}
