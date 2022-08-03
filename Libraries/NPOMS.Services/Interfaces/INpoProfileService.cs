using NPOMS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Services.Interfaces
{
	public interface INpoProfileService
	{
		Task<IEnumerable<NpoProfile>> Get(string userIdentifier);

		Task<NpoProfile> GetById(int id);

		Task Create(NpoProfile profile, string userIdentifier);

		Task Update(NpoProfile profile, string userIdentifier);

		Task<NpoProfile> GetByNpoId(int NpoId);
	}
}
