using NPOMS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
	public interface IApplicationAuditRepository : IBaseRepository<ApplicationAudit>
	{
		Task<IEnumerable<ApplicationAudit>> GetByApplicationId(int applicationId);

		Task CreateEntity(ApplicationAudit model);
	}
}
