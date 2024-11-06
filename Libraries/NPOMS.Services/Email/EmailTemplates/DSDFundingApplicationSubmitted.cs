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
using NPOMS.Domain.Entities;
using NPOMS.Repository.Interfaces.Entities;
using NPOMS.Repository.Implementation.Entities;
using System.Collections.Generic;

namespace NPOMS.Services.Email.EmailTemplates
{
    public class DSDFundingApplicationSubmitted : IEmailTemplate
    {
        private Application _application;
        public DSDFundingApplicationSubmitted Init(Application application)
        {
            this._application = application;
            return this;
        }
        public async Task SubmitToQueue()
        {
            var emailQueueService = EngineContext.Current.Resolve<IEmailQueueService>();
            var emailTemplateService = EngineContext.Current.Resolve<IEmailTemplateService>();
            var logger = EngineContext.Current.Resolve<ILogger<DSDFundingApplicationSubmitted>>();
            var applicationRepository = EngineContext.Current.Resolve<IApplicationRepository>();
            var httpContextAccessor = EngineContext.Current.Resolve<IHttpContextAccessor>();
            var npoRepository = EngineContext.Current.Resolve<INpoRepository>();
            var userRepository = EngineContext.Current.Resolve<IUserRepository>();
            var statusRepository = EngineContext.Current.Resolve<IStatusRepository>();

            var emailTemplate = await emailTemplateService.GetByType(EmailTemplateTypeEnum.DSDFundingApplicationSubmitted);
            var application = await applicationRepository.GetById(this._application.Id);
            var npo = await npoRepository.GetById(application.NpoId);
            var requestOrigin = httpContextAccessor.HttpContext.Request.Headers["Origin"].ToString();
            var status = await statusRepository.GetById(this._application.StatusId);

            var user =  await userRepository.GetActiveUserById(application.CreatedUserId);
            var fullName = user.FirstName + " " + user.LastName;
            try
            {
                var action = string.Empty;

                StatusEnum applicationStatus = (StatusEnum)this._application.StatusId;

                switch (applicationStatus)
                {
                    case StatusEnum.Submitted:
                        action = "has been submitted";
                        break;
                }

                EmailQueue emailQueue = new EmailQueue()
                {
                    CreatedDateTime = DateTime.Now,
                    EmailTemplateId = emailTemplate.Id,
                    FromEmailAddress = emailTemplate.EmailAccount.FromEmail,
                    FromEmailName = emailTemplate.EmailAccount.FromDisplayName,
                    Message = ReplacePlaceholders(emailTemplate.Body, npo, application, requestOrigin, status.Name),
                    Subject = ReplacePlaceholders(emailTemplate.Subject, npo, application, requestOrigin, status.Name),
                    RecipientEmail = user.Email,
                    RecipientName = fullName
                };

                await emailQueueService.Create(emailQueue);

            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside DSDFundingApplicationSubmitted: {ex.Message} Inner Exception: {ex.InnerException}");
                throw;
            }
        }

        private string ReplacePlaceholders(string value, Npo npo, Application application, string requestOrigin, string statusName)
        {

            var returnResult = value.Replace("{OrganizationName}", npo.Name)
                                    .Replace("{ApplicationRefNo}", application.RefNo);

            return returnResult;
        }
    }
}
