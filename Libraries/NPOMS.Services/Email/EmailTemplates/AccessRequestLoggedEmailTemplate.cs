using NPOMS.Domain.Core;
using NPOMS.Domain.Enumerations;
using NPOMS.Repository.Interfaces.Core;
using NPOMS.Services.Infrastructure.Implementation;
using NPOMS.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NPOMS.Services.Email.EmailTemplates
{
	public class AccessRequestLoggedEmailTemplate : IEmailTemplate
    {
        private User _user;

        public AccessRequestLoggedEmailTemplate Init(User user)
        {
            this._user = user;
            return this;
        }

        public async Task SubmitToQueue()
        {
            var emailQueueService = EngineContext.Current.Resolve<IEmailQueueService>();
            var emailTemplateService = EngineContext.Current.Resolve<IEmailTemplateService>();
            var logger = EngineContext.Current.Resolve<ILogger<AccessRequestLoggedEmailTemplate>>();
            var userRepository = EngineContext.Current.Resolve<IUserRepository>();
            var httpContextAccessor = EngineContext.Current.Resolve<IHttpContextAccessor>();

            var emailTemplate = await emailTemplateService.GetByType(EmailTemplateTypeEnum.AccessRequestLogged);
            var user = await userRepository.GetUserByIdAsync(this._user.Id);
            var requestOrigin = httpContextAccessor.HttpContext.Request.Headers["Origin"].ToString();

            try
            {
                /*var allUsers = await userRepository.GetAllUsersAsync();
                var dedatReps = allUsers.Where(x => x.Roles.Any(y => y.RoleId == (int)RoleEnum.DEDATRep));

                foreach (var dedatRep in dedatReps)
                {
                    EmailQueue emailQueue = new EmailQueue()
                    {
                        CreatedDateTime = DateTime.Now,
                        EmailTemplateId = emailTemplate.Id,
                        FromEmailAddress = emailTemplate.EmailAccount.FromEmail,
                        FromEmailName = emailTemplate.EmailAccount.FromDisplayName,
                        Message = ReplacePlaceholders(emailTemplate.Body, user, dedatRep, requestOrigin),
                        Subject = ReplacePlaceholders(emailTemplate.Subject, user, dedatRep, requestOrigin),
                        RecipientEmail = dedatRep.Email,
                        RecipientName = dedatRep.FirstName
                    };

                    await emailQueueService.CreateEmailQueue(emailQueue);
                }*/
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside AccessRequestLoggedEmailTemplate-SubmitToQueue action: {ex.Message} Inner Exception: {ex.InnerException}");
                throw;
            }
        }

        private string ReplacePlaceholders(string value, User user, User dedatRep, string requestOrigin)
        {

            var returnResult = value.Replace("{ToUserFullName}", dedatRep.FullName)
                                    .Replace("{ExternalUserName}", user.FullName)
                                    .Replace("{url}", requestOrigin);

            return returnResult;
        }
    }
}