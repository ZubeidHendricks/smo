using NPOMS.Domain.Dropdown;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Dropdown
{
	public interface IBankRepository : IBaseRepository<Bank>
	{
		Task<IEnumerable<Bank>> GetEntities(bool returnInactive);
	}
}
