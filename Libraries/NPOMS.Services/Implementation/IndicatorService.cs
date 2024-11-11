using NPOMS.Domain.Dropdown;
using NPOMS.Domain.Entities;
using NPOMS.Domain.Indicator;
using NPOMS.Repository;
using NPOMS.Repository.Implementation.Entities;
using NPOMS.Repository.Interfaces.Core;
using NPOMS.Repository.Interfaces.Dropdown;
using NPOMS.Repository.Interfaces.Entities;
using NPOMS.Repository.Interfaces.Indicator;
using NPOMS.Services.Interfaces;
using NPOMS.Services.Models;
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
        private IIndicatorReportRepository _indicatorReportRepository;
        private IIndicatorRepository _indicatorRepository;
        private INPOIndicatorRepository _npoindicatorRepository;
        private IAuditIndicatorRepository _auditIndicatorRepository;
        private RepositoryContext _repositoryContext;

		#endregion

		#region Constructors

		public IndicatorService(
			IWorkplanTargetRepository workplanTargetRepository,
			IUserRepository userRepository,
			IWorkplanActualRepository workplanActualRepository,
			IWorkplanCommentRepository workplanCommentRepository,
			IWorkplanActualAuditRepository workplanActualAuditRepository,
            IIndicatorReportRepository indicatorReportRepository,
            IIndicatorRepository indicatorRepository,
            INPOIndicatorRepository npoindicatorRepository,
            IAuditIndicatorRepository auditIndicatorRepository,
            RepositoryContext repositoryContext
			)
		{
			_workplanTargetRepository = workplanTargetRepository;
			_userRepository = userRepository;
			_workplanActualRepository = workplanActualRepository;
			_workplanCommentRepository = workplanCommentRepository;
			_workplanActualAuditRepository = workplanActualAuditRepository;
			_repositoryContext = repositoryContext;
			_indicatorReportRepository = indicatorReportRepository;
            _indicatorRepository = indicatorRepository;
            _npoindicatorRepository = npoindicatorRepository;
            _auditIndicatorRepository = auditIndicatorRepository;

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

			var oldEntity = await this._repositoryContext.WorkplanTargets.FindAsync(model.Id);
			await _workplanTargetRepository.UpdateAsync(oldEntity, model, true, loggedInUser.Id);
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

			var oldEntity = await this._repositoryContext.WorkplanActuals.FindAsync(model.Id);
			await _workplanActualRepository.UpdateAsync(oldEntity, model, true, loggedInUser.Id);
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

        public async Task<IEnumerable<IndicatorReport>> GetIndicatorReports()
        {
            return await _indicatorReportRepository.GetEntities();
        }

        public async Task<IndicatorReport> GetIndicatorReportById(int id)
        {
            return await _indicatorReportRepository.GetById(id);
        }

        public async Task<IEnumerable<IndicatorReport>> GetIndicatorReportByPeriodId(int applicationPeriodId)
        {
            return await _indicatorReportRepository.GetByPeriodId(applicationPeriodId);
        }

        public async Task<IEnumerable<IndicatorReport>> GetIndicatorReportByNpoId(int npoId)
        {
            return await _indicatorReportRepository.GetByNpoId(npoId);
        }

        public Task<IndicatorReport> GetByIds(int financialYearId, int applicationTypeId)
        {
            throw new NotImplementedException();
        }

        public async Task CreateIndicatorReportEntity(IndicatorReport model, string userIdentifier)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

            model.CreatedUserId = loggedInUser.Id;
            model.CreatedDateTime = DateTime.Now;

            await _indicatorReportRepository.CreateEntity(model);
        }

        public async Task UpdateIndicatorReportEntity(IndicatorReport model, string currentUserId)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(currentUserId);

            model.CreatedUserId = loggedInUser.Id;
            model.CreatedDateTime = DateTime.Now;

            await _indicatorReportRepository.UpdateEntity(model, loggedInUser.Id);
        }

        public Task UpdateIndicatorReportEntityQC(IndicatorReport model, int currentUserId)
        {
            throw new NotImplementedException();
        }

        public async Task loadindicatorsAsync(List<Indicators> data)
        {
            await _indicatorRepository.loadindicatorsAsync(data);
        }

        public async Task loadNPOindicatorsAsync(List<NPOIndicators> data)
        {
            await _npoindicatorRepository.loadindicatorsAsync(data);
        }
        public async Task<IEnumerable<WorkplanActual>> GetActualsByActivityIds(List<int> activityIds)
        {
            return await _workplanActualRepository.GetByActivityIds(activityIds);
        }

        public async Task<IEnumerable<WorkplanTarget>> GetTargetsByActivityIds(List<int> activityIds)
        {
            return await _workplanTargetRepository.GetTargetsByActivityIds(activityIds);
        }

        public async Task<IEnumerable<IndicatorReport>> UpdateIndicatorReportStatus(BaseCompleteViewModel model, string currentUserId)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(currentUserId);

             return await _indicatorReportRepository.UpdateIndicatorReportStatus(model.ApplicationId, model.FinYear, model.QuarterId, loggedInUser.Id);
        }

        public async Task CreateAudit(IndicatorReportAudit model, string userIdentifier)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

            model.CreatedUser = loggedInUser.FullName;
            model.CreatedDateTime = DateTime.Now;

            await _auditIndicatorRepository.CreateEntity(model);
        }

        #endregion
    }
}
