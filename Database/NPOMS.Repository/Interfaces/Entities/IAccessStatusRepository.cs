using NPOMS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
	public interface IAccessStatusRepository : IBaseRepository<AccessStatus>
	{
		Task<IEnumerable<AccessStatus>> GetEntities(bool returnInactive);

		Task<AccessStatus> GetById(int id);
	}
}
