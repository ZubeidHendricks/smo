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

namespace NPOMS.API.Controllers
{
	[Route("api/evaluation")]
	[ApiController]
	public class EvaluationController : ExternalBaseController
	{
		#region Fields

		private ILogger<EvaluationController> _logger;
		private IEvaluationService _evaluationService;
		private IFundingApplicationService _fundingApplicationService;
		private IEmailService _emailService;

		#endregion

		#region Constructors

		public EvaluationController(
			ILogger<EvaluationController> logger,
			IEvaluationService evaluationService,
			IFundingApplicationService fundingApplicationService,
			IEmailService emailService)
		{
			_logger = logger;
			_evaluationService = evaluationService;
			_fundingApplicationService = fundingApplicationService;
			_emailService = emailService;
		}

		#endregion

		#region Methods

		[HttpGet("fundingApplicationId/{fundingApplicationId}", Name = "GetQuestionnaire")]
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
			var statusId = 0;

			switch (questionCategoryId)
			{
				case QuestionCategoryEnum.PreEvaluation:
					{
						if (numberOfCapturedResponses.Count() >= workflowAssessment.NumberOfAssessments)
							statusId = (int)StatusEnum.PreEvaluated;
						else
							statusId = (int)StatusEnum.PreEvaluationInProgress;
						break;
					}
				case QuestionCategoryEnum.Evaluation:
					{
						if (numberOfCapturedResponses.Count() >= workflowAssessment.NumberOfAssessments)
							statusId = (int)StatusEnum.Evaluated;
						else
							statusId = (int)StatusEnum.EvaluationInProgress;
						break;
					}
				case QuestionCategoryEnum.Adjudication:
					{
						if (numberOfCapturedResponses.Count() >= workflowAssessment.NumberOfAssessments)
							statusId = (int)StatusEnum.Adjudicated;
						else
							statusId = (int)StatusEnum.AdjudicationInProgress;
						break;
					}
			}

			await _fundingApplicationService.UpdateFundingApplicationStatus(base.GetUserIdentifier(), model.FundingApplicationId, statusId);
			var fundingApplication = await _fundingApplicationService.GetFundingApplicationById(model.FundingApplicationId, false);
			await ConfigureEmail(fundingApplication);
		}

		private async Task ConfigureEmail(FundingApplication fundingApplication)
		{
			try
			{
				StatusEnum status = (StatusEnum)fundingApplication.StatusId;

				switch (status)
				{
					case StatusEnum.PreEvaluated:
						// Send email to Capturer
						var applicationPreEvaluated = EmailTemplateFactory
									.Create(EmailTemplateTypeEnum.StatusChanged)
									.Get<StatusChangedEmailTemplate>()
									.Init(fundingApplication);

						// Send email to Evaluators
						var applicationPendingEvaluation = EmailTemplateFactory
									.Create(EmailTemplateTypeEnum.StatusChangedPending)
									.Get<StatusChangedPendingEmailTemplate>()
									.Init(fundingApplication);

						await applicationPreEvaluated.SubmitToQueue();
						await applicationPendingEvaluation.SubmitToQueue();
						break;
					case StatusEnum.Evaluated:
						// Send email to Capturer
						var applicationEvaluated = EmailTemplateFactory
									.Create(EmailTemplateTypeEnum.StatusChanged)
									.Get<StatusChangedEmailTemplate>()
									.Init(fundingApplication);

						// Send email to Adjudicators
						var applicationPendingAdjudication = EmailTemplateFactory
									.Create(EmailTemplateTypeEnum.StatusChangedPending)
									.Get<StatusChangedPendingEmailTemplate>()
									.Init(fundingApplication);

						await applicationEvaluated.SubmitToQueue();
						await applicationPendingAdjudication.SubmitToQueue();
						break;
					case StatusEnum.Adjudicated:
						// Send email to Capturer
						var applicationAdjudicated = EmailTemplateFactory
									.Create(EmailTemplateTypeEnum.StatusChanged)
									.Get<StatusChangedEmailTemplate>()
									.Init(fundingApplication);

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
