using NPOMS.Domain.Indicator;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Indicator
{
	public interface IWorkplanActualAuditRepository : IBaseRepository<WorkplanActualAudit>
	{
		Task<IEnumerable<WorkplanActualAudit>> GetByWorkplanActualId(int workplanActualId);

		Task CreateEntity(WorkplanActualAudit model);
	}
}
