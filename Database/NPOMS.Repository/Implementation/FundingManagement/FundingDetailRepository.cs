using NPOMS.Domain.FundingManagement;
using NPOMS.Repository.Interfaces.FundingManagement;

namespace NPOMS.Repository.Implementation.FundingManagement
{
    public class FundingDetailRepository : BaseRepository<FundingDetail>, IFundingDetailRepository
    {
        #region Constructors

        public FundingDetailRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

        #endregion

        #region Methods

        //public async Task<IEnumerable<FundingDetail>> GetByWorkplanActualId(int workplanActualId)
        //{
        //    return await FindByCondition(x => x.WorkplanActualId.Equals(workplanActualId))
        //                    .Include(x => x.StatusId)
        //                    .Include(x => x.CreatedUser)
        //                    .OrderByDescending(x => x.CreatedDateTime).AsNoTracking().ToListAsync();
        //}

        //public async Task CreateEntity(FundingDetail model)
        //{
        //    await CreateAsync(model);
        //}

        #endregion
    }
}
