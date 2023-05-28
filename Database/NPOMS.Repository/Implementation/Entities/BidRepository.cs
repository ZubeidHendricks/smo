using NPOMS.Domain.Core;
using NPOMS.Repository.Interfaces;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using NPOMS.Domain.Entities;
using NPOMS.Repository.Interfaces.Entities;

namespace NPOMS.Repository.Implementation.Entities
{
    public class BidRepository : BaseRepository<FundingApplicationDetail>, IBidRepository
    {
        public BidRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }
        #region Methods

        public async Task<FundingApplicationDetail> GetById(int id)
        {
            return await FindByCondition(x => x.Id.Equals(id)).
                Include(x => x.FinancialMatters)
                .Include(impl => impl.Implementations).Include(x => x.ApplicationDetails)

                .FirstOrDefaultAsync();
        }

        public async Task<FundingApplicationDetail> GetapplicationIDAsync(int applicationId)
        {

           return await FindByCondition(x => x.ApplicationId.Equals(applicationId))
                .Include(x => x.FinancialMatters)
                .Include(impl => impl.Implementations).FirstOrDefaultAsync();
        }

        #endregion
    }

}