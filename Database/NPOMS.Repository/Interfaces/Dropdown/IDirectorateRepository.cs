using NPOMS.Domain.Dropdown;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Dropdown
{
	public interface IDirectorateRepository : IBaseRepository<Directorate>
	{
		Task<IEnumerable<Directorate>> GetEntities(bool returnInactive);
	}
}
