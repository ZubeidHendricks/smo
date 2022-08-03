using NPOMS.Domain.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Core
{
	public interface IDepartmentRepository : IBaseRepository<Department>
	{
		Task<IEnumerable<Department>> GetEntities(bool returnInactive);
	}
}
