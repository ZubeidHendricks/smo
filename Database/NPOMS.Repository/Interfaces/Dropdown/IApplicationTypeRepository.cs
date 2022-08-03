using NPOMS.Domain.Dropdown;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Dropdown
{
	public interface IApplicationTypeRepository : IBaseRepository<ApplicationType>
	{
		Task<IEnumerable<ApplicationType>> GetEntities(bool returnInactive);
	}
}
