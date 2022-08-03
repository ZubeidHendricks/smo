using NPOMS.Domain.Dropdown;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Dropdown
{
	public interface IFacilityClassRepository : IBaseRepository<FacilityClass>
	{
		Task<IEnumerable<FacilityClass>> GetEntities(bool returnInactive);
	}
}
