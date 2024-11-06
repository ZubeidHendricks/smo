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
using NPOMS.Services.Models;

namespace NPOMS.Services.Email.EmailTemplates
{
    public class NpoReviewerEmailTemplates : IEmailTemplate
    {
        private Application _application;
        private UserVM[] users;

        public NpoReviewerEmailTemplates Init(Application application, UserVM[] users)
        {
            this._application = application;
            this.users = users;
            return this;
        }

        public async Task SubmitToQueue()
        {
            var emailQueueService = EngineContext.Current.Resolve<IEmailQueueService>();
            var emailTemplateService = EngineContext.Current.Resolve<IEmailTemplateService>();
            var contactInformationRepository = EngineContext.Current.Resolve<IContactInformationRepository>();
            var logger = EngineContext.Current.Resolve<ILogger<NpoReviewerEmailTemplates>>();
            var applicationRepository = EngineContext.Current.Resolve<IApplicationRepository>();
            var httpContextAccessor = EngineContext.Current.Resolve<IHttpContextAccessor>();
            var statusRepository = EngineContext.Current.Resolve<IStatusRepository>();
            var contactPerson = await contactInformationRepository.GetByNpoId(this._application.Id);
            var emailTemplate = await emailTemplateService.GetByType(EmailTemplateTypeEnum.NpoReviewer);
            var application = await applicationRepository.GetById(this._application.Id);
            var requestOrigin = httpContextAccessor.HttpContext.Request.Headers["Origin"].ToString();
            var userRepository = EngineContext.Current.Resolve<IUserRepository>();
            var usersList = users;
            var npoRepository = EngineContext.Current.Resolve<INpoRepository>();
            var npo = await npoRepository.GetById(application.NpoId);
            var npoWorkPlanReviewerTrackingList = new List<NpoWorkPlanReviewerTracking>();
            try
            {
                foreach (var user in usersList)
                {
                    EmailQueue emailQueue = new EmailQueue()
                    {
                        CreatedDateTime = DateTime.Now,
                        EmailTemplateId = emailTemplate.Id,
                        FromEmailAddress = emailTemplate.EmailAccount.FromEmail,
                        FromEmailName = emailTemplate.EmailAccount.FromDisplayName,
                        Message = ReplacePlaceholders(emailTemplate.Body, application, requestOrigin, user.FullName, application.Id, npo),
                        Subject = emailTemplate.Subject,
                        RecipientEmail = user.Email,
                        RecipientName = user.FullName
                    };

                    await emailQueueService.Create(emailQueue);

                    NpoWorkPlanReviewerTracking npoWorkPlanReviewerTracking = new NpoWorkPlanReviewerTracking
                    {
                        ApplicationId = this._application.Id,
                        UserId = user.Id,
                        SentDateTime = DateTime.Now
                    };

                    npoWorkPlanReviewerTrackingList.Add(npoWorkPlanReviewerTracking);
                }

                await applicationRepository.CreateNpoUserReviewerTracking(npoWorkPlanReviewerTrackingList);
            }

            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside InitiateScorecardEmailTemplate-SubmitToQueue action: {ex.Message} Inner Exception: {ex.InnerException}");
                throw;
            }
        }
        private string ReplacePlaceholders(string value, Application application, string origin, string contactPerson, int id, Npo npo)
        {

            var returnResult = value.Replace("{ToUserFullName}", contactPerson)
                                    .Replace("{ApplicationRefNo}", application.RefNo)
                                    .Replace("{url}", origin)
                                    .Replace("{ApplicationId}", application.Id.ToString())
                                    .Replace("{npoId}", id.ToString())
                                    .Replace("{{NPO}}", npo.Name)
                                    .Replace("{financialYear}", application.ApplicationPeriod.FinancialYear.Name);

            return returnResult;
        }
    }
}
