using NPOMS.Domain.Entities;
using NPOMS.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Services.Interfaces
{
    public interface IPostService
    {
        Task<IEnumerable<PostReport>> GetPostReports();

        Task<PostReport> GetIndicatorReportById(int id);

        Task<IEnumerable<PostReport>> GetPostReportByPeriodId(int applicationPeriodId);

        Task<IEnumerable<PostReport>> GetPostReportByNpoId(int npoId);

        Task<PostReport> GetByIds(int financialYearId, int applicationTypeId);

        Task CreatePostReportEntity(PostReport model, string userIdentifier);

        Task UpdatePostReportEntity(PostReport model, string currentUserId);
        Task UpdatePostReportEntityQC(PostReport model, int currentUserId);
        Task<IEnumerable<PostReport>> CompletePost(BaseCompleteViewModel model, string currentUserId);
        Task CreateAudit(PostAudit audit, string currentUderId);
    }
}
