using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.FundingManagement;
using NPOMS.Repository.Interfaces.FundingManagement;

namespace NPOMS.Repository.Implementation.FundingManagement
{
    public class FundingCaptureRepository : BaseRepository<FundingCapture>, IFundingCaptureRepository
    {
        #region Constructors

        public FundingCaptureRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

        #endregion

        #region Methods

        public async Task<FundingCapture> GetById(int id)
        {
            return await FindByCondition(sp => sp.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task<FundingCapture> GetByNpoId(int npoId)
        {
            return await FindByCondition(sp => sp.NpoId.Equals(npoId)).FirstOrDefaultAsync();
        }

        #endregion
    }
}
