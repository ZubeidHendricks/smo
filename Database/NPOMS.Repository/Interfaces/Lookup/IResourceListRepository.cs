using NPOMS.Domain.Lookup;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Lookup
{
	public interface IResourceListRepository : IBaseRepository<ResourceList>
	{
		Task<IEnumerable<ResourceList>> GetEntities(bool returnInactive);

		Task CreateEntity(ResourceList model);

		Task UpdateEntity(ResourceList model);

		Task DeleteEntity(int id);

		Task<ResourceList> GetByName(string name);
	}
}
