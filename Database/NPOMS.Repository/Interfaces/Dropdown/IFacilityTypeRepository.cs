using NPOMS.Domain.Dropdown;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Dropdown
{
	public interface IFacilityTypeRepository : IBaseRepository<FacilityType>
	{
		Task<IEnumerable<FacilityType>> GetEntities(bool returnInactive);
	}
}
