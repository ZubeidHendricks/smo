using NPOMS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
    public interface IApplicationRepository : IBaseRepository<Application>
    {
        Task<IEnumerable<Application>> GetEntities();
        Task CreateNpoUserTracking(IEnumerable<NpoUserTracking> npoUserTrackings);
        Task CreateNpoUserSatisfactionTracking(IEnumerable<NpoUserSatisfactionTracking> npoUserSatisfactionTracking);

        Task CreateNpoWorkPlanApproverTracking(IEnumerable<NpoWorkPlanApproverTracking> npoWorkPlanApproverTracking);

        Task<Application> GetById(int id);

        Task<Application> GetByNpoIdAndPeriodId(int NpoId, int applicationPeriodId);

        Task<IEnumerable<Application>> GetByNpoId(int npoId);

        Task<Application> GetByIds(int npoId, int financialYearId, int applicationTypeId);

        Task CreateEntity(Application model);

        Task UpdateEntity(Application model, int currentUserId);
        Task UpdateEntityQC(Application model, int currentUserId);
        Task CreateNpoUserReviewerTracking(IEnumerable<NpoWorkPlanReviewerTracking> npoWorkPlanReviewerTrackingList);
    }
}
