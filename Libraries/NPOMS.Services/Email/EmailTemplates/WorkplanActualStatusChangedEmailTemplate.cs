using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NPOMS.Domain.Core;
using NPOMS.Domain.Entities;
using NPOMS.Domain.Enumerations;
using NPOMS.Domain.Indicator;
using NPOMS.Repository.Interfaces.Core;
using NPOMS.Repository.Interfaces.Dropdown;
using NPOMS.Repository.Interfaces.Entities;
using NPOMS.Services.Infrastructure.Implementation;
using NPOMS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Services.Email.EmailTemplates
{
	public class WorkplanActualStatusChangedEmailTemplate : IEmailTemplate
	{
		private WorkplanActual _workplanActual;
		private Application _application;

		public WorkplanActualStatusChangedEmailTemplate Init(WorkplanActual workplanActual, Application application)
		{
			this._workplanActual = workplanActual;
			this._application = application;
			return this;
		}

		public async Task SubmitToQueue()
		{
			var emailQueueService = EngineContext.Current.Resolve<IEmailQueueService>();
			var emailTemplateService = EngineContext.Current.Resolve<IEmailTemplateService>();
			var logger = EngineContext.Current.Resolve<ILogger<WorkplanActualStatusChangedEmailTemplate>>();
			var httpContextAccessor = EngineContext.Current.Resolve<IHttpContextAccessor>();
			var financialYearRepository = EngineContext.Current.Resolve<IFinancialYearRepository>();
			var frequencyPeriodRepository = EngineContext.Current.Resolve<IFrequencyPeriodRepository>();
			var userRepository = EngineContext.Current.Resolve<IUserRepository>();
			var statusRepository = EngineContext.Current.Resolve<IStatusRepository>();
			var npoRepository = EngineContext.Current.Resolve<INpoRepository>();

			var emailTemplate = await emailTemplateService.GetByType(EmailTemplateTypeEnum.WorkplanActualStatusChanged);
			var financialYear = await financialYearRepository.GetById(this._workplanActual.FinancialYearId);
			var frequencyPeriod = await frequencyPeriodRepository.GetById(this._workplanActual.FrequencyPeriodId);
			var status = await statusRepository.GetById(this._workplanActual.StatusId);
			var requestOrigin = httpContextAccessor.HttpContext.Request.Headers["Origin"].ToString();
			var npo = await npoRepository.GetById(this._application.NpoId);

			var users = new List<User>();
			users.Add(await userRepository.GetById(this._workplanActual.CreatedUserId));

			if (this._workplanActual.StatusId == (int)StatusEnum.PendingReview)
			{
				if (this._workplanActual.UpdatedUserId != null && this._workplanActual.CreatedUserId != this._workplanActual.UpdatedUserId)
					users.Add(await userRepository.GetById(Convert.ToInt32(this._workplanActual.UpdatedUserId)));
			}

			try
			{
				foreach (var user in users)
				{
					EmailQueue emailQueue = new EmailQueue()
					{
						CreatedDateTime = DateTime.Now,
						EmailTemplateId = emailTemplate.Id,
						FromEmailAddress = emailTemplate.EmailAccount.FromEmail,
						FromEmailName = emailTemplate.EmailAccount.FromDisplayName,
						Message = ReplacePlaceholders(emailTemplate.Body, this._application, financialYear.Name, frequencyPeriod.Name, requestOrigin, user, status.Name, npo),
						Subject = ReplacePlaceholders(emailTemplate.Subject, this._application, financialYear.Name, frequencyPeriod.Name, requestOrigin, user, status.Name, npo),
						RecipientEmail = user.Email,
						RecipientName = user.FullName
					};

					await emailQueueService.Create(emailQueue);
				}
			}
			catch (Exception ex)
			{
				logger.LogError($"Something went wrong inside WorkplanActualStatusChangedEmailTemplate-SubmitToQueue action: {ex.Message} Inner Exception: {ex.InnerException}");
				throw;
			}
		}

		private string ReplacePlaceholders(string value, Application application, string financialYear, string frequencyPeriod, string requestOrigin, User user, string status, Npo npo)
		{
			var returnResult = value.Replace("{ToUserFullName}", user.FullName)
									.Replace("{url}", requestOrigin)
									.Replace("{applicationId}", Convert.ToString(application.Id))
									.Replace("{ApplicationRefNo}", application.RefNo)
									.Replace("{financialYear}", financialYear)
									.Replace("{frequencyPeriod}", frequencyPeriod)
									.Replace("{status}", status)
									.Replace("{NPO}", npo.Name);

			return returnResult;
		}
	}
}
