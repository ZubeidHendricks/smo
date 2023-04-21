using NPOMS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
	public interface IApplicationApprovalRepository : IBaseRepository<ApplicationApproval>
	{
		Task<IEnumerable<ApplicationApproval>> GetByApplicationId(int applicationId);

		Task CreateEntity(ApplicationApproval model);

		Task UpdateEntity(ApplicationApproval model, int currentUserId);
	}
}
