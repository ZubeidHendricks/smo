using NPOMS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
	public interface IApplicationPeriodRepository : IBaseRepository<ApplicationPeriod>
	{
		Task<IEnumerable<ApplicationPeriod>> GetEntities();

		Task<ApplicationPeriod> GetById(int id);

		Task CreateEntity(ApplicationPeriod model);

		Task UpdateEntity(ApplicationPeriod model, int currentUserId);
	}
}
