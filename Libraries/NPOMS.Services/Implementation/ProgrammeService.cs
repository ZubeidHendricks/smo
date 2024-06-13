﻿using NPOMS.Domain.Entities;
using NPOMS.Domain.Enumerations;
using NPOMS.Repository;
using NPOMS.Repository.Interfaces.Core;
using NPOMS.Repository.Interfaces.Entities;
using NPOMS.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace NPOMS.Services.Implementation
{
    public class ProgrammeService : IProgrammeService
    {
        private IProgrameBankDetailRepository _programeBankDetailRepository;
        private IProgrameContactDetailRepository _programeContactDetailRepository;
        private IUserRepository _userRepository;
        private RepositoryContext _repositoryContext;
        private IProgrameDeliveryRepository _programeDeliveryRepository;
        private INpoProfileRepository _npoProfileRepository;
        public ProgrammeService(
            IProgrameBankDetailRepository programeBankDetailRepository,
            IProgrameContactDetailRepository programeContactDetailRepository,
            IUserRepository userRepository,
            IProgrameDeliveryRepository programeDeliveryRepository,
            INpoProfileRepository npoProfileRepository,
            RepositoryContext repositoryContext)
        {
            _programeBankDetailRepository = programeBankDetailRepository;
            _programeContactDetailRepository = programeContactDetailRepository;
            _userRepository = userRepository;
            _repositoryContext = repositoryContext;
            _programeDeliveryRepository = programeDeliveryRepository;
            _npoProfileRepository = npoProfileRepository;
        }

        public async Task CreateBankDetails(ProgramBankDetails model, string userId, int npoProfileId)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userId);

            model.CreatedUserId = loggedInUser.Id;
            model.CreatedDateTime = DateTime.Now;

            await _programeBankDetailRepository.CreateAsync(model);

            var npoProfile = await _npoProfileRepository.GetById(npoProfileId);
            npoProfile.AccessStatusId = (int)AccessStatusEnum.Pending;
            await _npoProfileRepository.UpdateAsync(npoProfile);
        }

        public async Task CreateContact(ProgramContactInformation model, string userId, int npoProfileId)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userId);

            model.CreatedUserId = loggedInUser.Id;
            model.CreatedDateTime = DateTime.Now;

            await _programeContactDetailRepository.CreateAsync(model);

            var npoProfile = await _npoProfileRepository.GetById(npoProfileId);
            npoProfile.AccessStatusId = (int)AccessStatusEnum.Pending;
            await _npoProfileRepository.UpdateAsync(npoProfile);
        }

        public async Task CreateDelivery(ProgrammeServiceDelivery model, string userId)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userId);
            model.IsActive = true;
            model.CreatedUserId = loggedInUser.Id;
            model.CreatedDateTime = DateTime.Now;

            await _programeDeliveryRepository.CreateAsync(model);
        }

        public async Task UpdateBankDetails(ProgramBankDetails model, string userId, int npoProfileId)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userId);

            model.UpdatedUserId = loggedInUser.Id;
            model.UpdatedDateTime = DateTime.Now;

            var oldEntity = await _repositoryContext.ProgramBankDetails.FindAsync(model.Id);
            await _programeBankDetailRepository.UpdateAsync(oldEntity, model, true, loggedInUser.Id);

            var npoProfile = await _npoProfileRepository.GetById(npoProfileId);
            npoProfile.AccessStatusId = (int)AccessStatusEnum.Pending;
            await _npoProfileRepository.UpdateAsync(npoProfile);
        }

        public async Task UpdateContact(ProgramContactInformation model, string userId, int npoProfileId)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userId);

            model.UpdatedUserId = loggedInUser.Id;
            model.UpdatedDateTime = DateTime.Now;

            var oldEntity = await this._repositoryContext.ProgramContactInformation.FindAsync(model.Id);
            await _programeContactDetailRepository.UpdateAsync(oldEntity, model, true, loggedInUser.Id);

            var npoProfile = await _npoProfileRepository.GetById(npoProfileId);
            npoProfile.AccessStatusId = (int)AccessStatusEnum.Pending;
            await _npoProfileRepository.UpdateAsync(npoProfile);
        }

        public async Task UpdateDelivery(ProgrammeServiceDelivery model, string userId)
        {
            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userId);

            model.UpdatedUserId = loggedInUser.Id;
            model.UpdatedDateTime = DateTime.Now;

            var oldEntity = await this._repositoryContext.ProgrammeServiceDelivery.FindAsync(model.Id);
            await _programeDeliveryRepository.UpdateAsync(oldEntity, model, true, loggedInUser.Id);
        }
    }
}
