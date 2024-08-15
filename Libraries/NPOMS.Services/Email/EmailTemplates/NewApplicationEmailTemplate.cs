using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NPOMS.Domain.Core;
using NPOMS.Domain.Entities;
using NPOMS.Domain.Enumerations;
using NPOMS.Repository.Implementation.Core;
using NPOMS.Repository.Interfaces.Core;
using NPOMS.Repository.Interfaces.Entities;
using NPOMS.Services.Infrastructure.Implementation;
using NPOMS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var userContactPrimary = npo.ContactInformation.Where(n => n.IsPrimaryContact == true).FirstOrDefault();
            var createdUser = await userRepository.GetActiveUserById(application.CreatedUserId);

            var users = new List<User>();

            users.Add(await userRepository.GetActiveUserById(application.CreatedUserId));

            var mainReveiwers = await userRepository.GetByIds((int)RoleEnum.MainReviewer, application.ApplicationPeriod.DepartmentId);

            users.AddRange(mainReveiwers);

            try
            {
                foreach (var user in users)
                {
                    EmailQueue emailQueue = new EmailQueue()
                    {
                        CreatedDateTime = DateTime.Now,
                        EmailTemplateId = emailTemplate.Id,
                        FromEmailAddress = emailTemplate.EmailAccount.FromEmail,
                        FromEmailName = emailTemplate.EmailAccount.FromDisplayName
                    };

                    emailQueue.Message = ReplacePlaceholders(emailTemplate.Body, application, requestOrigin, user, npo);
                    emailQueue.Subject = ReplacePlaceholders(emailTemplate.Subject, application, requestOrigin, user, npo);
                    emailQueue.RecipientEmail = user.Email;
                    emailQueue.RecipientName = user.FullName;

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
