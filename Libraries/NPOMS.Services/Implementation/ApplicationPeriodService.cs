using NPOMS.Domain.Entities;
using NPOMS.Domain.Enumerations;
using NPOMS.Repository.Interfaces.Core;
using NPOMS.Repository.Interfaces.Entities;
using NPOMS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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

		public async Task<IEnumerable<ApplicationPeriod>> Get(string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);
			var results = await _applicationPeriodRepository.GetEntities();

			//not supporting multiple departments
			if (!loggedInUser.Departments[0].DepartmentId.Equals((int)DepartmentEnum.ALL))
			{
				if (loggedInUser.Roles.Any(x => !x.RoleId.Equals((int)RoleEnum.Applicant)))
					results = results.Where(x => x.DepartmentId.Equals(loggedInUser.Departments[0].DepartmentId));
			}

			return results;
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

			await _applicationPeriodRepository.UpdateEntity(model, loggedInUser.Id);
		}

		#endregion
	}
}
