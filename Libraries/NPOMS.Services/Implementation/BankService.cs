﻿using NPOMS.Domain.Budget;
using NPOMS.Domain.Entities;
using NPOMS.Repository;
using NPOMS.Repository.Implementation.Core;
using NPOMS.Repository.Interfaces.Budget;
using NPOMS.Repository.Interfaces.Core;
using NPOMS.Repository.Interfaces.Entities;
using NPOMS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Services.Implementation
{
	public class BankService : IBankService
	{
		#region Fields

		private IBankDetailRepository _bankDetailRepository;
		private IProgrameBankDetailRepository _programeBankDetailRepository;
        private IUserRepository _userRepository;
		private RepositoryContext _repositoryContext;

		#endregion

		#region Constructors

		public BankService(
            IBankDetailRepository bankDetailRepository,
			IUserRepository userRepository,
            IProgrameBankDetailRepository programeBankDetailRepository,
            RepositoryContext repositoryContext)
		{
			_bankDetailRepository = bankDetailRepository;
            _userRepository = userRepository;
            _repositoryContext = repositoryContext;
            _programeBankDetailRepository = programeBankDetailRepository;

        }

		#endregion

		#region Methods

		public async Task Create(BankDetail model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.CreatedUserId = loggedInUser.Id;
			model.CreatedDateTime = DateTime.Now;
			await _bankDetailRepository.CreateAsync(model);
		}

		public async Task Update(BankDetail model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.UpdatedUserId = loggedInUser.Id;
			model.UpdatedDateTime = DateTime.Now;

			var oldEntity = await this._repositoryContext.BankDetails.FindAsync(model.Id);
			await _bankDetailRepository.UpdateAsync(oldEntity, model, true, loggedInUser.Id);
		}
	
        public Task<IEnumerable<BankDetail>> GetBankDetailsById(int banDetailId)
        {
            throw new NotImplementedException();
        }     

        public Task<IEnumerable<BankDetail>> GetBankDetails()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProgramBankDetails>> GetBankDetailsByProgramId(int progId)
        {
            return await _programeBankDetailRepository.GetBankDetailsByProgramId(progId);
        }

        #endregion
    }
}
