using NPOMS.Domain.Indicator;
using NPOMS.Repository.Interfaces.Core;
using NPOMS.Repository.Interfaces.Indicator;
using NPOMS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Services.Implementation
{
	public class IndicatorService : IIndicatorService
	{
		#region Fields

		private IWorkplanTargetRepository _workplanTargetRepository;
		private IUserRepository _userRepository;
		private IWorkplanActualRepository _workplanActualRepository;
		private IWorkplanCommentRepository _workplanCommentRepository;
		private IWorkplanActualAuditRepository _workplanActualAuditRepository;

		#endregion

		#region Constructors

		public IndicatorService(
			IWorkplanTargetRepository workplanTargetRepository,
			IUserRepository userRepository,
			IWorkplanActualRepository workplanActualRepository,
			IWorkplanCommentRepository workplanCommentRepository,
			IWorkplanActualAuditRepository workplanActualAuditRepository
			)
		{
			_workplanTargetRepository = workplanTargetRepository;
			_userRepository = userRepository;
			_workplanActualRepository = workplanActualRepository;
			_workplanCommentRepository = workplanCommentRepository;
			_workplanActualAuditRepository = workplanActualAuditRepository;
		}

		#endregion

		#region Methods

		public async Task<IEnumerable<WorkplanTarget>> GetTargetsByActivityId(int activityId)
		{
			return await _workplanTargetRepository.GetByActivityId(activityId);
		}

		public async Task<WorkplanTarget> GetTargetByIds(WorkplanTarget model)
		{
			return await _workplanTargetRepository.GetByIds(model);
		}

		public async Task CreateTarget(WorkplanTarget model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.Frequency = null;
			model.CreatedUserId = loggedInUser.Id;
			model.CreatedDateTime = DateTime.Now;

			await _workplanTargetRepository.CreateAsync(model);
		}

		public async Task UpdateTarget(WorkplanTarget model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.Frequency = null;
			model.UpdatedUserId = loggedInUser.Id;
			model.UpdatedDateTime = DateTime.Now;

			await _workplanTargetRepository.UpdateAsync(model);
		}

		public async Task<IEnumerable<WorkplanActual>> GetActualsByActivityId(int activityId)
		{
			return await _workplanActualRepository.GetByActivityId(activityId);
		}

		public async Task<WorkplanActual> GetActualsByIds(WorkplanActual model)
		{
			return await _workplanActualRepository.GetByIds(model);
		}

		public async Task CreateActual(WorkplanActual model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.CreatedUserId = loggedInUser.Id;
			model.CreatedDateTime = DateTime.Now;

			await _workplanActualRepository.CreateAsync(model);
		}

		public async Task UpdateActual(WorkplanActual model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.FrequencyPeriod = null;
			model.UpdatedUserId = loggedInUser.Id;
			model.UpdatedDateTime = DateTime.Now;

			await _workplanActualRepository.UpdateAsync(model);
		}

		public async Task<IEnumerable<WorkplanComment>> GetWorkplanComments(int workplanActualId)
		{
			return await _workplanCommentRepository.GetByWorkplanActualId(workplanActualId);
		}

		public async Task CreateWorkplanComment(WorkplanComment model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.CreatedUserId = loggedInUser.Id;
			model.CreatedDateTime = DateTime.Now;

			await _workplanCommentRepository.CreateEntity(model);
		}

		public async Task CreateWorkplanActualAudit(WorkplanActualAudit model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.CreatedUserId = loggedInUser.Id;
			model.CreatedDateTime = DateTime.Now;

			await _workplanActualAuditRepository.CreateEntity(model);
		}

		public async Task<IEnumerable<WorkplanActualAudit>> GetWorkplanActualAudits(int workplanActualId)
		{
			return await _workplanActualAuditRepository.GetByWorkplanActualId(workplanActualId);
		}

		public async Task<IEnumerable<WorkplanActual>> GetWorkplanActualsByIds(List<int> activityIds, int financialYearId, int frequencyPeriodId)
		{
			return await _workplanActualRepository.GetByIds(activityIds, financialYearId, frequencyPeriodId);
		}

		#endregion
	}
}
