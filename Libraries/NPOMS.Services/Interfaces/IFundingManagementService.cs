using NPOMS.Services.Models.FundingManagement;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Services.Interfaces
{
    public interface IFundingManagementService
    {
        Task<IEnumerable<NpoViewModel>> GetNposForFunding();

        Task<bool> CanCaptureFunding(int financialYearId, int programmeId, int subProgrammeId, int subProgrammeTypeId);

        Task<FundingCaptureViewModel> CreateFundingCapture(FundingCaptureViewModel model, string userIdentifier);

        Task<NpoViewModel> GetById(int id);

        Task UpdateFundingCapture(FundingCaptureViewModel model, string userIdentifier);

        Task UpdateFundingDetail(FundingDetailViewModel model, string userIdentifier);

        Task UpdateSDA(SDAViewModel model, string userIdentifier);

        Task UpdateBankDetail(BankDetailViewModel model, string userIdentifier);

        Task UpdateDocument(DocumentViewModel model, string userIdentifier);
    }
}
