using NPOMS.Domain.Budget;
using NPOMS.Repository;
using NPOMS.Repository.Interfaces.Budget;
using NPOMS.Repository.Interfaces.Core;
using NPOMS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Services.Implementation
{
	public class BudgetService : IBudgetService
	{
		#region Fields

		private IDepartmentBudgetRepository _departmentBudgetRepository;
		private IUserRepository _userRepository;
		private IDirectorateBudgetRepository _directorateBudgetRepository;
		private IProgrammeBudgetRepository _programmeBudgetRepository;

		private RepositoryContext _repositoryContext;

		#endregion

		#region Constructors

		public BudgetService(
			IDepartmentBudgetRepository departmentBudgetRepository,
			IUserRepository userRepository,
			IDirectorateBudgetRepository directorateBudgetRepository,
			IProgrammeBudgetRepository programmeBudgetRepository,
			RepositoryContext repositoryContext)
		{
			_departmentBudgetRepository = departmentBudgetRepository;
			_userRepository = userRepository;
			_directorateBudgetRepository = directorateBudgetRepository;
			_programmeBudgetRepository = programmeBudgetRepository;
			_repositoryContext = repositoryContext;
		}

		#endregion

		#region Methods

		public async Task<IEnumerable<DepartmentBudget>> GetDepartmentBudgetsByIds(int departmentId, int financialYearId)
		{
			return await _departmentBudgetRepository.GetDepartmentBudgetsByIds(departmentId, financialYearId);
		}

		public async Task Create(DepartmentBudget model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.CreatedUserId = loggedInUser.Id;
			model.CreatedDateTime = DateTime.Now;

			await _departmentBudgetRepository.CreateAsync(model);
		}

		public async Task Update(DepartmentBudget model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.UpdatedUserId = loggedInUser.Id;
			model.UpdatedDateTime = DateTime.Now;

			var oldEntity = await this._repositoryContext.DepartmentBudgets.FindAsync(model.Id);
			await _departmentBudgetRepository.UpdateAsync(oldEntity, model, true, loggedInUser.Id);
		}

		public async Task<IEnumerable<DirectorateBudget>> GetDirectorateBudgetsByIds(int departmentId, int financialYearId)
		{
			return await _directorateBudgetRepository.GetDirectorateBudgetsByIds(departmentId, financialYearId);
		}

		public async Task Create(DirectorateBudget model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.CreatedUserId = loggedInUser.Id;
			model.CreatedDateTime = DateTime.Now;

			await _directorateBudgetRepository.CreateAsync(model);
		}

		public async Task Update(DirectorateBudget model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.UpdatedUserId = loggedInUser.Id;
			model.UpdatedDateTime = DateTime.Now;

			var oldEntity = await this._repositoryContext.DirectorateBudgets.FindAsync(model.Id);
			await _directorateBudgetRepository.UpdateAsync(oldEntity, model, true, loggedInUser.Id);
		}

		public async Task<IEnumerable<ProgrammeBudget>> GetProgrammeBudgetsByIds(int departmentId, int financialYearId)
		{
			return await _programmeBudgetRepository.GetProgrammeBudgetsByIds(departmentId, financialYearId);
		}

		public async Task<ProgrammeBudget> GetProgrammeBudgetByProgrammeId(int programmeId, int financialYearId)
		{
			return await _programmeBudgetRepository.GetProgrammeBudgetByProgrammeId(programmeId, financialYearId);
		}

		public async Task Create(ProgrammeBudget model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.CreatedUserId = loggedInUser.Id;
			model.CreatedDateTime = DateTime.Now;

			await _programmeBudgetRepository.CreateAsync(model);
		}

		public async Task Update(ProgrammeBudget model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.UpdatedUserId = loggedInUser.Id;
			model.UpdatedDateTime = DateTime.Now;

			var oldEntity = await this._repositoryContext.ProgrammeBudgets.FindAsync(model.Id);
			await _programmeBudgetRepository.UpdateAsync(oldEntity, model, true, loggedInUser.Id);
		}

		#endregion
	}
}
