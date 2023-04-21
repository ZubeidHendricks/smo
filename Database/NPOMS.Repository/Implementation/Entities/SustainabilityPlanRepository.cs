using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Entities;
using NPOMS.Repository.Interfaces.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Entities
{
	public class SustainabilityPlanRepository : BaseRepository<SustainabilityPlan>, ISustainabilityPlanRepository
	{
		#region Constructors

		public SustainabilityPlanRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{

		}

		#endregion

		#region Methods

		public async Task<IEnumerable<SustainabilityPlan>> GetEntities(int applicationId)
		{
			return await FindByCondition(x => x.ApplicationId.Equals(applicationId))
				.Include(x => x.Activity).ThenInclude(x => x.ActivityList).AsNoTracking().ToListAsync();
		}

		public async Task<IEnumerable<SustainabilityPlan>> GetByActivityId(int activityId)
		{
			return await FindByCondition(x => x.ActivityId.Equals(activityId) && x.IsActive).AsNoTracking().ToListAsync();
		}

		public async Task CreateEntity(SustainabilityPlan model)
		{
			await CreateAsync(model);
		}

		public async Task UpdateEntity(SustainabilityPlan model, int currentUserId)
		{
			var oldEntity = await this.RepositoryContext.SustainabilityPlans.FindAsync(model.Id);
			await UpdateAsync(oldEntity, model, true, currentUserId);
		}

		public async Task<SustainabilityPlan> GetById(int id)
		{
			return await FindByCondition(x => x.Id.Equals(id)).AsNoTracking().FirstOrDefaultAsync();
		}

		#endregion
	}
}
