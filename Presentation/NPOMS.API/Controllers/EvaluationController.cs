using NPOMS.Domain.Entities;
using NPOMS.Domain.Enumerations;
using NPOMS.Domain.Evaluation;
using NPOMS.Services.Email;
using NPOMS.Services.Email.EmailTemplates;
using NPOMS.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using NPOMS.Services.Implementation;

namespace NPOMS.API.Controllers
{
	[Route("api/evaluation")]
	[ApiController]
	public class EvaluationController : ExternalBaseController
	{
		#region Fields

		private ILogger<EvaluationController> _logger;
		private IEvaluationService _evaluationService;
	//	private IFundingApplicationService _fundingApplicationService;
		private IApplicationService _applicationService;
		private IEmailService _emailService;
		private IDropdownService _dropdownService;

		#endregion

		#region Constructors

		public EvaluationController(
			ILogger<EvaluationController> logger,
			IEvaluationService evaluationService,
			//IFundingApplicationService fundingApplicationService,
			IApplicationService applicationService,
			IEmailService emailService,
			IDropdownService dropdownService)
		{
			_logger = logger;
			_evaluationService = evaluationService;
			//_fundingApplicationService = fundingApplicationService;
			_applicationService = applicationService;
			_emailService = emailService;
			_dropdownService = dropdownService;

        }

		#endregion

		#region Methods

