using NPOMS.Domain.Core;
using NPOMS.Domain.Dropdown;
using NPOMS.Domain.Mapping;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Core
{
	public interface IDepartmentRepository : IBaseRepository<Department>
	{
		Task<IEnumerable<Department>> GetEntities(bool returnInactive);
        Task<Department> GetDepartmentById(int id);
        Task<List<int>> GetDepartmentIdOfLogggedInUserAsync(int userId);
	}
}
