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
    public class VerifyActualService : IVerifyActualService
    {
        private IUserRepository _userRepository;
        private IVerifyActualRepository _verifyActualRepository;
        public VerifyActualService(IUserRepository userRepository, IVerifyActualRepository verifyActualRepository)
        {
            _userRepository = userRepository;
            _verifyActualRepository = verifyActualRepository;

        }
        public async Task CreateAudit(VerifyActual model, string currentUderId)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(currentUderId);

            //model.CreatedUser = loggedInUser.FullName;
            model.CreatedDateTime = DateTime.Now;

            await _verifyActualRepository.CreateEntity(model);
        }

        public async Task CreateVerifiedActualsEntity(VerifyActual model, string userIdentifier)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

            model.CreatedUserId = loggedInUser.Id;
            model.CreatedDateTime = DateTime.Now;

            await _verifyActualRepository.CreateEntity(model);
        }

       public async Task<IEnumerable<VerifyActual>> GetVerifiedActuals()
        {
            return await _verifyActualRepository.GetEntities();
        }

        public async Task<VerifyActual> GetVerifiedActualsById(int id)
        {
            return await _verifyActualRepository.GetById(id);
        }

            public Task<VerifyActual> GetVerifiedActualsByIds(int financialYearId, int applicationTypeId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<VerifyActual>> GetVerifiedActualsByNpoId(int npoId)
        {
            return await _verifyActualRepository.GetByNpoId(npoId);
        }

        public async    Task<VerifyActual> GetVerifiedActualsByPeriodId(int actualId)
        {
            return await _verifyActualRepository.GetVerifiedActualsByPeriodId(actualId);
        }

        public Task<IEnumerable<VerifyActual>> GetVerifiedActualsByPeriodIdQtrIId(int applicationPeriodId, int qtrId)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateVerifiedActualsEntity(VerifyActual model, string currentUserId)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(currentUserId);

            model.CreatedUserId = loggedInUser.Id;
            model.CreatedDateTime = DateTime.Now;

            await _verifyActualRepository.UpdateEntity(model, loggedInUser.Id);
        }

        public Task<IEnumerable<VerifyActual>> UpdateVerifiedActualsStatus(BaseCompleteViewModel model, string userIdentifier)
        {
            throw new NotImplementedException();
        }
    }
}
