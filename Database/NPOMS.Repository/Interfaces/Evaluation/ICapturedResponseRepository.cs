using NPOMS.Domain.Evaluation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Evaluation
{
	public interface ICapturedResponseRepository : IBaseRepository<CapturedResponse>
	{
		Task<IEnumerable<CapturedResponse>> GetAllAsync(bool returnInactive);

		Task<IEnumerable<CapturedResponse>> GetByFundingApplicationId(int fundingApplicationId);
        Task<CapturedResponse> DeleteById(int id);
        Task<IEnumerable<CapturedResponse>> GetByIds(int fundingApplicationId, int questionCategoryId);
        Task<CapturedResponse> GetByIds(int fundingApplicationId, int questionCategoryId, int userId);
        Task<CapturedResponse> GetById(int id);
    }
}
