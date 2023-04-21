using NPOMS.Domain.Lookup;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Lookup
{
	public interface IResourceListRepository : IBaseRepository<ResourceList>
	{
		Task<IEnumerable<ResourceList>> GetEntities(bool returnInactive);

		Task CreateEntity(ResourceList model);

		Task UpdateEntity(ResourceList model, int currentUserId);

		Task DeleteEntity(int id, int currentUserId);

		Task<ResourceList> GetByName(string name);
	}
}
