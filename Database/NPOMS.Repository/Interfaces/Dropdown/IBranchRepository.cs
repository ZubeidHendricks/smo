using NPOMS.Domain.Dropdown;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Dropdown
{
	public interface IBranchRepository : IBaseRepository<Branch>
	{
		Task<IEnumerable<Branch>> GetEntities(bool returnInactive);

		Task<IEnumerable<Branch>> GetByBankId(int bankId);

		Task<Branch> GetById(int id);
	}
}
