using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Entities;
using NPOMS.Repository.Interfaces.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Entities
{
	public class FundingApplicationDetailsRepository : BaseRepository<FundingApplicationDetail>, IFundingApplicationDetailsRepository
	{
		#region Constructors

		public FundingApplicationDetailsRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{

		}

		#endregion

		#region Methods

		public async Task<IEnumerable<FundingApplicationDetail>> GetEntities(int applicationId)
		{
			return await FindByCondition(x => x.ApplicationId.Equals(applicationId))
				.AsNoTracking().ToListAsync();
		}

		public async Task CreateEntity(FundingApplicationDetail model)
		{
			await CreateAsync(model);
		}

		public async Task UpdateEntity(FundingApplicationDetail model, int currentUserId)
		{
			var oldEntity = await this.RepositoryContext.FundingApplicationDetails.FindAsync(model.Id);
			await UpdateAsync(oldEntity, model, true, currentUserId);
		}

		public async Task<FundingApplicationDetail> GetById(int id)
		{
            return await FindByCondition(x => x.Id.Equals(id))
                .AsNoTracking().FirstOrDefaultAsync();
        }

		public async Task<FundingApplicationDetail> GetByApplicationId(int applicationId)
		{
			return await FindByCondition(x => x.ApplicationId.Equals(applicationId))
							.Include(x => x.ApplicationDetails)
								.ThenInclude(x => x.FundAppSDADetail)
									.ThenInclude(x => x.DistrictCouncil)
							.Include(x => x.ApplicationDetails)                            
                                .ThenInclude(x => x.FundAppSDADetail)
									.ThenInclude(x => x.LocalMunicipality)
                                    .Include(x => x.ProjectInformation)
                            .AsNoTracking().FirstOrDefaultAsync();
		}


		#endregion
	}
}
