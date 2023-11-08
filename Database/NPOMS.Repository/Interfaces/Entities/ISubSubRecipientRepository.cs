using NPOMS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
	public interface ISubSubRecipientRepository : IBaseRepository<SubSubRecipient>
	{
		Task<SubSubRecipient> GetById(int id);

		Task<IEnumerable<SubSubRecipient>> GetBySubRecipientId(int subRecipientId);
	}
}
