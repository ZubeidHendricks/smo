using NPOMS.Domain.Dropdown;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Dropdown
{
	public interface IActivityTypeRepository : IBaseRepository<ActivityType>
	{
		Task<IEnumerable<ActivityType>> GetEntities(bool returnInactive);
	}
}
