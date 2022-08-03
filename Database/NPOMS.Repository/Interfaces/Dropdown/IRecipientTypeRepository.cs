using NPOMS.Domain.Dropdown;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Dropdown
{
	public interface IRecipientTypeRepository : IBaseRepository<RecipientType>
	{
		Task<IEnumerable<RecipientType>> GetEntities(bool returnInactive);
	}
}
