using NPOMS.Domain.Core;
using NPOMS.Domain.Entities;
using NPOMS.Domain.Enumerations;
using NPOMS.Repository.Interfaces.Core;
using NPOMS.Repository.Interfaces.Entities;
using NPOMS.Services.Infrastructure.Implementation;
using NPOMS.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq;
using System.Collections.Generic;
using NPOMS.Repository.Interfaces.Evaluation;
using Azure;

namespace NPOMS.Services.Email.EmailTemplates
{
    public class RejectedScorecardEmailTemplate : IEmailTemplate
    {
        private Domain.Evaluation.Response _response;
        public RejectedScorecardEmailTemplate Init(Domain.Evaluation.Response response)
        {
            this._response = response;
            return this;
        }

        public async Task SubmitToQueue()
        {
            var emailQueueService = EngineContext.Current.Resolve<IEmailQueueService>();
            var emailTemplateService = EngineContext.Current.Resolve<IEmailTemplateService>();
            var logger = EngineContext.Current.Resolve<ILogger<ScorecardSummaryEmailTemplates>>();
            var applicationRepository = EngineContext.Current.Resolve<IApplicationRepository>();
            var httpContextAccessor = EngineContext.Current.Resolve<IHttpContextAccessor>();
            var emailTemplate = await emailTemplateService.GetByType(EmailTemplateTypeEnum.RejectedScorecard);
            var application = await applicationRepository.GetById(this._response.FundingApplicationId);
            var requestOrigin = httpContextAccessor.HttpContext.Request.Headers["Origin"].ToString();
            var userRepository = EngineContext.Current.Resolve<IUserRepository>();

            var npoRepository = EngineContext.Current.Resolve<INpoRepository>();
            var npo = await npoRepository.GetById(application.NpoId);

            var user = await userRepository.GetById(this._response.CreatedUserId);
            
            try
            {
                var action = string.Empty;
                var contactPersonFullName = string.Empty;

                var contactPersonName = user.UserName;

                if (contactPersonName != null)
                {
                    contactPersonFullName = user.FirstName + " " + user.LastName;
                }

                EmailQueue emailQueue = new EmailQueue()
                {
                    CreatedDateTime = DateTime.Now,
                    EmailTemplateId = emailTemplate.Id,
                    FromEmailAddress = emailTemplate.EmailAccount.FromEmail,
                    FromEmailName = emailTemplate.EmailAccount.FromDisplayName,
                    Message = ReplacePlaceholders(emailTemplate.Body, application, requestOrigin, user.FullName, application.Id, npo),
                    Subject = emailTemplate.Subject,
                    RecipientEmail = user.Email,
                    RecipientName = contactPersonFullName
                };

                await emailQueueService.Create(emailQueue);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside RejectedScorecardEmailTemplate action: {ex.Message} Inner Exception: {ex.InnerException}");
                throw;
            }

        }

        private string ReplacePlaceholders(string value, Application application, string origin, string contactPerson, int id, Npo npo)
        {

            var returnResult = value.Replace("{ToUserFullName}", contactPerson)
                                    .Replace("{ApplicationRefNo}", application.RefNo)
                                    .Replace("{url}", origin)
                                    .Replace("{npoId}", id.ToString())
                                    .Replace("{organisationName}", npo.Name)
                                    .Replace("{financialYear}", application.ApplicationPeriod.FinancialYear.Name);

            return returnResult;
        }
    }
}
