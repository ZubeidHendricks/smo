using NPOMS.Services.Models.FundingManagement;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Services.Interfaces
{
    public interface IFundingManagementService
    {
        Task<IEnumerable<NpoViewModel>> GetNposForFunding(string userIdentifier);

        Task<FundingCaptureViewModel> CreateFundingCapture(FundingCaptureViewModel model, string userIdentifier);

        Task<NpoViewModel> GetById(int id);

        Task UpdateFundingCapture(FundingCaptureViewModel model, string userIdentifier);

        Task UpdateFundingDetail(FundingDetailViewModel model, string userIdentifier);

        Task UpdateSDA(SDAViewModel model, string userIdentifier);

        Task<PaymentScheduleViewModel> GeneratePaymentSchedule(int fundingCaptureId, int frequencyId, string startDate, double amountAwarded);

        Task UpdatePaymentSchedules(PaymentScheduleViewModel model, string userIdentifier);

        Task UpdateBankDetail(BankDetailViewModel model, string userIdentifier);

        Task UpdateDocument(DocumentViewModel model, string userIdentifier);

        Task UpdateApproverDetail(FundingCaptureViewModel model, string userIdentifier);
    }
}
