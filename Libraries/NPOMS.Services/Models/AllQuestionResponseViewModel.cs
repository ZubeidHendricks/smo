using NPOMS.Domain.Evaluation;
using System.Collections.Generic;
using System.Linq;

namespace NPOMS.Services.Models
{
	public class AllQuestionResponseViewModel
	{
		public List<QuestionResponseViewModel> _questionResponses { get; } = new();

		public List<QuestionResponseViewModel> QuestionResponses => _questionResponses;

		private AllQuestionResponseViewModel()
		{

		}

		public AllQuestionResponseViewModel(List<Question> questions, List<Response> responses)
		{
			var orderedQuestions = questions.OrderBy(x => x.QuestionSection.SortOrder).ThenBy(x => x.SortOrder).ToList();
			orderedQuestions.ForEach(question => this._questionResponses
							.Add(
									new QuestionResponseViewModel
									(
										question,
										responses.FirstOrDefault(response => response.QuestionId == question.Id)
									)
								)
							);
		}
	}
}
