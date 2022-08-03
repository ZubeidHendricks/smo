using NPOMS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
	public interface INpoProfileRepository : IBaseRepository<NpoProfile>
	{
		Task<IEnumerable<NpoProfile>> GetEntities();

		Task<NpoProfile> GetById(int id);

		Task CreateEntity(NpoProfile model);

		Task UpdateEntity(NpoProfile model);

		Task<NpoProfile> GetByNpoId(int NpoId);
	}
}
