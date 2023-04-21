using NPOMS.Domain.Lookup;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Lookup
{
	public interface IActivityListRepository : IBaseRepository<ActivityList>
	{
		Task<IEnumerable<ActivityList>> GetEntities(bool returnInactive);

		Task<IEnumerable<ActivityList>> SearchByName(string name);

		Task CreateEntity(ActivityList model);

		Task UpdateEntity(ActivityList model, int currentUserId);

		Task DeleteEntity(int id, int currentUserId);

		Task<ActivityList> GetByName(string name);
	}
}
