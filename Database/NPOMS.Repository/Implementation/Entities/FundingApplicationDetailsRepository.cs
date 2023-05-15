using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Entities;
using NPOMS.Repository.Interfaces.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Entities
{
	public class FundingApplicationDetailsRepository : BaseRepository<FundingApplicationDetails>, IFundingApplicationDetailsRepository
	{
		#region Constructors

		public FundingApplicationDetailsRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{

		}

		#endregion

		#region Methods

		public async Task<IEnumerable<FundingApplicationDetails>> GetEntities(int applicationId)
		{
			return await FindByCondition(x => x.ApplicationId.Equals(applicationId))
				.Include(x => x.IsActive).AsNoTracking().ToListAsync();
		}

		public async Task CreateEntity(FundingApplicationDetails model)
		{
			await CreateAsync(model);
		}

		public async Task UpdateEntity(FundingApplicationDetails model, int currentUserId)
		{
			var oldEntity = await this.RepositoryContext.FundingApplicationDetails.FindAsync(model.Id);
			await UpdateAsync(oldEntity, model, true, currentUserId);
		}

		public async Task<FundingApplicationDetails> GetById(int id)
		{
            return await FindByCondition(x => x.Id.Equals(id)).Include(x => x.LocalMunicipality).Include(x=>x.DistrictCouncil).AsNoTracking().FirstOrDefaultAsync();
        }


        #endregion
    }
}
