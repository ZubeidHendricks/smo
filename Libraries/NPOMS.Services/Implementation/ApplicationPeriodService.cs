using NPOMS.Domain.Entities;
using NPOMS.Repository.Interfaces.Core;
using NPOMS.Repository.Interfaces.Entities;
using NPOMS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Services.Implementation
{
	public class ApplicationPeriodService : IApplicationPeriodService
	{
		#region Fields

		private IApplicationPeriodRepository _applicationPeriodRepository;
		private IUserRepository _userRepository;

		#endregion

		#region Constructorrs

		public ApplicationPeriodService(
			IApplicationPeriodRepository applicationPeriodRepository,
			IUserRepository userRepository
			)
		{
			_applicationPeriodRepository = applicationPeriodRepository;
			_userRepository = userRepository;
		}

		#endregion

		#region Methods

		public async Task<IEnumerable<ApplicationPeriod>> Get()
		{
			return await _applicationPeriodRepository.GetEntities();
		}

		public async Task<ApplicationPeriod> GetById(int id)
		{
			return await _applicationPeriodRepository.GetById(id);
		}

		public async Task Create(ApplicationPeriod model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.CreatedUserId = loggedInUser.Id;
			model.CreatedDateTime = DateTime.Now;

			await _applicationPeriodRepository.CreateEntity(model);
		}

		public async Task Update(ApplicationPeriod model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.UpdatedUserId = loggedInUser.Id;
			model.UpdatedDateTime = DateTime.Now;

			await _applicationPeriodRepository.UpdateEntity(model);
		}

		#endregion
	}
}
