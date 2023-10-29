using NPOMS.Services.Interfaces;
using NPOMS.Domain.Evaluation;
using NPOMS.Repository.Interfaces.Core;
using NPOMS.Repository.Interfaces.Evaluation;
using NPOMS.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Services.Implementation
{
    public class EvaluationService : IEvaluationService
    {

        #region Fields

        private IUserRepository _userRepository;
        private IQuestionRepository _questionRepository;
        private IResponseRepository _responseRepository;
        private IResponseHistoryRepository _responseHistoryRepository;
        private ICapturedResponseRepository _capturedResponseRepository;
        private IWorkflowAssessmentRepository _workflowAssessmentRepository;
        private IQuestionSectionRepository _questionSectionRepository;

        #endregion

        #region Constructors

        public EvaluationService(
            IUserRepository userRepository,
            IQuestionRepository questionRepository,
            IResponseRepository responseRepository,
            IResponseHistoryRepository responseHistoryRepository,
            ICapturedResponseRepository capturedResponseRepository,
            IWorkflowAssessmentRepository workflowAssessmentRepository,
            IQuestionSectionRepository questionSectionRepository)
        {
            _userRepository = userRepository;
            _questionRepository = questionRepository;
            _responseRepository = responseRepository;
            _responseHistoryRepository = responseHistoryRepository;
            _capturedResponseRepository = capturedResponseRepository;
            _workflowAssessmentRepository = workflowAssessmentRepository;
            _questionSectionRepository = questionSectionRepository;
        }

        #endregion

        #region Methods

        public async Task<IEnumerable<QuestionResponseViewModel>> GetQuestionnaire(int fundingApplicationId, string userIdentifier)
        {
            var currentUser = await _userRepository.GetUserByUserNameWithDetailsAsync(userIdentifier);
            var questions = await _questionRepository.GetAllWithDetails();
            var responses = await _responseRepository.GetByIdsWithDetail(fundingApplicationId, currentUser.Id);

            return new AllQuestionResponseViewModel(questions.ToList(), responses.ToList()).QuestionResponses;
        }

        public async Task<IEnumerable<QuestionResponseViewModel>> GetCompletedQuestionnaires(int fundingApplicationId, int questionCategoryId, int createdUserId)
        {
            var questionSections = await _questionSectionRepository.GetByQuestionCategoryId(questionCategoryId);
            var questions = await _questionRepository.GetByQuestionSectionIds(questionSections.Select(x => x.Id).ToList());
            var responses = await _responseRepository.GetResponseCollectionByIds(fundingApplicationId, questions.Select(x => x.Id).ToList(), createdUserId);

            return new AllQuestionResponseViewModel(questions.ToList(), responses.ToList()).QuestionResponses;
        }

        public async Task<IEnumerable<ResponseHistory>> GetResponseHistory(int fundingApplicationId, int questionId, string userIdentifier)
        {
            var currentUser = await _userRepository.GetUserByUserNameWithDetailsAsync(userIdentifier);
            return await _responseHistoryRepository.GetByIds(fundingApplicationId, questionId, currentUser.Id);
        }

        public async Task<IEnumerable<Response>> GetResponse(int fundingApplicationId)
        {
            return await _responseRepository.GetByFundingApplicationId(fundingApplicationId);
        }

        public async Task<IEnumerable<ResponseHistory>> GetCapturedResponseHistory(int fundingApplicationId, int questionId, int createdUserId)
        {
            return await _responseHistoryRepository.GetByIds(fundingApplicationId, questionId, createdUserId);
        }

        public async Task<QuestionResponseViewModel> UpdateResponse(Response model, string userIdentifier)
        {
            var currentUser = await _userRepository.GetUserByUserNameWithDetailsAsync(userIdentifier);
            var response = await _responseRepository.GetResponseByIds(model.FundingApplicationId, model.QuestionId, currentUser.Id);

            if (response == null)
            {
                model.CreatedUserId = currentUser.Id;
                model.CreatedDateTime = DateTime.Now;
                await _responseRepository.CreateAsync(model);
            }
            else
            {
                response.ResponseOptionId = model.ResponseOptionId;
                response.Comment = model.Comment;
                response.UpdatedUserId = currentUser.Id;
                response.UpdatedDateTime = DateTime.Now;
                await _responseRepository.UpdateAsync(response);
            }

            var newResponse = response == null ? true : false;
            var modelToReturn = response == null ? model : response;

            await CreateResponseHistory(modelToReturn, newResponse);

            var question = await _questionRepository.GetById(model.QuestionId);
            //var documents = await _documentStoreRepository.GetByEntityTypeId((int)EntityTypeEnum.TPAEvidence);
            //var paymentScheduleResponse = await _paymentScheduleResponseRepository.GetByIds(model.ApplicationId, model.QuestionId);

            return new QuestionResponseViewModel(question, modelToReturn);
        }

        private async Task CreateResponseHistory(Response model, bool newResponse)
        {
            await _responseHistoryRepository.CreateAsync(
                    new ResponseHistory
                    {
                        FundingApplicationId = model.FundingApplicationId,
                        QuestionId = model.QuestionId,
                        ResponseOptionId = model.ResponseOptionId,
                        Comment = model.Comment,
                        CreatedUserId = newResponse ? model.CreatedUserId : Convert.ToInt32(model.UpdatedUserId),
                        CreatedDateTime = newResponse ? model.CreatedDateTime : Convert.ToDateTime(model.UpdatedDateTime)
                    });
        }

        public async Task<IEnumerable<CapturedResponse>> GetCapturedResponsesByIds(int fundingApplicationId, int questionCategoryId)
        {
            return await _capturedResponseRepository.GetByIds(fundingApplicationId, questionCategoryId);
        }

        public async Task<IEnumerable<CapturedResponse>> GetCapturedResponses(int fundingApplicationId)
        {
            return await _capturedResponseRepository.GetByFundingApplicationId(fundingApplicationId);
        }

        public async Task CreateCapturedResponse(CapturedResponse model, string userIdentifier)
        {
            var currentUser = await _userRepository.GetUserByUserNameWithDetailsAsync(userIdentifier);

            model.CreatedUser = null;
            model.CreatedUserId = currentUser.Id;
            model.CreatedDateTime = DateTime.Now;

            await _capturedResponseRepository.CreateAsync(model);
        }

        public async Task<WorkflowAssessment> GetWorkflowAssessmentByQuestionCategoryId(int questionCategoryId)
        {
            return await _workflowAssessmentRepository.GetByQuestionCategoryId(questionCategoryId);
        }

        #endregion
    }
}
