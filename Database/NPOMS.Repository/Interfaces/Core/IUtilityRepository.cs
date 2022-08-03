using NPOMS.Domain.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Core
{
	public interface IUtilityRepository : IBaseRepository<Utility>
	{
		Task<IEnumerable<Utility>> GetEntities(bool returnInactive);
	}
}
