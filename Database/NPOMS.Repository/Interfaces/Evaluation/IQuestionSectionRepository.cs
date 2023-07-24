using NPOMS.Domain.Evaluation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Evaluation
{
	public interface IQuestionSectionRepository : IBaseRepository<QuestionSection>
	{
		Task<IEnumerable<QuestionSection>> GetAllAsync(bool returnInactive);
        Task<QuestionSection> DeleteById(int id);
        Task<IEnumerable<QuestionSection>> GetByQuestionCategoryId(int questioncategoryId);
	}
}
