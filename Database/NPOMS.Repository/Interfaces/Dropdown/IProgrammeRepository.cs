using NPOMS.Domain.Dropdown;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Dropdown
{
	public interface IProgrammeRepository : IBaseRepository<Programme>
	{
		Task<IEnumerable<Programme>> GetEntities(bool returnInactive);
	}
}
