using NPOMS.Domain.Evaluation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Evaluation
{
	public interface IResponseRepository : IBaseRepository<Response>
	{
        Task<IEnumerable<Response>> GetAllResponses();
        Task<IEnumerable<Response>> GetByIdsWithDetail(int fundingApplicationId, int currentUserId);

        Task<IEnumerable<Response>> GetByIdsWithDetailReport(int fundingApplicationId,int qtrId, int currentUserId);
        Task<IEnumerable<Response>> GetScorecardByIdsWithDetail(int fundingApplicationId, int currentUserId);

        Task<IEnumerable<Response>> GetByFundingApplicationId(int fundingApplicationId);

		Task<Response> GetResponseByIds(int fundingApplicationId, int questionId, int currentUserId);
        Task<Response> GetReportResponseByIds(int fundingApplicationId, int questionId, int qtrId, int currentUserId);
        
        Task<Response> GetResponseByIds(int fundingApplicationId, int questionId, int responseOptionId, int createdUserId);
        Task<Response> GetResponses(int fundingApplicationId, int questionId, int responseOptionId);
        Task<Response> GetResponses(int fundingApplicationId, int questionId, int responseOptionId, int CREATEDuSERiD);
        Task<IEnumerable<Response>> GetByFIdandQId(int fundingApplicationId, int questionId, int currentUserId);
        Task<Response> DeleteById(int id);
        Task<IEnumerable<Response>> GetResponseCollectionByIds(int fundingApplicationId, List<int> questionIds, int createdUserId);
	}
}
