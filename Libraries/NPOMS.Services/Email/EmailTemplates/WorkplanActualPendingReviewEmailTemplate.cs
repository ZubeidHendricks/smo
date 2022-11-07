using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NPOMS.Domain.Core;
using NPOMS.Domain.Entities;
using NPOMS.Domain.Enumerations;
using NPOMS.Domain.Indicator;
using NPOMS.Repository.Interfaces.Core;
using NPOMS.Repository.Interfaces.Dropdown;
using NPOMS.Repository.Interfaces.Entities;
using NPOMS.Repository.Interfaces.Mapping;
using NPOMS.Services.Infrastructure.Implementation;
using NPOMS.Services.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NPOMS.Services.Email.EmailTemplates
{
	public class WorkplanActualPendingReviewEmailTemplate : IEmailTemplate
	{
		private WorkplanActual _workplanActual;
		private Application _application;

		public WorkplanActualPendingReviewEmailTemplate Init(WorkplanActual workplanActual, Application application)
		{
			this._workplanActual = workplanActual;
			this._application = application;
			return this;
		}

		public async Task SubmitToQueue()
		{
			var emailQueueService = EngineContext.Current.Resolve<IEmailQueueService>();
			var emailTemplateService = EngineContext.Current.Resolve<IEmailTemplateService>();
			var logger = EngineContext.Current.Resolve<ILogger<WorkplanActualPendingReviewEmailTemplate>>();
			var httpContextAccessor = EngineContext.Current.Resolve<IHttpContextAccessor>();
			var financialYearRepository = EngineContext.Current.Resolve<IFinancialYearRepository>();
			var frequencyPeriodRepository = EngineContext.Current.Resolve<IFrequencyPeriodRepository>();
			var rolePermissionRepository = EngineContext.Current.Resolve<IRolePermissionRepository>();
			var userRoleRepository = EngineContext.Current.Resolve<IUserRoleRepository>();
			var userRepository = EngineContext.Current.Resolve<IUserRepository>();
			var npoRepository = EngineContext.Current.Resolve<INpoRepository>();

			var emailTemplate = await emailTemplateService.GetByType(EmailTemplateTypeEnum.WorkplanActualPendingReview);
			var financialYear = await financialYearRepository.GetById(this._workplanActual.FinancialYearId);
			var frequencyPeriod = await frequencyPeriodRepository.GetById(this._workplanActual.FrequencyPeriodId);
			var requestOrigin = httpContextAccessor.HttpContext.Request.Headers["Origin"].ToString();
			var npo = await npoRepository.GetById(this._application.NpoId);

			var rolePermissions = await rolePermissionRepository.GetByPermissionId((int)PermissionEnum.ReviewOrVerifyWorkplanActual);
			var distinctRoleIds = rolePermissions.Select(x => x.RoleId).Distinct().ToList();
			var userRoles = await userRoleRepository.GetByRoleIds(distinctRoleIds);
			var distinctUserIds = userRoles.Select(x => x.UserId).Distinct().ToList();
			var users = await userRepository.GetByUserIds(distinctUserIds);

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
						Message = ReplacePlaceholders(emailTemplate.Body, this._application, financialYear.Name, frequencyPeriod.Name, requestOrigin, user, npo),
						Subject = ReplacePlaceholders(emailTemplate.Subject, this._application, financialYear.Name, frequencyPeriod.Name, requestOrigin, user, npo),
						RecipientEmail = user.Email,
						RecipientName = user.FullName
					};

					await emailQueueService.Create(emailQueue);
				}
			}
			catch (Exception ex)
			{
				logger.LogError($"Something went wrong inside WorkplanActualPendingReviewEmailTemplate-SubmitToQueue action: {ex.Message} Inner Exception: {ex.InnerException}");
				throw;
			}
		}

		private string ReplacePlaceholders(string value, Application application, string financialYear, string frequencyPeriod, string requestOrigin, User user, Npo npo)
		{
			var returnResult = value.Replace("{ToUserFullName}", user.FullName)
									.Replace("{url}", requestOrigin)
									.Replace("{applicationId}", Convert.ToString(application.Id))
									.Replace("{ApplicationRefNo}", application.RefNo)
									.Replace("{financialYear}", financialYear)
									.Replace("{frequencyPeriod}", frequencyPeriod)
									.Replace("{NPO}", npo.Name);

			return returnResult;
		}
	}
}
