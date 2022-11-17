using NPOMS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
	public interface IApplicationReviewerSatisfactionRepository : IBaseRepository<ApplicationReviewerSatisfaction>
	{
		Task<IEnumerable<ApplicationReviewerSatisfaction>> GetByApplicationId(int applicationId);

		Task<IEnumerable<ApplicationReviewerSatisfaction>> GetByIds(int applicationId, int serviceProvisionStepId, int entityId);

		Task CreateEntity(ApplicationReviewerSatisfaction model);
	}
}
