using NPOMS.Domain.FundingManagement;

namespace NPOMS.Repository.Interfaces.FundingManagement
{
    public interface IFundingCaptureRepository : IBaseRepository<FundingCapture>
    {
        Task<IEnumerable<FundingCapture>> GetAll();

        Task<FundingCapture> GetById(int id);
    }
}
