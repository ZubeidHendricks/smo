using NPOMS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
	public interface IServicesRenderedRepository : IBaseRepository<ServicesRendered>
	{
		Task<IEnumerable<ServicesRendered>> GetByNpoProfileId(int npoProfileId);

		Task DeleteEntity(int id, int currentUserId);

		Task<ServicesRendered> GetByProperties(ServicesRendered model);
	}
}
