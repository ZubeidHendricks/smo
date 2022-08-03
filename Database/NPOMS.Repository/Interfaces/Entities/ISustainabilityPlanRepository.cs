using NPOMS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
	public interface ISustainabilityPlanRepository : IBaseRepository<SustainabilityPlan>
	{
		Task<IEnumerable<SustainabilityPlan>> GetEntities(int applicationId);

		Task<IEnumerable<SustainabilityPlan>> GetByActivityId(int activityId);

		Task CreateEntity(SustainabilityPlan model);

		Task UpdateEntity(SustainabilityPlan model);

		Task<SustainabilityPlan> GetById(int id);
	}
}
