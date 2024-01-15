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
using NPOMS.Repository.Implementation.Core;

namespace NPOMS.Services.Email.EmailTemplates
{
    public class ScorecardSummaryEmailTemplates : IEmailTemplate
    {
        private Application _application;

        public ScorecardSummaryEmailTemplates Init(Application application)
        {
            this._application = application;
            return this;
        }

        public async Task SubmitToQueue()
        {
            var emailQueueService = EngineContext.Current.Resolve<IEmailQueueService>();
            var emailTemplateService = EngineContext.Current.Resolve<IEmailTemplateService>();
            var contactInformationRepository = EngineContext.Current.Resolve<IContactInformationRepository>();
            var logger = EngineContext.Current.Resolve<ILogger<ScorecardSummaryEmailTemplates>>();
            var applicationRepository = EngineContext.Current.Resolve<IApplicationRepository>();
            var httpContextAccessor = EngineContext.Current.Resolve<IHttpContextAccessor>();
            var statusRepository = EngineContext.Current.Resolve<IStatusRepository>();
            var contactPerson = await contactInformationRepository.GetByNpoId(this._application.Id);
            var emailTemplate = await emailTemplateService.GetByType(EmailTemplateTypeEnum.ScorecardSummary);
            var application = await applicationRepository.GetById(this._application.Id);
            var requestOrigin = httpContextAccessor.HttpContext.Request.Headers["Origin"].ToString();
            //var status = await statusRepository.GetById(this._fundingApplication.StatusId);
            var userRepository = EngineContext.Current.Resolve<IUserRepository>();
            var user = await userRepository.GetByUserName("Shafieka.Samuels@westerncape.gov.za");
            try
            {
                var action = string.Empty;
                var contactPersonFullName = string.Empty;
                var contactPersonName = user.UserName; // contactPerson.Where(x => x.IsPrimaryContact == true).FirstOrDefault();
                if (contactPersonName != null)
                {
                    contactPersonFullName = user.FirstName + " " + user.LastName;
                }
                // StatusEnum applicationStatus = (StatusEnum)this._fundingApplication.StatusId;

                //switch (applicationStatus)
                //{
                //    case StatusEnum.Reviewed:
                //        action = "has been sent to be evaluated";
                //        break;
                //    case StatusEnum.Evaluated:
                //        action = "has been sent to be adjudicated";
                //        break;
                //    case StatusEnum.Adjudicated:
                //        action = "has been adjudicated";
                //        break;
                //}

                EmailQueue emailQueue = new EmailQueue()
                {
                    CreatedDateTime = DateTime.Now,
                    EmailTemplateId = emailTemplate.Id,
                    FromEmailAddress = emailTemplate.EmailAccount.FromEmail,
                    FromEmailName = emailTemplate.EmailAccount.FromDisplayName,
                    Message = ReplacePlaceholders(emailTemplate.Body, application, requestOrigin, contactPersonFullName, application.Id),
                    Subject = emailTemplate.Subject, // ReplacePlaceholders(emailTemplate.Subject, application, "", ""),
                    RecipientEmail = user.Email,
                    RecipientName = contactPersonFullName
                };

                await emailQueueService.Create(emailQueue);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside StatusChangedEmailTemplate-SubmitToQueue action: {ex.Message} Inner Exception: {ex.InnerException}");
                throw;
            }
        //}
        }
        private string ReplacePlaceholders(string value, Application application, string origin, string contactPerson, int id)
        {

            var returnResult = value.Replace("{ToUserFullName}", contactPerson)
                                    .Replace("{ApplicationRefNo}", application.RefNo)
                                    .Replace("{url}", origin)
                                    .Replace("{npoId}", id.ToString())
                                    .Replace("{financialYear}", application.ApplicationPeriod.FinancialYear.Name);

            return returnResult;
        }
    }
}