		[HttpGet("fundingApplicationId/{fundingApplicationId}")]
		public async Task<IActionResult> GetQuestionnaire(int fundingApplicationId)
		{
			try
			{
				var results = await _evaluationService.GetQuestionnaire(fundingApplicationId, base.GetUserIdentifier());
				return Ok(results);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside GetQuestionnaire action: {ex.Message} Inner Exception: {ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

        [HttpGet("funId/{funId}")]
        public async Task<IActionResult> GetAddScoreQuestionnaire(int funId)
        {
            try
            {
                var results = await _evaluationService.GetAddScoreQuestionnaire(funId, base.GetUserIdentifier());
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetQuestionnaire action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpGet("fId/{fId}")]
        public async Task<IActionResult> GetScorecardQuestionnaire(int fId)
        {
            try
            {
                var results = await _evaluationService.GetScorecardQuestionnaire(fId, base.GetUserIdentifier());
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetQuestionnaire action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("completed-questionnaires/fundingApplicationId/{fundingApplicationId}/questionCategoryId/{questionCategoryId}/createdUserId/{createdUserId}", Name = "GetCompletedQuestionnaires")]
		public async Task<IActionResult> GetCompletedQuestionnaires(int fundingApplicationId, int questionCategoryId, int createdUserId)
		{
			try
			{
				var results = await _evaluationService.GetCompletedQuestionnaires(fundingApplicationId, questionCategoryId, createdUserId);
				return Ok(results);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside GetCompletedQuestionnaires action: {ex.Message} Inner Exception: {ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpGet("fundingApplicationId/{fundingApplicationId}/questionId/{questionId}", Name = "GetResponseHistory")]
		public async Task<IActionResult> GetResponseHistory(int fundingApplicationId, int questionId)
		{
			try
			{
				var results = await _evaluationService.GetResponseHistory(fundingApplicationId, questionId, base.GetUserIdentifier());
				return Ok(results);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside GetResponseHistory action: {ex.Message} Inner Exception: {ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpGet("fundingAppId/{fundingAppId}/questionId/{questionId}", Name = "getResponses")]
		public async Task<IActionResult> GetResponses(int fundingAppId, int questionId)
		{
			try
			{
				var results = await _evaluationService.GetResponses(fundingAppId, questionId, base.GetUserIdentifier());
				return Ok(results);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside GetResponseHistory action: {ex.Message} Inner Exception: {ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpGet("Id/{id}")]
        public async Task<IActionResult> GetResponse(int id)
        {
            try
            {  
                var results = await _evaluationService.GetResponse(id);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetResponse action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("QCId/{qcId}")]
        public async Task<IActionResult> WorkflowAssessmentCount(int qcId)
        {
            try
            {  
				var workflowAssessment = await _evaluationService.GetWorkflowAssessmentByQuestionCategoryId(qcId);
                return Ok(workflowAssessment.NumberOfAssessments);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside WorkflowAssessmentCount action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("fundingApplicationId/{fundingApplicationId}/questionId/{questionId}/createdUserId/{createdUserId}", Name = "GetCapturedResponseHistory")]
		public async Task<IActionResult> GetCapturedResponseHistory(int fundingApplicationId, int questionId, int createdUserId)
		{
			try
			{
				var results = await _evaluationService.GetCapturedResponseHistory(fundingApplicationId, questionId, createdUserId);
				return Ok(results);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside GetCapturedResponseHistory action: {ex.Message} Inner Exception: {ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}



		[HttpPut("response", Name = "UpdateResponse")]
		public async Task<IActionResult> UpdateResponse([FromBody] Response model)
		{
			try
			{
				var results = await this._evaluationService.UpdateResponse(model, base.GetUserIdentifier());
				return Ok(results);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside UpdateResponse action: {ex.Message} Inner Exception: {ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

        [HttpPut("scorecardResponse", Name = "UpdateScorecardResponse")]
        public async Task<IActionResult> UpdateScorecardResponse([FromBody] Response model)
        {
            try
            {
                var results = await this._evaluationService.UpdateScorecardResponse(model, base.GetUserIdentifier());
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateResponse action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("captured-response/fundingApplicationId/{fundingApplicationId}", Name = "GetCapturedResponses")]
		public async Task<IActionResult> GetCapturedResponses(int fundingApplicationId)
		{
			try
			{
				var results = await this._evaluationService.GetCapturedResponses(fundingApplicationId);
				return Ok(results);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside GetCapturedResponses action: {ex.Message} Inner Exception: {ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

        [HttpPost("captured-scorecardResponse", Name = "CreateScorecardResponse")]
        public async Task<IActionResult> CreateScorecardResponse([FromBody] CapturedResponse model)
        {
            try
            {
                await this._evaluationService.CreateCapturedResponse(model, base.GetUserIdentifier());
                var fundingApplication = await _applicationService.GetById(model.FundingApplicationId);
                await ConfigureEmail();
                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateCapturedResponse action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("captured-response", Name = "CreateCapturedResponse")]
		public async Task<IActionResult> CreateCapturedResponse([FromBody] CapturedResponse model)
		{
			try
			{
				await this._evaluationService.CreateCapturedResponse(model, base.GetUserIdentifier());
				await UpdateFundingApplicationStatus(model);
				return Ok(model);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside CreateCapturedResponse action: {ex.Message} Inner Exception: {ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		private async Task UpdateFundingApplicationStatus(CapturedResponse model)
		{
			var workflowAssessment = await _evaluationService.GetWorkflowAssessmentByQuestionCategoryId(model.QuestionCategoryId);

			var capturedResponses = await _evaluationService.GetCapturedResponsesByIds(model.FundingApplicationId, model.QuestionCategoryId);
			var numberOfCapturedResponses = capturedResponses.Select(x => x.CreatedUserId).Distinct();

			QuestionCategoryEnum questionCategoryId = (QuestionCategoryEnum)model.QuestionCategoryId;
            var categories = await _dropdownService.GetQuestionCategories(false);
			var cn = categories.Where(x => x.Id == Convert.ToInt32(questionCategoryId)).Select(x => x.Name).ToList(); // (x.   Distinct();
            var statusId = 0;
			var step = 0;

			switch (cn[0])
			{
				case "PreEvaluation":
					{
						step = 0;
						if (numberOfCapturedResponses.Count() >= workflowAssessment.NumberOfAssessments)
							statusId = (int)StatusEnum.Reviewed;
						else
							statusId = (int)StatusEnum.PendingReview;
						break;
					}
				case "Evaluation":
					{
						step = 1;
						if(model.selectedStatus == (int)StatusEnum.NonCompliance)
						{
                            statusId = (int)StatusEnum.NonCompliance;
                            break;
                        }

                        if (numberOfCapturedResponses.Count() >= workflowAssessment.NumberOfAssessments)
							statusId = (int)StatusEnum.Evaluated;
						else
							statusId = (int)StatusEnum.EvaluationInProgress;
						break;
					}
				case "Adjudication":
					{
						step = 2;

                        if (model.selectedStatus == (int)StatusEnum.NonCompliance)
                        {
                            statusId = (int)StatusEnum.NonCompliance;
                            break;
                        }

                        if (numberOfCapturedResponses.Count() >= workflowAssessment.NumberOfAssessments)
							statusId = (int)StatusEnum.Adjudicated;
						else
							statusId = (int)StatusEnum.AdjudicationInProgress;
						
						break;
					}
                case "Approval":
                    {
						step = 3;
						if (model.selectedStatus == (int)StatusEnum.Declined)
                        {
                            statusId = (int)StatusEnum.Declined;
							break;
                        }
                        if (numberOfCapturedResponses.Count() >= workflowAssessment.NumberOfAssessments)
                            statusId = (int)StatusEnum.Approved;
                        else
                            statusId = (int)StatusEnum.ApprovalInProgress;
                        break;
                    }
            }

			await _applicationService.UpdateFundingApplicationStatus(base.GetUserIdentifier(), model.FundingApplicationId, statusId, step);
			var fundingApplication = await _applicationService.GetById(model.FundingApplicationId);
			await ConfigureEmail(fundingApplication);
		}

        private async Task ConfigureEmail()
        {
            try
            {
                // Send email to Capturer
                var applicationAdjudicated = EmailTemplateFactory
                            .Create(EmailTemplateTypeEnum.StatusChanged)
                            .Get<StatusChangedEmailTemplate>();
                //.Init(fundingApplication);

                await applicationAdjudicated.SubmitToQueue();
                   
                await _emailService.SendEmailFromQueue();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside EvaluationController-ConfigureEmail action: {ex.Message} Inner Exception: {ex.InnerException}");
            }
        }
        private async Task ConfigureEmail(Application fundingApplication)
		{
			try
			{
				StatusEnum status = (StatusEnum)fundingApplication.StatusId;

				switch (status)
				{
					case StatusEnum.Reviewed:
						// Send email to Capturer
						var applicationPreEvaluated = EmailTemplateFactory
									.Create(EmailTemplateTypeEnum.StatusChanged)
									.Get<StatusChangedEmailTemplate>();
						//.Init(fundingApplication);

						// Send email to Evaluators
						var applicationPendingEvaluation = EmailTemplateFactory
									.Create(EmailTemplateTypeEnum.StatusChangedPending)
									.Get<StatusChangedPendingEmailTemplate>();
									//.Init(fundingApplication);

						await applicationPreEvaluated.SubmitToQueue();
						await applicationPendingEvaluation.SubmitToQueue();
						break;
					case StatusEnum.Evaluated:
						// Send email to Capturer
						var applicationEvaluated = EmailTemplateFactory
									.Create(EmailTemplateTypeEnum.StatusChanged)
									.Get<StatusChangedEmailTemplate>();
						//.Init(fundingApplication);

						// Send email to Adjudicators
						var applicationPendingAdjudication = EmailTemplateFactory
									.Create(EmailTemplateTypeEnum.StatusChangedPending)
									.Get<StatusChangedPendingEmailTemplate>();
									//.Init(fundingApplication);

						await applicationEvaluated.SubmitToQueue();
						await applicationPendingAdjudication.SubmitToQueue();
						break;
					case StatusEnum.Adjudicated:
						// Send email to Capturer
						var applicationAdjudicated = EmailTemplateFactory
									.Create(EmailTemplateTypeEnum.StatusChanged)
									.Get<StatusChangedEmailTemplate>();
									//.Init(fundingApplication);

						await applicationAdjudicated.SubmitToQueue();
						break;
                    case StatusEnum.Approved:
                        // Send email to Capturer
                        var applicationApproved = EmailTemplateFactory
                                    .Create(EmailTemplateTypeEnum.StatusChanged)
                                    .Get<StatusChangedEmailTemplate>();
						//.Init(fundingApplication);
						break;

                        await applicationAdjudicated.SubmitToQueue();
                        break;
                }

				await _emailService.SendEmailFromQueue();
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside EvaluationController-ConfigureEmail action: {ex.Message} Inner Exception: {ex.InnerException}");
			}
		}

		#endregion
	}
}
