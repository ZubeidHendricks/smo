using NPOMS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
	public interface IActivityRepository : IBaseRepository<Activity>
	{
		Task<IEnumerable<Activity>> GetByApplicationId(int applicationId);
        Task<IEnumerable<Activity>> GetByAll();

        Task<IEnumerable<Activity>> GetByObjectiveId(int objectiveId);

		Task CreateEntity(Activity model);

		Task UpdateEntity(Activity model, int currentUserId);

		Task<Activity> GetById(int id);
	}
}
