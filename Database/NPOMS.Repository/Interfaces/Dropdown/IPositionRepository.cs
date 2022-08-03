using NPOMS.Domain.Dropdown;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Dropdown
{
	public interface IPositionRepository : IBaseRepository<Position>
	{
		Task<IEnumerable<Position>> GetEntities(bool returnInactive);
	}
}
