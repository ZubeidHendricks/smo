using NPOMS.Domain.Lookup;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Lookup
{
	public interface IFacilityListRepository : IBaseRepository<FacilityList>
	{
		Task<IEnumerable<FacilityList>> GetEntities(bool returnInactive);

		Task<IEnumerable<FacilityList>> SearchByName(string name);

		Task CreateEntity(FacilityList model);

		Task UpdateEntity(FacilityList model);

		Task DeleteEntity(int id);

		Task<FacilityList> GetByProperties(FacilityList model);
	}
}
