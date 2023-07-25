using NPOMS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
	public interface IMunicipalResourceContributionRepository : IBaseRepository<MunicipalResourceContribution>
	{
		Task<IEnumerable<MunicipalResourceContribution>> GetByFundingApplicationIdAsync(int fundingApplicationId);

		Task DeleteMunicipalResourceContributionByIdAsync(int id);
	}
}
