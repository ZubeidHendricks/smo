using NPOMS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
	public interface IApplicationRepository : IBaseRepository<Application>
	{
		Task<IEnumerable<Application>> GetEntities();

		Task<Application> GetById(int id);

		Task<Application> GetByNpoIdAndPeriodId(int NpoId, int applicationPeriodId);

		Task<IEnumerable<Application>> GetByNpoId(int npoId);

		Task<Application> GetByIds(int npoId, int financialYearId, int applicationTypeId);

		Task CreateEntity(Application model);

		Task UpdateEntity(Application model, int currentUserId);
	}
}
