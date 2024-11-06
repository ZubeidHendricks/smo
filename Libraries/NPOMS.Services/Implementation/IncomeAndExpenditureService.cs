using NPOMS.Domain.Entities;
using NPOMS.Repository.Implementation.Entities;
using NPOMS.Repository.Interfaces.Core;
using NPOMS.Repository.Interfaces.Entities;
using NPOMS.Services.Interfaces;
using NPOMS.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Services.Implementation
{
    public class IncomeAndExpenditureService : IIncomeAndExpenditureService
    {
        private IUserRepository _userRepository;
        private IIncomeAndExpenditureRepository _incomeRepository;
        private IIncomeAuditRepository _incomeAuditRepository;
        public IncomeAndExpenditureService(IUserRepository userRepository, IIncomeAndExpenditureRepository incomeRepository, IIncomeAuditRepository incomeAuditRepository)
        {
            _userRepository = userRepository;
            _incomeRepository = incomeRepository;
            _incomeAuditRepository = incomeAuditRepository;


        }
        public async Task<IEnumerable<IncomeAndExpenditureReport>> GetPostReports()
        {
            return await _incomeRepository.GetEntities();
        }

        public async Task<IncomeAndExpenditureReport> GetPostReportById(int id)
        {
            return await _incomeRepository.GetById(id);
        }

        public async Task<IEnumerable<IncomeAndExpenditureReport>> GetIncomeReportByPeriodId(int applicationPeriodId)
        {
            return await _incomeRepository.GetByPeriodId(applicationPeriodId);
        }

        public async Task<IEnumerable<IncomeAndExpenditureReport>> GetIncomeReportByNpoId(int npoId)
        {
            return await _incomeRepository.GetByNpoId(npoId);
        }

        public Task<IncomeAndExpenditureReport> GetByIds(int financialYearId, int applicationTypeId)
        {
            throw new NotImplementedException();
        }

        public async Task CreateIncomeReportEntity(IncomeAndExpenditureReport model, string userIdentifier)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

            model.CreatedUserId = loggedInUser.Id;
            model.CreatedDateTime = DateTime.Now;

            await _incomeRepository.CreateEntity(model);
        }

        public async Task UpdateIncomeReportEntity(IncomeAndExpenditureReport model, string currentUserId)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(currentUserId);

            model.CreatedUserId = loggedInUser.Id;
            model.CreatedDateTime = DateTime.Now;

            await _incomeRepository.UpdateEntity(model, loggedInUser.Id);
        }

        public Task<IncomeAndExpenditureReport> GetIncomeReportById(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePostReportEntityQC(IncomeAndExpenditureReport model, int currentUserId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IncomeAndExpenditureReport>> GetPostReportByPeriodId(int applicationPeriodId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IncomeAndExpenditureReport>> GetPostReportByNpoId(int npoId)
        {
            throw new NotImplementedException();
        }

        public Task<IncomeAndExpenditureReport> GetIndicatorReportById(int id)
        {
            throw new NotImplementedException();
        }

        public Task CreatePostReportEntity(IncomeAndExpenditureReport model, string userIdentifier)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePostReportEntity(IncomeAndExpenditureReport model, string currentUserId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IncomeAndExpenditureReport>> GetIncomeReports()
        {
            throw new NotImplementedException();
        }

        public Task UpdateIncomeReportEntityQC(IncomeAndExpenditureReport model, int currentUserId)
        {
            throw new NotImplementedException();
        }

        //public async Task UpdateIncomeReportStatus(BaseCompleteViewModel model, string currentUserId)
        //{
        //    var loggedInUser = await _userRepository.GetByUserNameWithDetails(currentUserId);

        //    await _incomeRepository.UpdateIncomeReportStatus(model.ApplicationId, model.FinYear, model.QuarterId, loggedInUser.Id);
        //}

      public async  Task<IEnumerable<IncomeAndExpenditureReport>> UpdateIncomeReportStatus(BaseCompleteViewModel model, string userIdentifier)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

            return  await _incomeRepository.UpdateIncomeReportStatus(model.ApplicationId, model.FinYear, model.QuarterId, loggedInUser.Id);

      
        }

        public async  Task CreateAudit(IncomeReportAudit model, string currentUderId)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(currentUderId);

            model.CreatedUser = loggedInUser.FullName;
            model.CreatedDateTime = DateTime.Now;

            await _incomeAuditRepository.CreateEntity(model);
        }

    }
}
