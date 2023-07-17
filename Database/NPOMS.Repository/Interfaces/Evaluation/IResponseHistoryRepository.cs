using NPOMS.Domain.Evaluation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Evaluation
{
	public interface IResponseHistoryRepository : IBaseRepository<ResponseHistory>
	{
		Task<IEnumerable<ResponseHistory>> GetByIds(int fundingApplicationId, int questionId, int currentUserId);
	}
}
