﻿using NPOMS.Domain.Core;
using NPOMS.Domain.Entities;
using NPOMS.Domain.Enumerations;
using NPOMS.Repository.Interfaces.Entities;
using NPOMS.Services.Infrastructure.Implementation;
using NPOMS.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace NPOMS.Services.Email.EmailTemplates
{
	public class StatusChangedApprovedEmailTemplate : IEmailTemplate
    {
        private FundingApplication _fundingApplication;

        public StatusChangedApprovedEmailTemplate Init(FundingApplication fundingApplication)
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

            var emailTemplate = await emailTemplateService.GetByType(EmailTemplateTypeEnum.StatusChangedApproved);
            var application = await fundingApplicationRepository.GetFundingApplicationByIdAsync(this._fundingApplication.Id);
            var requestOrigin = httpContextAccessor.HttpContext.Request.Headers["Origin"].ToString();

            try
            {
                EmailQueue emailQueue = new EmailQueue()
                {
                    CreatedDateTime = DateTime.Now,
                    EmailTemplateId = emailTemplate.Id,
                    FromEmailAddress = emailTemplate.EmailAccount.FromEmail,
                    FromEmailName = emailTemplate.EmailAccount.FromDisplayName,
                    Message = ReplacePlaceholders(emailTemplate.Body, application, requestOrigin),
                    Subject = ReplacePlaceholders(emailTemplate.Subject, application, requestOrigin),
                    RecipientEmail = application.CreatedUser.Email,
                    RecipientName = application.CreatedUser.FullName
                };

                await emailQueueService.CreateEmailQueue(emailQueue);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside StatusChangedApprovedEmailTemplate-SubmitToQueue action: {ex.Message} Inner Exception: {ex.InnerException}");
                throw;
            }
        }

        private string ReplacePlaceholders(string value, FundingApplication fundingApplication, string requestOrigin)
        {

            var returnResult = value.Replace("{ToUserFullName}", fundingApplication.CreatedUser.FullName)
                                    .Replace("{FundingApplicationRefNo}", fundingApplication.RefNo)
                                    .Replace("{url}", requestOrigin);

            return returnResult;
        }
    }
}
