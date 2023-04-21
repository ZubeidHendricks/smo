using NPOMS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
	public interface IObjectiveRepository : IBaseRepository<Objective>
	{
		Task<IEnumerable<Objective>> GetEntities(int applicationId);

		Task CreateEntity(Objective model);

		Task UpdateEntity(Objective model, int currentUserId);

		Task<Objective> GetById(int id);
	}
}
