using NPOMS.Domain.Dropdown;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Dropdown
{
	public interface IAllocationTypeRepository : IBaseRepository<AllocationType>
	{
		Task<IEnumerable<AllocationType>> GetEntities(bool returnInactive);
	}
}
