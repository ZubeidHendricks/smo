using NPOMS.Domain.Evaluation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Evaluation
{
	public interface ICapturedResponseRepository : IBaseRepository<CapturedResponse>
	{
		Task<IEnumerable<CapturedResponse>> GetAllAsync(bool returnInactive);

		Task<IEnumerable<CapturedResponse>> GetByFundingApplicationId(int fundingApplicationId);

		Task<IEnumerable<CapturedResponse>> GetByIds(int fundingApplicationId, int questionCategoryId);
	}
}
