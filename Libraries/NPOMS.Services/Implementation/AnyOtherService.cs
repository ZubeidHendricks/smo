using NPOMS.Domain.Entities;
using NPOMS.Repository.Implementation.Entities;
using NPOMS.Repository.Interfaces;
using NPOMS.Repository.Interfaces.Core;
using NPOMS.Repository.Interfaces.Entities;
using NPOMS.Services.Interfaces;
using NPOMS.Services.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Services.Implementation
{
    public class AnyOtherService : IAnyOtherService
    {
        private IAnyOtherRepository _anyOtherRepository;
        private IUserRepository _userRepository;
        private IAnyOtherAuditRepository _anyOtherAuditRepository;
        public AnyOtherService(IAnyOtherRepository anyOtherRepository, IUserRepository userRepository, IAnyOtherAuditRepository anyOtherAuditRepository)
        {
            _anyOtherRepository = anyOtherRepository;
            _userRepository = userRepository;
            _anyOtherAuditRepository = anyOtherAuditRepository;
        }

        public async Task CreateEntity(AnyOtherInformationReport model,string userIdentifier)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

            model.CreatedUserId = loggedInUser.Id;
            model.CreatedDateTime = DateTime.Now;

            await _anyOtherRepository.CreateEntity(model);
        }

        public Task<AnyOtherInformationReport> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<AnyOtherInformationReport> GetByIds(int financialYearId, int applicationTypeId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AnyOtherInformationReport>> GetByNpoId(int npoId)
        {
            return await _anyOtherRepository.GetByNpoId(npoId);
        }

        public async Task<IEnumerable<AnyOtherInformationReport>> GetByPeriodId(int applicationPeriodId)
        {
            return await _anyOtherRepository.GetByPeriodId(applicationPeriodId);
        }

        public async Task<IEnumerable<AnyOtherInformationReport>> GetEntities()
        {
            return await _anyOtherRepository.GetEntities();
        }

        public async  Task<IEnumerable<AnyOtherInformationReport>> UpdateAnyOtherStatus(BaseCompleteViewModel model, string currentUserId)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(currentUserId);

           return  await _anyOtherRepository.UpdateAnyOtherStatus(model.ApplicationId, model.FinYear, model.QuarterId, loggedInUser.Id);
        }

        public async Task UpdateEntity(AnyOtherInformationReport model, string currentUserId)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(currentUserId);

            model.CreatedUserId = loggedInUser.Id;
            model.CreatedDateTime = DateTime.Now;

            await _anyOtherRepository.UpdateEntity(model, loggedInUser.Id);
        }

        public Task UpdateEntityQC(AnyOtherInformationReport model, string currentUserId)
        {
            throw new NotImplementedException();
        }

        public async Task CreateAudit(AnyOtherReportAudit model, string currentUderId)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(currentUderId);

            model.CreatedUser = loggedInUser.FullName;
            model.CreatedDateTime = DateTime.Now;

            await _anyOtherAuditRepository.CreateEntity(model);
        }
    }
}
