using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Entities;
using NPOMS.Repository.Interfaces.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Entities
{
	public class ApplicationReviewerSatisfactionRepository : BaseRepository<ApplicationReviewerSatisfaction>, IApplicationReviewerSatisfactionRepository
	{
		#region Constructors

		public ApplicationReviewerSatisfactionRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{

		}

		#endregion

		#region Methods

		public async Task<IEnumerable<ApplicationReviewerSatisfaction>> GetByApplicationId(int applicationId)
		{
			return await FindByCondition(x => x.ApplicationId.Equals(applicationId))
				.Include(x => x.CreatedUser).OrderByDescending(x => x.CreatedDateTime).AsNoTracking().ToListAsync();
		}

		public async Task<IEnumerable<ApplicationReviewerSatisfaction>> GetByIds(int applicationId, int serviceProvisionStepId, int entityId)
		{
			return await FindByCondition(x => x.ApplicationId.Equals(applicationId) &&
										 x.ServiceProvisionStepId.Equals(serviceProvisionStepId) &&
										 x.EntityId.Equals(entityId))
				.Include(x => x.CreatedUser).OrderByDescending(x => x.CreatedDateTime).AsNoTracking().ToListAsync();
		}

		public async Task CreateEntity(ApplicationReviewerSatisfaction model)
		{
			await CreateAsync(model);
		}

		#endregion
	}
}
