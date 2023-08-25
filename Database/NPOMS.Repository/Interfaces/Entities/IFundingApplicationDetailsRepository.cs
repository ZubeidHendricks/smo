using NPOMS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
	public interface IFundingApplicationDetailsRepository : IBaseRepository<FundingApplicationDetail>
	{
		Task<IEnumerable<FundingApplicationDetail>> GetEntities(int applicationId);

		Task CreateEntity(FundingApplicationDetail model);

		Task UpdateEntity(FundingApplicationDetail model, int currentUserId);

		Task<FundingApplicationDetail> GetById(int id);

		Task<FundingApplicationDetail> GetByApplicationId(int applicationId);
	}
}
