using NPOMS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
	public interface IContactInformationRepository : IBaseRepository<ContactInformation>
	{
		Task<IEnumerable<ContactInformation>> GetByNpoId(int NpoId);

		Task DeleteEntity(int id, Npo model, int currentUserId);
	}
}
