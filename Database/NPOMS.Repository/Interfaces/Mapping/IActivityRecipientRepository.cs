using NPOMS.Domain.Mapping;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Mapping
{
	public interface IActivityRecipientRepository : IBaseRepository<ActivityRecipient>
	{
		Task<IEnumerable<ActivityRecipient>> GetByActivityId(int activityId);

		Task DeleteEntity(int activityId);
	}
}
