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
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Services.Email.EmailTemplates
{
	public class NewApplicationEmailTemplate : IEmailTemplate
	{
		private Application _application;

		public NewApplicationEmailTemplate Init(Application application)
		{
			this._application = application;
			return this;
		}

		public async Task SubmitToQueue()
		{
			var emailQueueService = EngineContext.Current.Resolve<IEmailQueueService>();
			var emailTemplateService = EngineContext.Current.Resolve<IEmailTemplateService>();
			var logger = EngineContext.Current.Resolve<ILogger<NewApplicationEmailTemplate>>();
			var applicationRepository = EngineContext.Current.Resolve<IApplicationRepository>();
			var httpContextAccessor = EngineContext.Current.Resolve<IHttpContextAccessor>();
			var npoRepository = EngineContext.Current.Resolve<INpoRepository>();
			var userRepository = EngineContext.Current.Resolve<IUserRepository>();

			var emailTemplate = await emailTemplateService.GetByType(EmailTemplateTypeEnum.NewApplication);
			var application = await applicationRepository.GetById(this._application.Id);
			var npo = await npoRepository.GetById(application.NpoId);
			var requestOrigin = httpContextAccessor.HttpContext.Request.Headers["Origin"].ToString();

			var users = new List<User>();
			users.Add(await userRepository.GetById(application.CreatedUserId));

			if (application.UpdatedUserId != null && application.CreatedUserId != application.UpdatedUserId)
				users.Add(await userRepository.GetById(Convert.ToInt32(application.UpdatedUserId)));

			try
			{
				foreach (var user in users)
				{
					EmailQueue emailQueue = new EmailQueue()
					{
						CreatedDateTime = DateTime.Now,
						EmailTemplateId = emailTemplate.Id,
						FromEmailAddress = emailTemplate.EmailAccount.FromEmail,
						FromEmailName = emailTemplate.EmailAccount.FromDisplayName,
						Message = ReplacePlaceholders(emailTemplate.Body, application, requestOrigin, user, npo),
						Subject = ReplacePlaceholders(emailTemplate.Subject, application, requestOrigin, user, npo),
						RecipientEmail = user.Email,
						RecipientName = user.FullName
					};

					await emailQueueService.Create(emailQueue);
				}
			}
			catch (Exception ex)
			{
				logger.LogError($"Something went wrong inside NewApplicationEmailTemplate-SubmitToQueue action: {ex.Message} Inner Exception: { ex.InnerException}");
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
