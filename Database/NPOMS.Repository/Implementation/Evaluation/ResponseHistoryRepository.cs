using NPOMS.Domain.Evaluation;
using NPOMS.Repository.Interfaces.Evaluation;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Evaluation
{
	public class ResponseHistoryRepository : BaseRepository<ResponseHistory>, IResponseHistoryRepository
	{
		#region Contructors

		public ResponseHistoryRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{

		}

		#endregion

		#region Methods

		public async Task<IEnumerable<ResponseHistory>> GetByIds(int fundingApplicationId, int questionId, int currentUserId)
		{
			return await FindByCondition(x => x.FundingApplicationId.Equals(fundingApplicationId) && 
											  x.QuestionId.Equals(questionId) &&
											  x.CreatedUserId.Equals(currentUserId))
							.Include(x => x.ResponseOption).Include(x => x.CreatedUser)
							.OrderByDescending(x => x.CreatedDateTime).AsNoTracking().ToListAsync();
		}

		#endregion
	}
}
