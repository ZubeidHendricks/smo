using NPOMS.Domain.Dropdown;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Dropdown
{
	public interface IProvisionTypeRepository : IBaseRepository<ProvisionType>
	{
		Task<IEnumerable<ProvisionType>> GetEntities(bool returnInactive);
	}
}
