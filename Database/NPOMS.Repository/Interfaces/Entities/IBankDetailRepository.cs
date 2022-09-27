using NPOMS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
	public interface IBankDetailRepository : IBaseRepository<BankDetail>
	{
		Task<IEnumerable<BankDetail>> GetByNpoProfileId(int npoProfileId);
	}
}
