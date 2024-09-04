using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.FundingManagement;
using NPOMS.Repository.Interfaces.FundingManagement;

namespace NPOMS.Repository.Implementation.FundingManagement
{
    public class PaymentScheduleRepository : BaseRepository<PaymentSchedule>, IPaymentScheduleRepository
    {
        #region Constructors

        public PaymentScheduleRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

        #endregion

        #region Methods

        public async Task<PaymentSchedule> GetByFundingCaptureId(int fundingCaptureId)
        {
            return await FindByCondition(x => x.FundingCaptureId.Equals(fundingCaptureId)).Include(x => x.PaymentScheduleItems.Where(y => y.IsActive)).AsNoTracking().FirstOrDefaultAsync();
        }

        #endregion
    }
}
