using NPOMS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
	public interface IFundingApplicationDetailsRepository : IBaseRepository<FundingApplicationDetails>
	{
		Task<IEnumerable<FundingApplicationDetails>> GetEntities(int applicationId);

		Task CreateEntity(FundingApplicationDetails model);

		Task UpdateEntity(FundingApplicationDetails model, int currentUserId);

		Task<FundingApplicationDetails> GetById(int id);
	}
}
