using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NPOMS.Domain.Enumerations;
using NPOMS.Domain.Indicator;
using NPOMS.Services.Email;
using NPOMS.Services.Email.EmailTemplates;
using NPOMS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPOMS.API.Controllers
{
	[Route("api/indicators")]
	[ApiController]
	public class IndicatorController : ExternalBaseController
	{
		#region Fields

		private ILogger<IndicatorController> _logger;
		private IIndicatorService _indicatorService;
		private IDropdownService _dropdownService;
		private IApplicationService _applicationService;
		private IEmailService _emailService;

		#endregion

		#region Constructors

		public IndicatorController(
			ILogger<IndicatorController> logger,
			IIndicatorService indicatorService,
			IDropdownService dropdownService,
			IApplicationService applicationService,
			IEmailService emailService)
		{
			_logger = logger;
			_indicatorService = indicatorService;
			_dropdownService = dropdownService;
			_applicationService = applicationService;
			_emailService = emailService;
		}

		#endregion

		#region Methods

		[HttpGet("workplan-target/activityId/{activityId}", Name = "GetTargetsByActivityId")]
		public async Task<IActionResult> GetTargetsByActivityId(int activityId)
		{
			try
			{
				var results = await _indicatorService.GetTargetsByActivityId(activityId);
				return Ok(results);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside GetTargetsByActivityId action: {ex.Message} Inner Exception: {ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

        [HttpPost("workplan-target/targetactivityIds", Name = "GetTargetsByActivityIds")]
        public async Task<IActionResult> GetTargetsByActivityIds([FromBody] List<int> activityIds)
        {
            try
            {
                // Ensure activityIds is not null or empty
                if (activityIds == null || !activityIds.Any())
                {
                    return BadRequest("Activity IDs cannot be null or empty.");
                }

                var results = await _indicatorService.GetTargetsByActivityIds(activityIds);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetTargetsByActivityIds action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("workplan-actual/actualactivityIds", Name = "GetActualsByActivityIds")]
        public async Task<IActionResult> GetActualsByActivityIds([FromBody] List<int> activityIds)
        {
            try
            {
                // Ensure activityIds is not null or empty
                if (activityIds == null || !activityIds.Any())
                {
                    return BadRequest("Activity IDs cannot be null or empty.");
                }

                var results = await _indicatorService.GetActualsByActivityIds(activityIds);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetActualsByActivityIds action: {ex.Message} Inner Exception: {ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpPost("workplan-target", Name = "ManageTarget")]
		public async Task<IActionResult> ManageTarget([FromBody] WorkplanTarget model)
		{
			try
			{
				var target = await _indicatorService.GetTargetByIds(model);

				if (target == null)
					await _indicatorService.CreateTarget(model, base.GetUserIdentifier());
				else
					await _indicatorService.UpdateTarget(model, base.GetUserIdentifier());

				await CreateWorkplanActual(model);
				return Ok();
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside ManageTarget action: {ex.Message} Inner Exception: {ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		/// <summary>
		/// Create Workplan Actual placeholders based on the captured workplan targets
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		private async Task CreateWorkplanActual(WorkplanTarget model)
		{
			// Only return active frequency periods by frequency Id
			var frequencyPeriods = await _dropdownService.GetFrequencyPeriodsByFrequencyId(model.FrequencyId);

			foreach (var period in frequencyPeriods)
			{
				var workplanActual = new WorkplanActual
				{
					ActivityId = model.ActivityId,
					FinancialYearId = model.FinancialYearId,
					FrequencyPeriodId = period.Id,
					StatusId = (int)StatusEnum.New,
					WorkplanTargetId = model.Id
				};

				var workplanActualExists = await _indicatorService.GetActualsByIds(workplanActual);

				if (workplanActualExists == null)
				{
					await _indicatorService.CreateActual(workplanActual, base.GetUserIdentifier());
					await CreateWorkplanActualAudit(workplanActual);
				}
			}
		}

		[HttpGet("workplan-actual/activityId/{activityId}", Name = "GetActualsByActivityId")]
		public async Task<IActionResult> GetActualsByActivityId(int activityId)
		{
			try
			{
				var results = await _indicatorService.GetActualsByActivityId(activityId);
				return Ok(results);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside GetActualsByActivityId action: {ex.Message} Inner Exception: {ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpPut("workplan-actual", Name = "UpdateActual")]
		public async Task<IActionResult> UpdateActual([FromBody] WorkplanActual model)
		{
			try
			{
				await _indicatorService.UpdateActual(model, base.GetUserIdentifier());
				await CreateWorkplanActualAudit(model);
				//await ConfigureEmail(model);

				return Ok(model);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside UpdateActual action: {ex.Message} Inner Exception: {ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		private async Task ConfigureEmail(WorkplanActual model)
		{
			try
			{
				var activity = await _applicationService.GetActivityById(model.ActivityId);
				var application = await _applicationService.GetApplicationById(activity.ApplicationId);
				var activities = await _applicationService.GetAllActivitiesAsync(application.NpoId, application.ApplicationPeriodId);
				var activityIds = activities.Select(x => x.Id).ToList();
				var workplanActuals = await _indicatorService.GetWorkplanActualsByIds(activityIds, model.FinancialYearId, model.FrequencyPeriodId);

				StatusEnum status = (StatusEnum)model.StatusId;

				switch (status)
				{
					case StatusEnum.PendingReview:
						
						if (!workplanActuals.Any(x => x.StatusId == (int)StatusEnum.New ||
												 x.StatusId == (int)StatusEnum.Saved ||
												 x.StatusId == (int)StatusEnum.AmendmentsRequired))
						{
							var statusChangedSubmitted = EmailTemplateFactory
								.Create(EmailTemplateTypeEnum.WorkplanActualStatusChanged)
								.Get<WorkplanActualStatusChangedEmailTemplate>()
								.Init(model, application);

							var workplanActualPendingReview = EmailTemplateFactory
								.Create(EmailTemplateTypeEnum.WorkplanActualPendingReview)
								.Get<WorkplanActualPendingReviewEmailTemplate>()
								.Init(model, application);

							await statusChangedSubmitted.SubmitToQueue();
							await workplanActualPendingReview.SubmitToQueue();
						}

						break;
					case StatusEnum.PendingApproval:

						if (!workplanActuals.Any(x => x.StatusId == (int)StatusEnum.New ||
												 x.StatusId == (int)StatusEnum.Saved ||
												 x.StatusId == (int)StatusEnum.AmendmentsRequired ||
												 x.StatusId == (int)StatusEnum.PendingReview))
						{
							var statusChangedReviewed = EmailTemplateFactory
								.Create(EmailTemplateTypeEnum.WorkplanActualStatusChanged)
								.Get<WorkplanActualStatusChangedEmailTemplate>()
								.Init(model, application);

							var workplanActualPendingApproval = EmailTemplateFactory
								.Create(EmailTemplateTypeEnum.WorkplanActualPendingApproval)
								.Get<WorkplanActualPendingApprovalEmailTemplate>()
								.Init(model, application);

							await statusChangedReviewed.SubmitToQueue();
							await workplanActualPendingApproval.SubmitToQueue();
						}

							break;
					case StatusEnum.Approved:

						if (!workplanActuals.Any(x => x.StatusId != (int)StatusEnum.Approved))
						{
							var statusChangedApproved = EmailTemplateFactory
								.Create(EmailTemplateTypeEnum.WorkplanActualStatusChanged)
								.Get<WorkplanActualStatusChangedEmailTemplate>()
								.Init(model, application);

							await statusChangedApproved.SubmitToQueue();
						}

						break;
					case StatusEnum.AmendmentsRequired:
						
						var statusChangedAmendmentsRequired = EmailTemplateFactory
								.Create(EmailTemplateTypeEnum.WorkplanActualStatusChanged)
								.Get<WorkplanActualStatusChangedEmailTemplate>()
								.Init(model, application);

						await statusChangedAmendmentsRequired.SubmitToQueue();
						break;
				}

				await _emailService.SendEmailFromQueue();
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside IndicatorConfigureEmail action: {ex.Message} Inner Exception: {ex.InnerException}");
			}
		}

		private async Task CreateWorkplanActualAudit(WorkplanActual model)
		{
			try
			{
				var workplanActualAudit = new WorkplanActualAudit { WorkplanActualId = model.Id, StatusId = model.StatusId };
				await _indicatorService.CreateWorkplanActualAudit(workplanActualAudit, base.GetUserIdentifier());
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside CreateWorkplanActualAudit action: {ex.Message} Inner Exception: {ex.InnerException}");
			}
		}

		[HttpGet("workplan-actual-audits/workplanActualId/{workplanActualId}", Name = "GetWorkplanActualAudits")]
		public async Task<IActionResult> GetWorkplanActualAudits(int workplanActualId)
		{
			try
			{
				var results = await _indicatorService.GetWorkplanActualAudits(workplanActualId);
				return Ok(results);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside GetWorkplanActualAudits action: {ex.Message} Inner Exception: {ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpGet("workplan-comments/workplanActualId/{workplanActualId}", Name = "GetWorkplanComments")]
		public async Task<IActionResult> GetWorkplanComments(int workplanActualId)
		{
			try
			{
				var results = await _indicatorService.GetWorkplanComments(workplanActualId);
				return Ok(results);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside GetWorkplanActualComments action: {ex.Message} Inner Exception: {ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		[HttpPost("workplan-comments", Name = "CreateWorkplanComment")]
		public async Task<IActionResult> CreateWorkplanComment([FromBody] WorkplanComment model)
		{
			try
			{
				await _indicatorService.CreateWorkplanComment(model, base.GetUserIdentifier());
				return Ok();
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside CreateWorkplanComment action: {ex.Message} Inner Exception: {ex.InnerException}");
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}

		#endregion
	}
}
