using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NPOMS.Domain.Core;
using NPOMS.Domain.Entities;
using NPOMS.Domain.Enumerations;
using NPOMS.Repository.Interfaces.Core;
using NPOMS.Repository.Interfaces.Entities;
using NPOMS.Services.Infrastructure.Implementation;
using NPOMS.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace NPOMS.Services.Email.EmailTemplates
{
	public class StatusChangedDeptCommentsEmailTemplate : IEmailTemplate
	{
		private Application _application;

		public StatusChangedDeptCommentsEmailTemplate Init(Application application)
		{
			this._application = application;
			return this;
		}

		public async Task SubmitToQueue()
		{
			var emailQueueService = EngineContext.Current.Resolve<IEmailQueueService>();
			var emailTemplateService = EngineContext.Current.Resolve<IEmailTemplateService>();
			var logger = EngineContext.Current.Resolve<ILogger<StatusChangedDeptCommentsEmailTemplate>>();
			var applicationRepository = EngineContext.Current.Resolve<IApplicationRepository>();
			var httpContextAccessor = EngineContext.Current.Resolve<IHttpContextAccessor>();
			var npoRepository = EngineContext.Current.Resolve<INpoRepository>();
			var userRepository = EngineContext.Current.Resolve<IUserRepository>();

			var emailTemplate = await emailTemplateService.GetByType(EmailTemplateTypeEnum.StatusChangedDeptComments);
			var application = await applicationRepository.GetById(this._application.Id);
			var npo = await npoRepository.GetById(application.NpoId);
			var requestOrigin = httpContextAccessor.HttpContext.Request.Headers["Origin"].ToString();
			var createdUser = await userRepository.GetActiveUserById(application.CreatedUserId);

			try
			{
				EmailQueue emailQueue = new EmailQueue()
				{
					CreatedDateTime = DateTime.Now,
					EmailTemplateId = emailTemplate.Id,
					FromEmailAddress = emailTemplate.EmailAccount.FromEmail,
					FromEmailName = emailTemplate.EmailAccount.FromDisplayName,
					Message = ReplacePlaceholders(emailTemplate.Body, application, requestOrigin, createdUser, npo),
					Subject = ReplacePlaceholders(emailTemplate.Subject, application, requestOrigin, createdUser, npo),
					RecipientEmail = createdUser.Email,
					RecipientName = createdUser.FullName
				};

				await emailQueueService.Create(emailQueue);
			}
			catch (Exception ex)
			{
				logger.LogError($"Something went wrong inside StatusChangedDeptCommentsEmailTemplate-SubmitToQueue action: {ex.Message} Inner Exception: { ex.InnerException}");
				throw;
			}
		}

		private string ReplacePlaceholders(string value, Application application, string requestOrigin, User user, Npo npo)
		{
			var returnResult = value.Replace("{ToUserFullName}", user.FullName)
									.Replace("{ApplicationRefNo}", application.RefNo)
									.Replace("{url}", requestOrigin)
									.Replace("{NPO}", npo.Name);

			return returnResult;
		}		
	}
}
