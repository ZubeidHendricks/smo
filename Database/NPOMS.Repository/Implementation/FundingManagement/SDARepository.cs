using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.FundingManagement;
using NPOMS.Repository.Interfaces.FundingManagement;

namespace NPOMS.Repository.Implementation.FundingManagement
{
    public class SDARepository : BaseRepository<SDA>, ISDARepository
    {
        #region Constructors

        public SDARepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

        #endregion

        #region Methods

        public async Task<SDA> GetByFundingCaptureId(int fundingCaptureId)
        {
            return await FindByCondition(x => x.FundingCaptureId.Equals(fundingCaptureId))
                            .Include(x => x.Place)
                            .AsNoTracking().FirstOrDefaultAsync();
        }

        #endregion
    }
}
