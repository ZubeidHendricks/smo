using NPOMS.Domain.Evaluation;
using NPOMS.Repository.Interfaces.Evaluation;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Evaluation
{
	public class QuestionRepository : BaseRepository<Question>, IQuestionRepository
	{
		#region Constructors

		public QuestionRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{

		}

		#endregion

		#region Methods

		public async Task<IEnumerable<Question>> GetAllAsync(bool returnInactive)
		{
			if (returnInactive)
				return await FindAll().OrderBy(x => x.QuestionSectionId).ThenBy(y => y.SortOrder).Include(x => x.QuestionProperty).AsNoTracking().ToListAsync();
			else
				return await FindAll().Where(x => x.IsActive).OrderBy(x => x.QuestionSectionId).ThenBy(y => y.SortOrder).Include(x => x.QuestionProperty).AsNoTracking().ToListAsync();
		}

		public async Task<IEnumerable<Question>> GetAllWithDetails()
		{
			return await FindByCondition(x =>  x.IsActive)
							.Include(x => x.QuestionSection)
								.ThenInclude(x => x.QuestionCategory)
							.Include(x => x.QuestionProperty)
							.AsNoTracking().ToListAsync();
		}

		public async Task<Question> GetById(int id)
		{
			return await FindByCondition(x => x.Id.Equals(id))
							.Include(x => x.QuestionSection)
								.ThenInclude(x => x.QuestionCategory)
							.Include(x => x.QuestionProperty)
							.AsNoTracking().FirstOrDefaultAsync();
		}

		public async Task<IEnumerable<Question>> GetByQuestionSectionIds(List<int> questionSectionIds)
		{
			return await FindByCondition(x => questionSectionIds.Contains(x.QuestionSectionId) && x.IsActive)
							.Include(x => x.QuestionSection)
								.ThenInclude(x => x.QuestionCategory)
							.Include(x => x.QuestionProperty)
							.AsNoTracking().ToListAsync();
		}

        public async Task<Question> DeleteById(int id)
        {
            var model = await FindByCondition(x => x.Id.Equals(id)).FirstOrDefaultAsync();
            await DeleteAsync(model);
            return model;
        }

        #endregion
    }
}
