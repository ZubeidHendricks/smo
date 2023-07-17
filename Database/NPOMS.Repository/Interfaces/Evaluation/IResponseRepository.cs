using NPOMS.Domain.Evaluation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Evaluation
{
	public interface IResponseRepository : IBaseRepository<Response>
	{
		Task<IEnumerable<Response>> GetByIdsWithDetail(int fundingApplicationId, int currentUserId);

		Task<IEnumerable<Response>> GetByFundingApplicationId(int fundingApplicationId);

		Task<Response> GetResponseByIds(int fundingApplicationId, int questionId, int currentUserId);

		Task<IEnumerable<Response>> GetResponseCollectionByIds(int fundingApplicationId, List<int> questionIds, int createdUserId);
	}
}
