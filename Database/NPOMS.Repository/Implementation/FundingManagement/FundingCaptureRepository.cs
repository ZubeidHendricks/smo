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

        public async Task<IEnumerable<FundingCapture>> GetAll()
        {
            return await FindAll().Where(x => x.IsActive)
                            .Include(x => x.FinancialYear)
                            .Include(x => x.Status)
                            .AsNoTracking().ToListAsync();
        }

        public async Task<FundingCapture> GetById(int id)
        {
            return await FindByCondition(x => x.Id.Equals(id)).AsNoTracking().FirstOrDefaultAsync();
        }

        #endregion
    }
}
