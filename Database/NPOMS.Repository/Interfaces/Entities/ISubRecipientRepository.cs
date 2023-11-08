using NPOMS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
	public interface ISubRecipientRepository : IBaseRepository<SubRecipient>
	{
		Task<SubRecipient> GetById(int id);

		Task<IEnumerable<SubRecipient>> GetByObjectiveId(int objectiveId);
	}
}
