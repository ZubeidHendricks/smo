using NPOMS.Domain.FundingManagement;

namespace NPOMS.Repository.Interfaces.FundingManagement
{
    public interface IFundingDetailRepository : IBaseRepository<FundingDetail>
    {
        Task<IEnumerable<FundingDetail>> GetAll();

        Task<FundingDetail> GetByIds(int financialYearId, int programmeId, int subProgrammeId, int subProgrammeTypeId);

        Task<FundingDetail> GetByFundingCaptureId(int fundingCaptureId);
    }
}
