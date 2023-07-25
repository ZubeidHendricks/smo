using NPOMS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
	public interface IImplementationRiskRepository : IBaseRepository<ImplementationRisk>
	{
		Task<IEnumerable<ImplementationRisk>> GetByFundingApplicationIdAsync(int fundingApplicationId);

		Task DeleteImplementationRiskByIdAsync(int id);
	}
}
