using NPOMS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
	public interface IStatusRepository : IBaseRepository<Status>
	{
		Task<IEnumerable<Status>> GetEntities(bool returnInactive);

		Task<Status> GetById(int id);
	}
}
