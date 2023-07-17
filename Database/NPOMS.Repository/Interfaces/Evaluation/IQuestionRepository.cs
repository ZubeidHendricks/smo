using NPOMS.Domain.Evaluation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Evaluation
{
	public interface IQuestionRepository : IBaseRepository<Question>
	{
		Task<IEnumerable<Question>> GetAllAsync(bool returnInactive);

		Task<IEnumerable<Question>> GetAllWithDetails();

		Task<Question> GetById(int id);

		Task<IEnumerable<Question>> GetByQuestionSectionIds(List<int> questionSectionIds);
	}
}
