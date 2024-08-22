using NPOMS.Domain.FundingManagement;

namespace NPOMS.Repository.Interfaces.FundingManagement
{
    public interface IFundingCaptureRepository
    {
        Task<FundingCapture> GetById(int id);

        Task<FundingCapture> GetByNpoId(int npoId);
    }
}
