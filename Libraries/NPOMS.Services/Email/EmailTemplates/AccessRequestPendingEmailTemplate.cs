using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NPOMS.Domain.Core;
using NPOMS.Domain.Entities;
using NPOMS.Domain.Enumerations;
using NPOMS.Domain.Mapping;
using NPOMS.Repository.Interfaces.Core;
using NPOMS.Repository.Interfaces.Entities;
using NPOMS.Repository.Interfaces.Mapping;
using NPOMS.Services.Infrastructure.Implementation;
using NPOMS.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace NPOMS.Services.Email.EmailTemplates
{
	public class AccessRequestPendingEmailTemplate : IEmailTemplate
	{
		private UserNpo _userNpoMapping;

		public AccessRequestPendingEmailTemplate Init(UserNpo userNpoMapping)
		{
			this._userNpoMapping = userNpoMapping;
			return this;
		}

		public async Task SubmitToQueue()
		{
			var emailQueueService = EngineContext.Current.Resolve<IEmailQueueService>();
			var emailTemplateService = EngineContext.Current.Resolve<IEmailTemplateService>();
			var logger = EngineContext.Current.Resolve<ILogger<AccessRequestPendingEmailTemplate>>();
			var userNpoRepository = EngineContext.Current.Resolve<IUserNpoRepository>();
			var npoRepository = EngineContext.Current.Resolve<INpoRepository>();
			var httpContextAccessor = EngineContext.Current.Resolve<IHttpContextAccessor>();
			var userRepository = EngineContext.Current.Resolve<IUserRepository>();

			var emailTemplate = await emailTemplateService.GetByType(EmailTemplateTypeEnum.AccessRequestPending);
			var mapping = await userNpoRepository.GetById(this._userNpoMapping.Id);
			var npo = await npoRepository.GetById(mapping.NpoId);
			var requestOrigin = httpContextAccessor.HttpContext.Request.Headers["Origin"].ToString();
			var adminUsers = await userRepository.GetByRoleId((int)RoleEnum.Admin);

			try
			{
				foreach (var user in adminUsers)
				{
					EmailQueue emailQueue = new EmailQueue()
					{
						CreatedDateTime = DateTime.Now,
						EmailTemplateId = emailTemplate.Id,
						FromEmailAddress = emailTemplate.EmailAccount.FromEmail,
						FromEmailName = emailTemplate.EmailAccount.FromDisplayName,
						Message = ReplacePlaceholders(emailTemplate.Body, mapping, npo, requestOrigin, user),
						Subject = ReplacePlaceholders(emailTemplate.Subject, mapping, npo, requestOrigin, user),
						RecipientEmail = user.Email,
						RecipientName = user.FullName
					};

					await emailQueueService.Create(emailQueue);
				}
			}
			catch (Exception ex)
			{
				logger.LogError($"Something went wrong inside AccessRequestPendingEmailTemplate-SubmitToQueue action: {ex.Message} Inner Exception: { ex.InnerException}");
				throw;
			}
		}

		private string ReplacePlaceholders(string value, UserNpo mapping, Npo npo, string requestOrigin, User user)
		{
			var returnResult = value.Replace("{ToUserFullName}", user.FullName)
									.Replace("{NpoName}", npo.Name)
									.Replace("{url}", requestOrigin)
									.Replace("{UserAccessFullName}", mapping.CreatedUser.FullName);

			return returnResult;
		}
	}
}
