using NPOMS.Domain.Dropdown;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Dropdown
{
	public interface IRaceRepository : IBaseRepository<Race>
	{
		Task<IEnumerable<Race>> GetEntities(bool returnInactive);
	}
}
