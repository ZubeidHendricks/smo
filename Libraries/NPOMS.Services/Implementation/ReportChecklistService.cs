using NPOMS.Domain.Entities;
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
    public class ReportChecklistService : IReportChecklistService
    {
        private IReportChecklistRepository _reportChecklistRepository;
        private IUserRepository _userRepository;
        public ReportChecklistService(IUserRepository userRepository, IReportChecklistRepository reportChecklistRepository)
        {
             _userRepository = userRepository;
            _reportChecklistRepository = reportChecklistRepository;


        }
        public Task CreateAudit(ReportChecklist audit, string currentUderId)
        {
            throw new NotImplementedException();
        }

        public async Task CreateEntity(ReportChecklist model, string userIdentifier)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

            model.CreatedUserId = loggedInUser.Id;
            model.CreatedDateTime = DateTime.Now;

            await _reportChecklistRepository.CreateAsync(model);
        }

        public Task<ReportChecklist> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ReportChecklist> GetByIds(int financialYearId, int applicationTypeId)
        {
            throw new NotImplementedException();
        }

        public async Task<ReportChecklist> GetByPeriodIdAndqtrId(int applicationPeriodId, int qtrId)
        {
            return await _reportChecklistRepository.GetByPeriodIdAndqtrId(applicationPeriodId, qtrId);
        }

        public async Task<IEnumerable<ReportChecklist>> GetEntities()
        {
            return await _reportChecklistRepository.GetEntities();
        }

        public Task<IEnumerable<ReportChecklist>> UpdateAnyOtherStatus(BaseCompleteViewModel model, string currentUserId)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateEntity(ReportChecklist model, string currentUserId)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(currentUserId);

            model.CreatedUserId = loggedInUser.Id;
            model.CreatedDateTime = DateTime.Now;

            await _reportChecklistRepository.UpdateAsync(model);
        }
    }
}
