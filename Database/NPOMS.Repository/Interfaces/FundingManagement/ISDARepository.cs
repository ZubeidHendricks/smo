using NPOMS.Domain.FundingManagement;

namespace NPOMS.Repository.Interfaces.FundingManagement
{
    public interface ISDARepository : IBaseRepository<SDA>
    {
        Task<SDA> GetByFundingCaptureId(int fundingCaptureId);
    }
}
