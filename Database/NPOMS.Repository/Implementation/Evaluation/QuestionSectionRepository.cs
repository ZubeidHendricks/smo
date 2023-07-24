using NPOMS.Domain.Evaluation;
using NPOMS.Repository.Interfaces.Evaluation;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Evaluation
{
	public class QuestionSectionRepository : BaseRepository<QuestionSection>, IQuestionSectionRepository
	{
		#region Constructors

		public QuestionSectionRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{

		}

		#endregion

		#region Methods

		public async Task<IEnumerable<QuestionSection>> GetAllAsync(bool returnInactive)
		{
			if (returnInactive)
				return await FindAll().OrderBy(x => x.QuestionCategoryId).ThenBy(y => y.SortOrder).AsNoTracking().ToListAsync();
			else
				return await FindAll().Where(x => x.IsActive).OrderBy(x => x.QuestionCategoryId).ThenBy(y => y.SortOrder).AsNoTracking().ToListAsync();
		}

		public async Task<IEnumerable<QuestionSection>> GetByQuestionCategoryId(int questioncategoryId)
		{
			return await FindByCondition(x => x.QuestionCategoryId.Equals(questioncategoryId) && x.IsActive)
										.OrderBy(x => x.SortOrder).AsNoTracking().ToListAsync();
		}

        public async Task<QuestionSection> DeleteById(int id)
        {
            var model = await FindByCondition(x => x.Id.Equals(id)).FirstOrDefaultAsync();
            await DeleteAsync(model);
            return model;
        }

        #endregion
    }
}
