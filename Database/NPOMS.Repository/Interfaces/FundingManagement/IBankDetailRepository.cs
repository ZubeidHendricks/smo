using NPOMS.Domain.FundingManagement;

namespace NPOMS.Repository.Interfaces.FundingManagement
{
    public interface IBankDetailRepository : IBaseRepository<BankDetail>
    {
        Task<BankDetail> GetByFundingCaptureId(int fundingCaptureId);
    }
}
