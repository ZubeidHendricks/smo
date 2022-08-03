using NPOMS.Domain.Dropdown;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Dropdown
{
	public interface IResourceTypeRepository : IBaseRepository<ResourceType>
	{
		Task<IEnumerable<ResourceType>> GetEntities(bool returnInactive);
	}
}
