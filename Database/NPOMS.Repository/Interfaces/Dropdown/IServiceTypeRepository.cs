using NPOMS.Domain.Dropdown;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Dropdown
{
	public interface IServiceTypeRepository : IBaseRepository<ServiceType>
	{
		Task<IEnumerable<ServiceType>> GetEntities(bool returnInactive);
	}
}
