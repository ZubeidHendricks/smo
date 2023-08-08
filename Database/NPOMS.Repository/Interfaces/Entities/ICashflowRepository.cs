using NPOMS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
	public interface ICashflowRepository : IBaseRepository<Cashflow>
	{
		Task<IEnumerable<Cashflow>> GetByFundingApplicationIdAsync(int fundingApplicationId);

		Task DeleteCashflowByIdAsync(int id);
	}
}
