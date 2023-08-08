using NPOMS.Domain.Evaluation;
using NPOMS.Repository.Interfaces.Evaluation;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Evaluation
{
	public class WorkflowAssessmentRepository : BaseRepository<WorkflowAssessment>, IWorkflowAssessmentRepository
	{
		#region Constructors

		public WorkflowAssessmentRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{

		}

		#endregion

		#region Methods

		public async Task<IEnumerable<WorkflowAssessment>> GetAllAsync(bool returnInactive)
		{
			if (returnInactive)
				return await FindAll().OrderBy(x => x.QuestionCategoryId).AsNoTracking().ToListAsync();
			else
				return await FindAll().Where(x => x.IsActive).OrderBy(x => x.QuestionCategoryId).AsNoTracking().ToListAsync();
		}

		public async Task<WorkflowAssessment> GetByQuestionCategoryId(int questionCategoryId)
		{
			return await FindByCondition(x => x.QuestionCategoryId.Equals(questionCategoryId) && x.IsActive).AsNoTracking().FirstOrDefaultAsync();
		}

        public async Task<WorkflowAssessment> DeleteById(int id)
        {
            var model = await FindByCondition(x => x.Id.Equals(id)).FirstOrDefaultAsync();
            await DeleteAsync(model);
            return model;
        }

        #endregion
    }
}
