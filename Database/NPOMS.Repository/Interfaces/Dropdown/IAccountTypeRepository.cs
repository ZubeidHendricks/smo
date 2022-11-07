using NPOMS.Domain.Dropdown;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Dropdown
{
	public interface IAccountTypeRepository : IBaseRepository<AccountType>
	{
		Task<IEnumerable<AccountType>> GetEntities(bool returnInactive);

		Task<AccountType> GetById(int id);
	}
}
