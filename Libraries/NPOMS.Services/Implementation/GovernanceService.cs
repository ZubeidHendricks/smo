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

    public class GovernanceService : IGovernanceService
    {
        private IGovernanceRepository _governanceRepository;
        private IUserRepository _userRepository;
        public GovernanceService(IGovernanceRepository governanceRepository, IUserRepository userRepository)
        {
            _governanceRepository = governanceRepository;
            _userRepository = userRepository;
                
        }

        public async Task CreateGovernanceReportEntity(GovernanceReport model, string userIdentifier)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

            model.CreatedUserId = loggedInUser.Id;
            model.CreatedDateTime = DateTime.Now;

            await _governanceRepository.CreateEntity(model);
        }

        public async Task<IEnumerable<GovernanceReport>> GetGovernanceReportByNpoId(int npoId)
        {
            return await _governanceRepository.GetByNpoId(npoId);
        }

        public Task<GovernanceReport> GetByIds(int financialYearId, int applicationTypeId)
        {
            throw new NotImplementedException();
        }

        public Task<GovernanceReport> GetGovernanceById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<GovernanceReport>> GetGovernanceReportByPeriodId(int applicationPeriodId)
        {
            return await _governanceRepository.GetByPeriodId(applicationPeriodId);
        }

        public async Task<IEnumerable<GovernanceReport>> GetGovernanceReports()
        {
            return await _governanceRepository.GetEntities();
        }

        public async Task UpdateGovernanceReportEntity(GovernanceReport model, string currentUserId)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(currentUserId);

            model.CreatedUserId = loggedInUser.Id;
            model.CreatedDateTime = DateTime.Now;

            await _governanceRepository.UpdateEntity(model, loggedInUser.Id);
        }

        public Task UpdateGovernanceReportEntityQC(GovernanceReport model, int currentUserId)
        {
            throw new NotImplementedException();
        }

        public async Task CompleteGovernanceReportPost(BaseCompleteViewModel model, string currentUserId)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(currentUserId);

            await _governanceRepository.CompleteGovernanceReportPost(model.ApplicationId, model.FinYear, model.QuarterId, loggedInUser.Id);
        }
    }
}
