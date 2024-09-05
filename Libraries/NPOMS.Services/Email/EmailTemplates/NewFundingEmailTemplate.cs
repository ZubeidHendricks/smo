using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NPOMS.Domain.Core;
using NPOMS.Domain.Entities;
using NPOMS.Domain.Enumerations;
using NPOMS.Domain.FundingManagement;
using NPOMS.Repository.Interfaces.Core;
using NPOMS.Repository.Interfaces.Entities;
using NPOMS.Repository.Interfaces.FundingManagement;
using NPOMS.Services.Infrastructure.Implementation;
using NPOMS.Services.Interfaces;
using NPOMS.Services.Models.FundingManagement;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Services.Email.EmailTemplates
{
    public class NewFundingEmailTemplate : IEmailTemplate
    {
        private FundingCaptureViewModel _fundingCapture;

        public NewFundingEmailTemplate Init(FundingCaptureViewModel fundingCapture)
        {
            this._fundingCapture = fundingCapture;
            return this;
        }

        public async Task SubmitToQueue()
        {
            var emailQueueService = EngineContext.Current.Resolve<IEmailQueueService>();
            var emailTemplateService = EngineContext.Current.Resolve<IEmailTemplateService>();
            var logger = EngineContext.Current.Resolve<ILogger<NewFundingEmailTemplate>>();
            var fundingCaptureRepository = EngineContext.Current.Resolve<IFundingCaptureRepository>();
            var npoRepository = EngineContext.Current.Resolve<INpoRepository>();
            var financialYearRepository = EngineContext.Current.Resolve<IFinancialYearRepository>();
            var userRepository = EngineContext.Current.Resolve<IUserRepository>();
            var httpContextAccessor = EngineContext.Current.Resolve<IHttpContextAccessor>();

            var emailTemplate = await emailTemplateService.GetByType(EmailTemplateTypeEnum.NewFunding);
            var funding = await fundingCaptureRepository.GetById(this._fundingCapture.Id);
            var npo = await npoRepository.GetById(funding.NpoId);
            var financialYear = await financialYearRepository.GetById(Convert.ToInt32(funding.FinancialYearId));
            var requestOrigin = httpContextAccessor.HttpContext.Request.Headers["Origin"].ToString();

            try
            {
                var users = new List<User>();
                users.Add(await userRepository.GetUserByIdAsync(funding.CreatedUserId));

                if (funding.UpdatedUserId != null && funding.CreatedUserId != funding.UpdatedUserId)
                    users.Add(await userRepository.GetUserByIdAsync(Convert.ToInt32(funding.UpdatedUserId)));

                foreach (var user in users)
                {
                    if (user.IsActive)
                    {
                        EmailQueue emailQueue = new EmailQueue()
                        {
                            CreatedDateTime = DateTime.Now,
                            EmailTemplateId = emailTemplate.Id,
                            FromEmailAddress = emailTemplate.EmailAccount.FromEmail,
                            FromEmailName = emailTemplate.EmailAccount.FromDisplayName,
                            Message = ReplacePlaceholders(emailTemplate.Body, npo, financialYear, user, requestOrigin),
                            Subject = ReplacePlaceholders(emailTemplate.Subject, npo, financialYear, user, requestOrigin),
                            RecipientEmail = user.Email,
                            RecipientName = user.FullName
                        };

                        await emailQueueService.Create(emailQueue);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside NewFundingEmailTemplate-SubmitToQueue action: {ex.Message} Inner Exception: {ex.InnerException}");
                throw;
            }
        }

        private string ReplacePlaceholders(string value, Npo npo, FinancialYear financialYear, User user, string requestOrigin)
        {

            var returnResult = value.Replace("{ToUserFullName}", user.FullName)
                                    .Replace("{NpoName}", npo.Name)
                                    .Replace("{FinancialYearName}", financialYear.Name)
                                    .Replace("{url}", requestOrigin);

            return returnResult;
        }
    }
}
