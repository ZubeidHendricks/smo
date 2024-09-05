using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<FundingDetail>> GetAll()
        {
            return await FindAll().Where(x => x.IsActive)
                            .Include(x => x.Programme)
                            .Include(x => x.SubProgrammeType)
                            .Include(x => x.Frequency)
                            .AsNoTracking().ToListAsync();
        }

        public async Task<FundingDetail> GetByIds(int financialYearId, int programmeId, int subProgrammeId, int subProgrammeTypeId)
        {
            return await FindByCondition(x => x.FinancialYearId.Equals(financialYearId) &&
                                              x.ProgrammeId.Equals(programmeId) &&
                                              x.SubProgrammeId.Equals(subProgrammeId) &&
                                              x.SubProgrammeTypeId.Equals(subProgrammeTypeId))
                                              .Where(x => x.IsActive)
                                              .AsNoTracking()
                                              .FirstOrDefaultAsync();
        }

        public async Task<FundingDetail> GetByFundingCaptureId(int fundingCaptureId)
        {
            return await FindByCondition(x => x.FundingCaptureId.Equals(fundingCaptureId))
                            .Include(x => x.FinancialYear)
                            .Include(x => x.Frequency)
                            .Include(x => x.Programme)
                            .Include(x => x.SubProgramme)
                            .Include(x => x.SubProgrammeType)
                            .Include(x => x.FundingType)
                            .Include(x => x.CalculationType)
                            .AsNoTracking().FirstOrDefaultAsync();
        }

        #endregion
    }
}
