using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.FundingManagement;
using NPOMS.Repository.Interfaces.FundingManagement;

namespace NPOMS.Repository.Implementation.FundingManagement
{
    public class BankDetailRepository : BaseRepository<BankDetail>, IBankDetailRepository
    {
        #region Constructors

        public BankDetailRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

        #endregion

        #region Methods

        public async Task<BankDetail> GetByFundingCaptureId(int fundingCaptureId)
        {
            return await FindByCondition(x => x.FundingCaptureId.Equals(fundingCaptureId))
                            .Include(x => x.ProgramBankDetails)
                            .AsNoTracking().FirstOrDefaultAsync();
        }

        #endregion
    }
}
