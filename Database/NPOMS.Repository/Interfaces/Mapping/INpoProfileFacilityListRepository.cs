using NPOMS.Domain.Mapping;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Mapping
{
	public interface INpoProfileFacilityListRepository : IBaseRepository<NpoProfileFacilityList>
	{
		Task<IEnumerable<NpoProfileFacilityList>> GetByNpoProfileId(int npoProfileId);

		Task<NpoProfileFacilityList> GetByModel(NpoProfileFacilityList model);

		Task DeleteEntity(int id);
	}
}
