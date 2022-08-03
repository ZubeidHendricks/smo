using NPOMS.Domain.Dropdown;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Dropdown
{
	public interface IFacilityDistrictRepository : IBaseRepository<FacilityDistrict>
	{
		Task<IEnumerable<FacilityDistrict>> GetEntities(bool returnInactive);
	}
}
