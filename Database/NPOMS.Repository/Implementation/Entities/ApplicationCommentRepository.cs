using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Entities;
using NPOMS.Repository.Interfaces.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Entities
{
	public class ApplicationCommentRepository : BaseRepository<ApplicationComment>, IApplicationCommentRepository
	{
		#region Constructors

		public ApplicationCommentRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{

		}

		#endregion

		#region Methods

		public async Task<IEnumerable<ApplicationComment>> GetByApplicationId(int applicationId)
		{
			return await FindByCondition(x => x.ApplicationId.Equals(applicationId))
				.Include(x => x.CreatedUser).OrderByDescending(x => x.CreatedDateTime).AsNoTracking().ToListAsync();
		}

		public async Task<IEnumerable<ApplicationComment>> GetByIds(int applicationId, int serviceProvisionStepId, int entityId)
		{
			return await FindByCondition(x => x.ApplicationId.Equals(applicationId) &&
										 x.ServiceProvisionStepId.Equals(serviceProvisionStepId) &&
										 x.EntityId.Equals(entityId))
				.Include(x => x.CreatedUser).OrderByDescending(x => x.CreatedDateTime).AsNoTracking().ToListAsync();
		}

		public async Task CreateEntity(ApplicationComment model)
		{
			await CreateAsync(model);
		}

		#endregion
	}
}
