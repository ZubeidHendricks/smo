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
    public class SDIPService : ISDIPService
    {
        private ISDIPRepository _sdipRepository;
        private IUserRepository _userRepository;
        private ISDIPAuditRepository _SDIPAuditRepository;
        public SDIPService(ISDIPRepository sdipRepository, IUserRepository userRepository, ISDIPAuditRepository SDIPAuditRepository)
        {
            _sdipRepository = sdipRepository;
            _userRepository = userRepository;
            _SDIPAuditRepository = SDIPAuditRepository;


        }
        public async  Task CreateAudit(SDIPReportAudit model, string currentUderId)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(currentUderId);

            model.CreatedUser = loggedInUser.FullName;
            model.CreatedDateTime = DateTime.Now;

            await _SDIPAuditRepository.CreateEntity(model);
        }

        public async Task CreateSDIPReportEntity(SDIPReport model, string userIdentifier)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

            model.CreatedUserId = loggedInUser.Id;
            model.CreatedDateTime = DateTime.Now;

            await _sdipRepository.CreateEntity(model);
        }

        public Task<SDIPReport> GetByIds(int financialYearId, int applicationTypeId)
        {
            throw new NotImplementedException();
        }

        public async Task<SDIPReport> GetSDIPReportById(int id)
        {
            return await _sdipRepository.GetById(id);
        }

        public async Task<IEnumerable<SDIPReport>> GetSDIPReportByNpoId(int npoId)
        {
            return await _sdipRepository.GetByNpoId(npoId);
        }

        public async Task<IEnumerable<SDIPReport>> GetSDIPReportByPeriodId(int applicationPeriodId)
        {
            return await _sdipRepository.GetByPeriodId(applicationPeriodId);
        }

        public async Task<IEnumerable<SDIPReport>> GetSDIPReports()
        {
            return await _sdipRepository.GetEntities();
        }

        public async Task UpdateSDIPReportEntity(SDIPReport model, string currentUserId)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(currentUserId);

            model.CreatedUserId = loggedInUser.Id;
            model.CreatedDateTime = DateTime.Now;

            await _sdipRepository.UpdateEntity(model, loggedInUser.Id);
        }

        public async Task<IEnumerable<SDIPReport>> UpdateSDIPStatus(BaseCompleteViewModel model, string currentUserId)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(currentUserId);

            return await _sdipRepository.UpdateSDIPStatus(model.ApplicationId, model.FinYear, model.QuarterId, loggedInUser.Id);
        }
    }
}
