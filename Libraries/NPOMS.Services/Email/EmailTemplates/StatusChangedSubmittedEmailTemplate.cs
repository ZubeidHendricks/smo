﻿using NPOMS.Domain.Core;
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
	public class StatusChangedSubmittedEmailTemplate : IEmailTemplate
    {
        private FundingApplication _fundingApplication;

        public StatusChangedSubmittedEmailTemplate Init(FundingApplication fundingApplication)
        {
            this._fundingApplication = fundingApplication;
            return this;
        }

        public async Task SubmitToQueue()
        {
            var emailQueueService = EngineContext.Current.Resolve<IEmailQueueService>();
            var emailTemplateService = EngineContext.Current.Resolve<IEmailTemplateService>();
            var logger = EngineContext.Current.Resolve<ILogger<StatusChangedSubmittedEmailTemplate>>();
            var fundingApplicationRepository = EngineContext.Current.Resolve<IFundingApplicationRepository>();
            var userRepository = EngineContext.Current.Resolve<IUserRepository>();
            var httpContextAccessor = EngineContext.Current.Resolve<IHttpContextAccessor>();

            var emailTemplate = await emailTemplateService.GetByType(EmailTemplateTypeEnum.StatusChangedSubmitted);
            var application = await fundingApplicationRepository.GetFundingApplicationByIdAsync(this._fundingApplication.Id);
            var requestOrigin = httpContextAccessor.HttpContext.Request.Headers["Origin"].ToString();

            try
            {
                var allUsers = await userRepository.GetAllUsersAsync();
                var verifiers = allUsers.Where(x => x.Roles.Any(y => y.RoleId == (int)RoleEnum.Verifier));

                foreach (var verifier in verifiers)
                {
                    EmailQueue emailQueue = new EmailQueue()
                    {
                        CreatedDateTime = DateTime.Now,
                        EmailTemplateId = emailTemplate.Id,
                        FromEmailAddress = emailTemplate.EmailAccount.FromEmail,
                        FromEmailName = emailTemplate.EmailAccount.FromDisplayName,
                        Message = ReplacePlaceholders(emailTemplate.Body, application, verifier, requestOrigin),
                        Subject = ReplacePlaceholders(emailTemplate.Subject, application, verifier, requestOrigin),
                        RecipientEmail = verifier.Email,
                        RecipientName = verifier.FirstName
                    };

                    await emailQueueService.CreateEmailQueue(emailQueue);
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside StatusChangedSubmittedEmailTemplate-SubmitToQueue action: {ex.Message} Inner Exception: {ex.InnerException}");
                throw;
            }
        }

        private string ReplacePlaceholders(string value, FundingApplication fundingApplication, User verifier, string requestOrigin)
        {

            var returnResult = value.Replace("{ToUserFullName}", verifier.FullName)
                                    .Replace("{FundingApplicationRefNo}", fundingApplication.RefNo)
                                    .Replace("{url}", requestOrigin);

            return returnResult;
        }
    }
}