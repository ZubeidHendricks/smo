using NPOMS.Domain.FundingManagement;

namespace NPOMS.Repository.Interfaces.FundingManagement
{
    public interface IPaymentScheduleRepository : IBaseRepository<PaymentSchedule>
    {
        Task<PaymentSchedule> GetByFundingCaptureId(int fundingCaptureId);
    }
}
