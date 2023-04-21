using NPOMS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
	public interface IResourceRepository : IBaseRepository<Resource>
	{
		Task<IEnumerable<Resource>> GetEntities(int applicationId);

		Task<IEnumerable<Resource>> GetByActivityId(int activityId);

		Task CreateEntity(Resource model);

		Task UpdateEntity(Resource model, int currentUserId);

		Task<Resource> GetById(int id);
	}
}
