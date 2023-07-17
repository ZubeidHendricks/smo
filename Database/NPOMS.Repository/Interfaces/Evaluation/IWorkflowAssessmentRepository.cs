using NPOMS.Domain.Evaluation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Evaluation
{
	public interface IWorkflowAssessmentRepository : IBaseRepository<WorkflowAssessment>
	{
		Task<IEnumerable<WorkflowAssessment>> GetAllAsync(bool returnInactive);

		Task<WorkflowAssessment> GetByQuestionCategoryId(int questionCategoryId);
	}
}
