using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NPOMS.Domain.Core;
using NPOMS.Domain.Entities;
using NPOMS.Domain.Enumerations;
using NPOMS.Repository.Interfaces.Core;
using NPOMS.Repository.Interfaces.Entities;
using NPOMS.Services.Infrastructure.Implementation;
using NPOMS.Services.Interfaces;
using NPOMS.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Services.Email.EmailTemplates
{
    public class AddworkplanapproversEmailsTemplates : IEmailTemplate
    {
        private Application _application;
        private UserVM[] users;

        public AddworkplanapproversEmailsTemplates Init(Application application, UserVM[] users)
        {
            this._application = application;
            this.users = users;
            return this;
        }

        public async Task SubmitToQueue()
        {
            var emailQueueService = EngineContext.Current.Resolve<IEmailQueueService>();
            var emailTemplateService = EngineContext.Current.Resolve<IEmailTemplateService>();
            var logger = EngineContext.Current.Resolve<ILogger<AddworkplanapproversEmailsTemplates>>();
            var applicationRepository = EngineContext.Current.Resolve<IApplicationRepository>();
            var httpContextAccessor = EngineContext.Current.Resolve<IHttpContextAccessor>();
            var npoRepository = EngineContext.Current.Resolve<INpoRepository>();
            var userRepository = EngineContext.Current.Resolve<IUserRepository>();

            var emailTemplate = await emailTemplateService.GetByType(EmailTemplateTypeEnum.AddworkplanapproversEmails);
            var application = await applicationRepository.GetById(this._application.Id);
            var npo = await npoRepository.GetById(application.NpoId);
            var requestOrigin = httpContextAccessor.HttpContext.Request.Headers["Origin"].ToString();
            var npoWorkPlanApproverTrackingList = new List<NpoWorkPlanApproverTracking>();
            /*await userRepository.GetByRoleAndDepartmentId(4,11);*/
            //var approvers = await userRepository.GetByIds((int)RoleEnum.Approver, application.ApplicationPeriod.DepartmentId);

            try
            {
                foreach (var approver in users)
                {
                    EmailQueue emailQueue = new EmailQueue()
                    {
                        CreatedDateTime = DateTime.Now,
                        EmailTemplateId = emailTemplate.Id,
                        FromEmailAddress = emailTemplate.EmailAccount.FromEmail,
                        FromEmailName = emailTemplate.EmailAccount.FromDisplayName,
                        Message = ReplacePlaceholders(emailTemplate.Body, application, requestOrigin, approver, npo),
                        Subject = ReplacePlaceholders(emailTemplate.Subject, application, requestOrigin, approver, npo),
                        RecipientEmail = approver.Email,
                        RecipientName = approver.FullName
                    };

                    await emailQueueService.Create(emailQueue);

                    NpoWorkPlanApproverTracking npoWorkPlanApproverTracking = new NpoWorkPlanApproverTracking
                    {
                        ApplicationId = this._application.Id,
                        UserId = approver.Id,
                        SentDateTime = DateTime.Now
                    };

                    npoWorkPlanApproverTrackingList.Add(npoWorkPlanApproverTracking);
                }

                await applicationRepository.CreateNpoWorkPlanApproverTracking(npoWorkPlanApproverTrackingList);
            }
            catch (Exception ex)
            {
                logger.LogError($"Something went wrong inside StatusChangedPendingApprovalEmailTemplate-SubmitToQueue action: {ex.Message} Inner Exception: {ex.InnerException}");
                throw;
            }
        }
        private string ReplacePlaceholders(string value, Application application, string requestOrigin, UserVM user, Npo npo)
        {
            var returnResult = value.Replace("{ToUserFullName}", user.FullName)
                                    .Replace("{ApplicationRefNo}", application.RefNo)
                                    .Replace("{url}", requestOrigin)
                                    .Replace("{NPO}", npo.Name);

            return returnResult;
        }
    }
}
