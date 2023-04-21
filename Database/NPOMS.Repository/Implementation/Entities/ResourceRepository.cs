using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Entities;
using NPOMS.Repository.Interfaces.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Entities
{
	public class ResourceRepository : BaseRepository<Resource>, IResourceRepository
	{
		#region Constructors

		public ResourceRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{

		}

		#endregion

		#region Methods

		public async Task<IEnumerable<Resource>> GetEntities(int applicationId)
		{
			return await FindByCondition(x => x.ApplicationId.Equals(applicationId))
					.Include(x => x.Activity).ThenInclude(x => x.ActivityList)
					.Include(x => x.ResourceType).Include(x => x.ServiceType).Include(x => x.AllocationType)
					.Include(x => x.ResourceList).Include(x => x.ProvisionType).AsNoTracking().ToListAsync();
		}

		public async Task<IEnumerable<Resource>> GetByActivityId(int activityId)
		{
			return await FindByCondition(x => x.ActivityId.Equals(activityId) && x.IsActive).AsNoTracking().ToListAsync();
		}

		public async Task CreateEntity(Resource model)
		{
			await CreateAsync(model);
		}

		public async Task UpdateEntity(Resource model, int currentUserId)
		{
			var oldEntity = await this.RepositoryContext.Resources.FindAsync(model.Id);
			await UpdateAsync(oldEntity, model, true, currentUserId);
		}

		public async Task<Resource> GetById(int id)
		{
			return await FindByCondition(x => x.Id.Equals(id))
							.Include(x => x.ResourceType)
							.Include(x => x.ServiceType)
							.Include(x => x.AllocationType)
							.AsNoTracking()
							.FirstOrDefaultAsync();
		}

		#endregion
	}
}
