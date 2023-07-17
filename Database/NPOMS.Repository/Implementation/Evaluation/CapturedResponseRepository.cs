using NPOMS.Domain.Evaluation;
using NPOMS.Repository.Interfaces.Evaluation;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Evaluation
{
	public class CapturedResponseRepository : BaseRepository<CapturedResponse>, ICapturedResponseRepository
	{
		#region Constructors

		public CapturedResponseRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{

		}

		#endregion

		#region Methods

		public async Task<IEnumerable<CapturedResponse>> GetAllAsync(bool returnInactive)
		{
			if (returnInactive)
				return await FindAll().AsNoTracking().ToListAsync();
			else
				return await FindAll().Where(x => x.IsActive).AsNoTracking().ToListAsync();
		}

		public async Task<IEnumerable<CapturedResponse>> GetByFundingApplicationId(int fundingApplicationId)
		{
			return await FindByCondition(x => x.FundingApplicationId.Equals(fundingApplicationId) && x.IsActive)
							.Include(x => x.CreatedUser).AsNoTracking().ToListAsync();
		}

		public async Task<IEnumerable<CapturedResponse>> GetByIds(int fundingApplicationId, int questionCategoryId)
		{
			return await FindByCondition(x => x.FundingApplicationId.Equals(fundingApplicationId) &&
											  x.QuestionCategoryId.Equals(questionCategoryId) &&
											  x.IsActive)
							.AsNoTracking().ToListAsync();
		}

		#endregion
	}
}
