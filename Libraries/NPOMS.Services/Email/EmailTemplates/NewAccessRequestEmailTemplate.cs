using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NPOMS.Domain.Core;
using NPOMS.Domain.Entities;
using NPOMS.Domain.Enumerations;
using NPOMS.Domain.Mapping;
using NPOMS.Repository.Interfaces.Entities;
using NPOMS.Repository.Interfaces.Mapping;
using NPOMS.Services.Infrastructure.Implementation;
using NPOMS.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace NPOMS.Services.Email.EmailTemplates
{
	public class NewAccessRequestEmailTemplate : IEmailTemplate
	{
		private UserNpo _userNpoMapping;

		public NewAccessRequestEmailTemplate Init(UserNpo userNpoMapping)
		{
			this._userNpoMapping = userNpoMapping;
			return this;
		}

		public async Task SubmitToQueue()
		{
			var emailQueueService = EngineContext.Current.Resolve<IEmailQueueService>();
			var emailTemplateService = EngineContext.Current.Resolve<IEmailTemplateService>();
			var logger = EngineContext.Current.Resolve<ILogger<NewAccessRequestEmailTemplate>>();
			var userNpoRepository = EngineContext.Current.Resolve<IUserNpoRepository>();
			var npoRepository = EngineContext.Current.Resolve<INpoRepository>();
			var httpContextAccessor = EngineContext.Current.Resolve<IHttpContextAccessor>();

			var emailTemplate = await emailTemplateService.GetByType(EmailTemplateTypeEnum.NewAccessRequest);
			var mapping = await userNpoRepository.GetById(this._userNpoMapping.Id);
			var npo = await npoRepository.GetById(mapping.NpoId);
			var requestOrigin = httpContextAccessor.HttpContext.Request.Headers["Origin"].ToString();

			try
			{
				EmailQueue emailQueue = new EmailQueue()
				{
					CreatedDateTime = DateTime.Now,
					EmailTemplateId = emailTemplate.Id,
					FromEmailAddress = emailTemplate.EmailAccount.FromEmail,
					FromEmailName = emailTemplate.EmailAccount.FromDisplayName,
					Message = ReplacePlaceholders(emailTemplate.Body, mapping, npo, requestOrigin),
					Subject = ReplacePlaceholders(emailTemplate.Subject, mapping, npo, requestOrigin),
					RecipientEmail = mapping.CreatedUser.Email,
					RecipientName = mapping.CreatedUser.FullName
				};

				await emailQueueService.Create(emailQueue);
			}
			catch (Exception ex)
			{
				logger.LogError($"Something went wrong inside NewAccessRequestEmailTemplate-SubmitToQueue action: {ex.Message} Inner Exception: { ex.InnerException}");
				throw;
			}
		}

		private string ReplacePlaceholders(string value, UserNpo mapping, Npo npo, string requestOrigin)
		{
			var returnResult = value.Replace("{ToUserFullName}", mapping.CreatedUser.FullName)
									.Replace("{NpoName}", npo.Name)
									.Replace("{url}", requestOrigin);

			return returnResult;
		}
	}
}
