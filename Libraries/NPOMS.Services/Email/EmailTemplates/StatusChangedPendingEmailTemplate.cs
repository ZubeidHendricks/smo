using NPOMS.Domain.Core;
using NPOMS.Domain.Entities;
using NPOMS.Domain.Enumerations;
using NPOMS.Repository.Interfaces.Core;
using NPOMS.Repository.Interfaces.Entities;
using NPOMS.Services.Infrastructure.Implementation;
using NPOMS.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NPOMS.Services.Email.EmailTemplates
{
	public class StatusChangedPendingEmailTemplate : IEmailTemplate
	{
		private FundingApplication _fundingApplication;

		public StatusChangedPendingEmailTemplate Init(FundingApplication fundingApplication)
		{
			this._fundingApplication = fundingApplication;
			return this;
		}

		public async Task SubmitToQueue()
		{
			var emailQueueService = EngineContext.Current.Resolve<IEmailQueueService>();
			var emailTemplateService = EngineContext.Current.Resolve<IEmailTemplateService>();
			var logger = EngineContext.Current.Resolve<ILogger<StatusChangedApprovedEmailTemplate>>();
			var fundingApplicationRepository = EngineContext.Current.Resolve<IFundingApplicationRepository>();
			var httpContextAccessor = EngineContext.Current.Resolve<IHttpContextAccessor>();
			var userRepository = EngineContext.Current.Resolve<IUserRepository>();
			var statusRepository = EngineContext.Current.Resolve<IStatusRepository>();

			var emailTemplate = await emailTemplateService.GetByType(EmailTemplateTypeEnum.StatusChangedApproved);
			var application = await fundingApplicationRepository.GetFundingApplicationByIdAsync(this._fundingApplication.Id);
			var requestOrigin = httpContextAccessor.HttpContext.Request.Headers["Origin"].ToString();
			var status = await statusRepository.GetById(this._fundingApplication.StatusId);

			try
			{
				var users = Enumerable.Empty<User>();
				var action = string.Empty;

				StatusEnum applicationStatus = (StatusEnum)this._fundingApplication.StatusId;

				switch (applicationStatus)
				{
					case StatusEnum.Reviewed:
						action = "pre-evaluate";
						users = await userRepository.GetUsersByRoleId((int)RoleEnum.PreEvaluator);
						break;
					case StatusEnum.Evaluated:
						action = "evaluate";
						users = await userRepository.GetUsersByRoleId((int)RoleEnum.Evaluator);
						break;
					case StatusEnum.Adjudicated:
						action = "adjudicate";
						users = await userRepository.GetUsersByRoleId((int)RoleEnum.Adjudicator);
						break;
				}

				foreach (var user in users)
				{
					EmailQueue emailQueue = new EmailQueue()
					{
						CreatedDateTime = DateTime.Now,
						EmailTemplateId = emailTemplate.Id,
						FromEmailAddress = emailTemplate.EmailAccount.FromEmail,
						FromEmailName = emailTemplate.EmailAccount.FromDisplayName,
						Message = ReplacePlaceholders(emailTemplate.Body, application, user, requestOrigin, status.Name),
						Subject = ReplacePlaceholders(emailTemplate.Subject, application, user, requestOrigin, status.Name),
						RecipientEmail = user.Email,
						RecipientName = user.FirstName
					};

					await emailQueueService.CreateEmailQueue(emailQueue);
				}
			}
			catch (Exception ex)
			{
				logger.LogError($"Something went wrong inside StatusChangedPendingEmailTemplate-SubmitToQueue action: {ex.Message} Inner Exception: {ex.InnerException}");
				throw;
			}
		}

		private string ReplacePlaceholders(string value, FundingApplication fundingApplication, User user, string requestOrigin, string statusName)
		{

			var returnResult = value.Replace("{ToUserFullName}", user.FullName)
									.Replace("{FundingApplicationRefNo}", fundingApplication.RefNo)
									.Replace("{url}", requestOrigin)
									.Replace("{StatusName}", statusName);

			return returnResult;
		}
	}
}
