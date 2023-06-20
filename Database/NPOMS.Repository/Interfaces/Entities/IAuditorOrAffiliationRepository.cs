using NPOMS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
	public interface IAuditorOrAffiliationRepository : IBaseRepository<AuditorOrAffiliation>
	{
		Task<IEnumerable<AuditorOrAffiliation>> GetByEntityId(int entityId);

		Task UpdateEntity(AuditorOrAffiliation model, int currentUserId);
	}
}
