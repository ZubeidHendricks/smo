using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NPOMS.Domain.Core;
using NPOMS.Domain.Entities;
using NPOMS.Domain.Enumerations;
using NPOMS.Repository.Interfaces.Core;
using NPOMS.Repository.Interfaces.Entities;
using NPOMS.Repository.Interfaces.FundingManagement;
using NPOMS.Services.Infrastructure.Implementation;
using NPOMS.Services.Interfaces;
using NPOMS.Services.Models.FundingManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPOMS.Services.Email.EmailTemplates
{
    public class FundingStatusChangedEmailTemplate : IEmailTemplate
    {
        private FundingCaptureViewModel _fundingCapture;

        public FundingStatusChangedEmailTemplate Init(FundingCaptureViewModel fundingCapture)
        {
            this._fundingCapture = fundingCapture;
            return this;
        }

        public async Task SubmitToQueue()
        {
            var emailQueueService = EngineContext.Current.Resolve<IEmailQueueService>();
            var emailTemplateService = EngineContext.Current.Resolve<IEmailTemplateService>();
            var logger = EngineContext.Current.Resolve<ILogger<FundingStatusChangedEmailTemplate>>();
            var fundingCaptureRepository = EngineContext.Current.Resolve<IFundingCaptureRepository>();
            var npoRepository = EngineContext.Current.Resolve<INpoRepository>();
            var financialYearRepository = EngineContext.Current.Resolve<IFinancialYearRepository>();
            var userRepository = EngineContext.Current.Resolve<IUserRepository>();
            var statusRepository = EngineContext.Current.Resolve<IStatusRepository>();
            var httpContextAccessor = EngineContext.Current.Resolve<IHttpContextAccessor>();

            var emailTemplate = await emailTemplateService.GetByType(EmailTemplateTypeEnum.FundingStatusChanged);
            var funding = await fundingCaptureRepository.GetById(this._fundingCapture.Id);
            var npo = await npoRepository.GetById(funding.NpoId);
            var financialYear = await financialYearRepository.GetById(Convert.ToInt32(funding.FinancialYearId));
            var status = await statusRepository.GetById(this._fundingCapture.StatusId);
            var requestOrigin = httpContextAccessor.HttpContext.Request.Headers["Origin"].ToString();

            try
            {
                var users = new List<User>();
                users.Add(await userRepository.GetUserByIdAsync(funding.CreatedUserId));

                if (funding.UpdatedUserId != null && funding.CreatedUserId != funding.UpdatedUserId)
                    users.Add(await userRepository.GetUserByIdAsync(Convert.ToInt32(funding.UpdatedUserId)));

                var action = string.Empty;

                StatusEnum fundingStatus = (StatusEnum)this._fundingCapture.StatusId;

                switch (fundingStatus)
                {
                    case StatusEnum.Approved:
                        action = "approved";
                        break;
                    case StatusEnum.Declined:
                        action = "declined";
                        break;
                }

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
                            Message = ReplacePlaceholders(emailTemplate.Body, npo, financialYear, user, requestOrigin, status.Name, action),
                            Subject = ReplacePlaceholders(emailTemplate.Subject, npo, financialYear, user, requestOrigin, status.Name, action),
                            RecipientEmail = user.Email,
                            RecipientName = user.FullName
                        };

                        await emailQueueService.Create(emailQueue);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside FundingStatusChangedEmailTemplate-SubmitToQueue action: {ex.Message} Inner Exception: {ex.InnerException}");
                throw;
            }
        }

        private string ReplacePlaceholders(string value, Npo npo, FinancialYear financialYear, User user, string requestOrigin, string statusName, string action)
        {

            var returnResult = value.Replace("{ToUserFullName}", user.FullName)
                                    .Replace("{NpoName}", npo.Name)
                                    .Replace("{FinancialYearName}", financialYear.Name)
                                    .Replace("{url}", requestOrigin)
                                    .Replace("{StatusName}", statusName)
                                    .Replace("{action}", action);

            return returnResult;
        }
    }
}
