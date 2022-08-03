﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NPOMS.Domain.Entities;
using NPOMS.Domain.Enumerations;
using NPOMS.Services.Email;
using NPOMS.Services.Email.EmailTemplates;
using NPOMS.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace NPOMS.API.Controllers
{
	[Route("api/applications")]
	[ApiController]
	public class ApplicationController : ExternalBaseController
	{
		#region Fields

		private ILogger<ApplicationController> _logger;
		private IApplicationService _applicationService;
		private IEmailService _emailService;

		#endregion

		#region Constructors

		public ApplicationController(
			ILogger<ApplicationController> logger,
			IApplicationService applicationService,
			IEmailService emailService
			)
		{
			_logger = logger;
			_applicationService = applicationService;
			_emailService = emailService;
		}

		#endregion

		#region Methods

		[HttpGet(Name = "GetAllApplications")]
		public async Task<IActionResult> GetAllApplications()
		{
			try
			{
				var results = await _applicationService.GetAllApplicationsAsync(base.GetUserIdentifier());
				return Ok(results);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside GetAllApplications action: {ex.Message} Inner Exception: { ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpGet("applicationId/{applicationId}", Name = "GetApplicationById")]
		public async Task<IActionResult> GetApplicationById(int applicationId)
		{
			try
			{
				var results = await _applicationService.GetApplicationById(applicationId);
				return Ok(results);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside GetApplicationById action: {ex.Message} Inner Exception: { ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpGet("NpoId/{NpoId}/applicationPeriodId/{applicationPeriodId}", Name = "GetApplicationByNpoIdAndPeriodId")]
		public async Task<IActionResult> GetApplicationByNpoIdAndPeriodId(int NpoId, int applicationPeriodId)
		{
			try
			{
				var results = await _applicationService.GetApplicationByNpoIdAndPeriodId(NpoId, applicationPeriodId);
				return Ok(results);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside GetApplicationByNpoIdAndPeriodId action: {ex.Message} Inner Exception: { ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpPost(Name = "CreateApplication")]
		public async Task<IActionResult> CreateApplication([FromBody] Application model)
		{
			try
			{
				var application = await _applicationService.GetApplicationByNpoIdAndPeriodId(model.NpoId, model.ApplicationPeriodId);

				if (application == null)
				{
					await _applicationService.CreateApplication(model, base.GetUserIdentifier());

					var applicationAudit = new ApplicationAudit { ApplicationId = model.Id, StatusId = model.StatusId };
					await _applicationService.CreateApplicationAudit(applicationAudit, base.GetUserIdentifier());
				}

				var modelToReturn = application == null ? model : application;
				return Ok(modelToReturn);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside CreateApplication action: {ex.Message} Inner Exception: { ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpPut(Name = "UpdateApplication")]
		public async Task<IActionResult> UpdateApplication([FromBody] Application model)
		{
			try
			{
				await _applicationService.UpdateApplication(model, base.GetUserIdentifier());

				var applicationAudit = new ApplicationAudit { ApplicationId = model.Id, StatusId = model.StatusId };
				await _applicationService.CreateApplicationAudit(applicationAudit, base.GetUserIdentifier());

				await ConfigureEmail(model);
				return Ok(model);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside UpdateApplication action: {ex.Message} Inner Exception: { ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		private async Task ConfigureEmail(Application model)
		{
			try
			{
				StatusEnum status = (StatusEnum)model.StatusId;

				switch (status)
				{
					case StatusEnum.PendingReview:
						var newApplication = EmailTemplateFactory
								.Create(EmailTemplateTypeEnum.NewApplication)
								.Get<NewApplicationEmailTemplate>()
								.Init(model);

						var statusChangedPendingReview = EmailTemplateFactory
								.Create(EmailTemplateTypeEnum.StatusChangedPendingReview)
								.Get<StatusChangedPendingReviewEmailTemplate>()
								.Init(model);

						await newApplication.SubmitToQueue();
						await statusChangedPendingReview.SubmitToQueue();
						break;
					case StatusEnum.AmendmentsRequired:
						var statusChangedAmendmentsRequired = EmailTemplateFactory
								.Create(EmailTemplateTypeEnum.StatusChangedAmendmentsRequired)
								.Get<StatusChangedAmendmentsRequiredEmailTemplate>()
								.Init(model);

						await statusChangedAmendmentsRequired.SubmitToQueue();
						break;
					case StatusEnum.PendingApproval:
						var statusChangedApproved = EmailTemplateFactory
								.Create(EmailTemplateTypeEnum.StatusChangedPendingApproval)
								.Get<StatusChangedPendingApprovalEmailTemplate>()
								.Init(model);

						await statusChangedApproved.SubmitToQueue();
						break;
					case StatusEnum.Rejected:
						var statusChangedRejected = EmailTemplateFactory
								.Create(EmailTemplateTypeEnum.StatusChangedRejected)
								.Get<StatusChangedRejectedEmailTemplate>()
								.Init(model);

						await statusChangedRejected.SubmitToQueue();
						break;
					case StatusEnum.PendingSLA:
						var statusChangesPendingSLA = EmailTemplateFactory
								.Create(EmailTemplateTypeEnum.StatusChangedPendingSLA)
								.Get<StatusChangedPendingSLAEmailTemplate>()
								.Init(model);

						await statusChangesPendingSLA.SubmitToQueue();
						break;
					case StatusEnum.PendingSignedSLA:
						var statusChangesPendingSignedSLA = EmailTemplateFactory
								.Create(EmailTemplateTypeEnum.StatusChangedPendingSignedSLA)
								.Get<StatusChangedPendingSignedSLAEmailTemplate>()
								.Init(model);

						await statusChangesPendingSignedSLA.SubmitToQueue();
						break;
					case StatusEnum.AcceptedSLA:
						var statusChangesAcceptedSLA = EmailTemplateFactory
								.Create(EmailTemplateTypeEnum.StatusChangedAcceptedSLA)
								.Get<StatusChangedAcceptedSLAEmailTemplate>()
								.Init(model);

						await statusChangesAcceptedSLA.SubmitToQueue();
						break;
					case StatusEnum.DeptComments:
						var statusChangedDeptReviewComments = EmailTemplateFactory
								.Create(EmailTemplateTypeEnum.StatusChangedDeptComments)
								.Get<StatusChangedDeptCommentsEmailTemplate>()
								.Init(model);

						await statusChangedDeptReviewComments.SubmitToQueue();
						break;
					case StatusEnum.OrgComments:
						var statusChangedOrgReviewComments = EmailTemplateFactory
								.Create(EmailTemplateTypeEnum.StatusChangedOrgComments)
								.Get<StatusChangedOrgCommentsEmailTemplate>()
								.Init(model);

						await statusChangedOrgReviewComments.SubmitToQueue();
						break;
				}

				await _emailService.SendEmailFromQueue();
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside ApplicationConfigureEmail action: {ex.Message} Inner Exception: { ex.InnerException}");
			}
		}

		[HttpGet("objectives/NpoId/{NpoId}/applicationPeriodId/{applicationPeriodId}", Name = "GetAllObjectives")]
		public async Task<IActionResult> GetAllObjectives(int NpoId, int applicationPeriodId)
		{
			try
			{
				var results = await _applicationService.GetAllObjectivesAsync(NpoId, applicationPeriodId);
				return Ok(results);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside GetAllObjectives action: {ex.Message} Inner Exception: { ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpPost("objectives/NpoId/{NpoId}/applicationPeriodId/{applicationPeriodId}", Name = "CreateObjective")]
		public async Task<IActionResult> CreateObjective([FromBody] Objective model, int NpoId, int applicationPeriodId)
		{
			try
			{
				var application = await _applicationService.GetApplicationByNpoIdAndPeriodId(NpoId, applicationPeriodId);
				model.ApplicationId = application.Id;

				await _applicationService.CreateObjective(model, base.GetUserIdentifier());
				return Ok();
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside CreateObjective action: {ex.Message} Inner Exception: { ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpPut("objectives", Name = "UpdateObjective")]
		public async Task<IActionResult> UpdateObjective([FromBody] Objective model)
		{
			try
			{
				await _applicationService.UpdateObjective(model, base.GetUserIdentifier());
				return Ok();
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside UpdateObjective action: {ex.Message} Inner Exception: { ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpGet("activities/NpoId/{NpoId}/applicationPeriodId/{applicationPeriodId}", Name = "GetAllActivities")]
		public async Task<IActionResult> GetAllActivities(int NpoId, int applicationPeriodId)
		{
			try
			{
				var results = await _applicationService.GetAllActivitiesAsync(NpoId, applicationPeriodId);
				return Ok(results);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside GetAllActivities action: {ex.Message} Inner Exception: { ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpPost("activities/NpoId/{NpoId}/applicationPeriodId/{applicationPeriodId}", Name = "CreateActivity")]
		public async Task<IActionResult> CreateActivity([FromBody] Activity model, int NpoId, int applicationPeriodId)
		{
			try
			{
				var application = await _applicationService.GetApplicationByNpoIdAndPeriodId(NpoId, applicationPeriodId);
				model.ApplicationId = application.Id;

				await _applicationService.CreateActivity(model, base.GetUserIdentifier());
				return Ok();
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside CreateActivity action: {ex.Message} Inner Exception: { ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpPut("activities", Name = "UpdateActivity")]
		public async Task<IActionResult> UpdateActivity([FromBody] Activity model)
		{
			try
			{
				await _applicationService.UpdateActivity(model, base.GetUserIdentifier());
				return Ok();
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside UpdateActivity action: {ex.Message} Inner Exception: { ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpGet("resources/NpoId/{NpoId}/applicationPeriodId/{applicationPeriodId}", Name = "GetAllResources")]
		public async Task<IActionResult> GetAllResources(int NpoId, int applicationPeriodId)
		{
			try
			{
				var results = await _applicationService.GetAllResourcesAsync(NpoId, applicationPeriodId);
				return Ok(results);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside GetAllResources action: {ex.Message} Inner Exception: { ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpPost("resources/NpoId/{NpoId}/applicationPeriodId/{applicationPeriodId}", Name = "CreateResource")]
		public async Task<IActionResult> CreateResource([FromBody] Resource model, int NpoId, int applicationPeriodId)
		{
			try
			{
				var application = await _applicationService.GetApplicationByNpoIdAndPeriodId(NpoId, applicationPeriodId);
				model.ApplicationId = application.Id;

				await _applicationService.CreateResource(model, base.GetUserIdentifier());
				return Ok();
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside CreateResource action: {ex.Message} Inner Exception: { ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpPut("resources", Name = "UpdateResource")]
		public async Task<IActionResult> UpdateResource([FromBody] Resource model)
		{
			try
			{
				await _applicationService.UpdateResource(model, base.GetUserIdentifier());
				return Ok();
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside UpdateResource action: {ex.Message} Inner Exception: { ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpGet("sustainability-plans/NpoId/{NpoId}/applicationPeriodId/{applicationPeriodId}", Name = "GetAllSustainabilityPlans")]
		public async Task<IActionResult> GetAllSustainabilityPlans(int NpoId, int applicationPeriodId)
		{
			try
			{
				var results = await _applicationService.GetAllSustainabilityPlansAsync(NpoId, applicationPeriodId);
				return Ok(results);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside GetAllSustainabilityPlans action: {ex.Message} Inner Exception: { ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpPost("sustainability-plans/NpoId/{NpoId}/applicationPeriodId/{applicationPeriodId}", Name = "CreateSustainabilityPlan")]
		public async Task<IActionResult> CreateSustainabilityPlan([FromBody] SustainabilityPlan model, int NpoId, int applicationPeriodId)
		{
			try
			{
				var application = await _applicationService.GetApplicationByNpoIdAndPeriodId(NpoId, applicationPeriodId);
				model.ApplicationId = application.Id;

				await _applicationService.CreateSustainabilityPlan(model, base.GetUserIdentifier());
				return Ok();
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside CreateSustainabilityPlan action: {ex.Message} Inner Exception: { ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpPut("sustainability-plans", Name = "UpdateSustainabilityPlan")]
		public async Task<IActionResult> UpdateSustainabilityPlan([FromBody] SustainabilityPlan model)
		{
			try
			{
				await _applicationService.UpdateSustainabilityPlan(model, base.GetUserIdentifier());
				return Ok();
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside UpdateSustainabilityPlan action: {ex.Message} Inner Exception: { ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpGet("facilities/NpoId/{NpoId}", Name = "GetAssignedFacilities")]
		public async Task<IActionResult> GetAssignedFacilities(int NpoId)
		{
			try
			{
				var results = await _applicationService.GetAssignedFacilitiesByNpoId(NpoId);
				return Ok(results);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside GetAssignedFacilities action: {ex.Message} Inner Exception: { ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpGet("application-comments/applicationId/{applicationId}", Name = "GetAllApplicationComments")]
		public async Task<IActionResult> GetAllApplicationComments(int applicationId)
		{
			try
			{
				var results = await _applicationService.GetAllApplicationComments(applicationId);
				return Ok(results);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside GetAllApplicationComments action: {ex.Message} Inner Exception: { ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpGet("application-comments/applicationId/{applicationId}/serviceProvisionStepId/{serviceProvisionStepId}/entityId/{entityId}", Name = "GetApplicationComments")]
		public async Task<IActionResult> GetApplicationComments(int applicationId, int serviceProvisionStepId, int entityId)
		{
			try
			{
				var results = await _applicationService.GetApplicationComments(applicationId, serviceProvisionStepId, entityId);
				return Ok(results);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside GetApplicationComments action: {ex.Message} Inner Exception: { ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpPost("application-comments/changesRequired/{changesRequired}", Name = "CreateApplicationComment")]
		public async Task<IActionResult> CreateApplicationComment([FromBody] ApplicationComment model, bool changesRequired)
		{
			try
			{
				await _applicationService.CreateApplicationComment(model, base.GetUserIdentifier());

				if (changesRequired)
					await _applicationService.UpdateChangesRequired(model, changesRequired);

				return Ok();
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside CreateApplicationComment action: {ex.Message} Inner Exception: { ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpGet("application-audits/applicationId/{applicationId}", Name = "GetApplicationAudits")]
		public async Task<IActionResult> GetApplicationAudits(int applicationId)
		{
			try
			{
				var results = await _applicationService.GetApplicationAudits(applicationId);
				return Ok(results);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside GetApplicationAudits action: {ex.Message} Inner Exception: { ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpGet("approval/applicationId/{applicationId}", Name = "GetApplicationApprovals")]
		public async Task<IActionResult> GetApplicationApprovals(int applicationId)
		{
			try
			{
				var results = await _applicationService.GetApplicationApprovals(applicationId);
				return Ok(results);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside GetApplicationApprovals action: {ex.Message} Inner Exception: { ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpPost("approval", Name = "CreateApplicationApproval")]
		public async Task<IActionResult> CreateApplicationApproval([FromBody] ApplicationApproval model)
		{
			try
			{
				await _applicationService.CreateApplicationApproval(model, base.GetUserIdentifier());
				var results = await _applicationService.GetApplicationApprovals(model.ApplicationId);
				return Ok(results);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside CreateApplicationApproval action: {ex.Message} Inner Exception: { ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpPut("approval", Name = "UpdateApplicationApproval")]
		public async Task<IActionResult> UpdateApplicationApproval([FromBody] ApplicationApproval model)
		{
			try
			{
				var results = await _applicationService.GetApplicationApprovals(model.ApplicationId);

				foreach (var item in results)
				{
					await _applicationService.UpdateApplicationApproval(item, base.GetUserIdentifier());
				}

				return Ok();
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside UpdateApplicationApproval action: {ex.Message} Inner Exception: { ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		#endregion
	}
}
