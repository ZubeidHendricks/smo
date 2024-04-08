using NPOMS.Domain.Evaluation;
using NPOMS.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Services.Interfaces
{
	public interface IEvaluationService
	{
        
        Task<IEnumerable<QuestionResponseViewModel>> GetQuestionnaire(int fundingApplicationId, string userIdentifier);
        Task<IEnumerable<QuestionResponseViewModel>> GetAddScoreQuestionnaire(int fundingApplicationId, string userIdentifier);
        Task<IEnumerable<QuestionResponseViewModel>> GetScorecardQuestionnaire(int fundingApplicationId, string userIdentifier);

        Task<IEnumerable<QuestionResponseViewModel>> GetCompletedQuestionnaires(int fundingApplicationId, int questionCategoryId, int createdUserId);

		Task<IEnumerable<ResponseHistory>> GetResponseHistory(int fundingApplicationId, int questionId, string userIdentifier);
        Task<IEnumerable<Response>> GetResponses(int fundingApplicationId, int questionId, string userIdentifier);

        Task<IEnumerable<Response>> GetResponse(int fundingApplicationId);


        Task<IEnumerable<ResponseHistory>> GetCapturedResponseHistory(int fundingApplicationId, int questionId, int createdUserId);

		Task<QuestionResponseViewModel> UpdateResponse(Response model, string userIdentifier);
        Task<QuestionResponseViewModel> UpdateScorecardResponse(Response model, string userIdentifier);

        Task<QuestionResponseViewModel> UpdateScorecardRejectionResponse(Response model, string userIdentifier, int param);

        Task<IEnumerable<CapturedResponse>> GetCapturedResponsesByIds(int fundingApplicationId, int questionCategoryId);

		Task<IEnumerable<CapturedResponse>> GetCapturedResponses(int fundingApplicationId);

		Task CreateCapturedResponse(CapturedResponse model, int createdUserId);
        Task UpdateReviewerComment(CapturedResponse model, int createdUserId);        

        Task<WorkflowAssessment> GetWorkflowAssessmentByQuestionCategoryId(int questionCategoryId);
	}
}
