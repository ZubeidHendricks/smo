using NPOMS.Domain.Dropdown;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Dropdown
{
	public interface IFacilitySubDistrictRepository : IBaseRepository<FacilitySubDistrict>
	{
		Task<IEnumerable<FacilitySubDistrict>> GetEntities(bool returnInactive);
	}
}
