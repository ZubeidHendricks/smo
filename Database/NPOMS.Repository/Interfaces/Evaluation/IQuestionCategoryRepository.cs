using NPOMS.Domain.Evaluation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Evaluation
{
	public interface IQuestionCategoryRepository : IBaseRepository<QuestionCategory>
	{
		Task<IEnumerable<QuestionCategory>> GetAllAsync(bool returnInactive);
	}
}
