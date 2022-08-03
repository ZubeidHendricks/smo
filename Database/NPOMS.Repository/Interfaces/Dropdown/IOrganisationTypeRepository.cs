using NPOMS.Domain.Dropdown;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Dropdown
{
	public interface IOrganisationTypeRepository : IBaseRepository<OrganisationType>
	{
		Task<IEnumerable<OrganisationType>> GetEntities(bool returnInactive);

		Task<OrganisationType> GetById(int id);
	}
}
