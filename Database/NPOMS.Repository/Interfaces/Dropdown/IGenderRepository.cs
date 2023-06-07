using NPOMS.Domain.Dropdown;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Dropdown
{
	public interface IGenderRepository : IBaseRepository<Gender>
	{
		Task<IEnumerable<Gender>> GetEntities(bool returnInactive);
	}
}
