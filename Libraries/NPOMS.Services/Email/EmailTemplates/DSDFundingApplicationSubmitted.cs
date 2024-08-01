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

namespace NPOMS.Services.Email.EmailTemplates
{
    public class DSDFundingApplicationSubmitted : IEmailTemplate
    {
        private FundingApplication _fundingApplication;
        public DSDFundingApplicationSubmitted Init(FundingApplication fundingApplication)
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
            var statusRepository = EngineContext.Current.Resolve<IStatusRepository>();

            var emailTemplate = await emailTemplateService.GetByType(EmailTemplateTypeEnum.DSDFundingApplicationSubmitted);
            var application = await fundingApplicationRepository.GetFundingApplicationByIdAsync(this._fundingApplication.Id);
            var requestOrigin = httpContextAccessor.HttpContext.Request.Headers["Origin"].ToString();
            var status = await statusRepository.GetById(this._fundingApplication.StatusId);
            
            try
            {
                var action = string.Empty;

                StatusEnum applicationStatus = (StatusEnum)this._fundingApplication.StatusId;

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
                    Message = ReplacePlaceholders(emailTemplate.Body, application, requestOrigin, status.Name),
                    Subject = ReplacePlaceholders(emailTemplate.Subject, application, requestOrigin, status.Name),
                    RecipientEmail = application.CreatedUser.Email,
                    RecipientName = application.CreatedUser.FullName
                };

                await emailQueueService.CreateEmailQueue(emailQueue);

            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside DSDFundingApplicationSubmitted: {ex.Message} Inner Exception: {ex.InnerException}");
                throw;
            }
        }

        private string ReplacePlaceholders(string value, FundingApplication fundingApplication, string requestOrigin, string statusName)
        {

            var returnResult = value.Replace("{OrganizationName}", fundingApplication.CreatedUser.FullName)
                                    .Replace("{ApplicationRefNo}", fundingApplication.RefNo);

            return returnResult;
        }
    }
}
