using NPOMS.Domain.Entities;
using NPOMS.Domain.Enumerations;
using NPOMS.Repository.Implementation.Core;
using NPOMS.Repository.Implementation.Entities;
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
        private IDepartmentRepository _departmentRepository;
        private Repository.Interfaces.Dropdown.IProgrammeRepository _programmeRepository;

        #endregion

        #region Constructorrs

        public ApplicationPeriodService(
			IApplicationPeriodRepository applicationPeriodRepository,
			IUserRepository userRepository,
            IDepartmentRepository departmentRepository,
            Repository.Interfaces.Dropdown.IProgrammeRepository programmeRepository
			)
		{
			_applicationPeriodRepository = applicationPeriodRepository;
			_userRepository = userRepository;
            _departmentRepository = departmentRepository;
			_programmeRepository = programmeRepository;

        }

		#endregion

		#region Methods

		public async Task<IEnumerable<ApplicationPeriod>> Get(string userIdentifier)
		{

            var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);
            var results = await _applicationPeriodRepository.GetEntities();

            var departmentIds = await _departmentRepository.GetDepartmentIdOfLogggedInUserAsync(loggedInUser.Id);
            var programmesIds = await _programmeRepository.GetProgrammesIdOfLoggenInUserAsync(loggedInUser.Id);
            if (loggedInUser.Roles.Any(x => x.IsActive && (x.RoleId.Equals((int)RoleEnum.SystemAdmin))))
            {
                return results;
            }
            else
            {
				if (loggedInUser.Roles.Any(x => x.IsActive && (x.RoleId.Equals((int)RoleEnum.Applicant))))
				{
                    results = results.Where(x => x.CreatedUserId == loggedInUser.Id);
                }
				else {
                    results = results.Where(x => departmentIds.Contains(x.DepartmentId)
                    || programmesIds.Contains(x.ProgrammeId));
                }

                return results;
            }
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
