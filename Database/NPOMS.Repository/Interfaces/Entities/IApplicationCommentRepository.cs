using NPOMS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
	public interface IApplicationCommentRepository : IBaseRepository<ApplicationComment>
	{
		Task<IEnumerable<ApplicationComment>> GetByApplicationId(int applicationId);

		Task<IEnumerable<ApplicationComment>> GetByIds(int applicationId, int serviceProvisionStepId, int entityId);

		Task CreateEntity(ApplicationComment model);
	}
}
