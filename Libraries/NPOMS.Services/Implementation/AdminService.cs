using NPOMS.Domain.Entities;
using NPOMS.Repository.Interfaces.Core;
using NPOMS.Repository.Interfaces.Entities;
using NPOMS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Services.Implementation
{
	public class AdminService : IAdminService
	{
		#region Fields

		private ICompliantCycleRepository _compliantCycleRepository;
		private IPaymentScheduleRepository _paymentScheduleRepository;
		private IUserRepository _userRepository;

		#endregion

		#region Constructors

		public AdminService(
			ICompliantCycleRepository compliantCycleRepository,
			IPaymentScheduleRepository paymentScheduleRepository,
			IUserRepository userRepository
			)
		{
			_compliantCycleRepository = compliantCycleRepository;
			_paymentScheduleRepository = paymentScheduleRepository;
			_userRepository = userRepository;
		}

		#endregion

		#region Methods

		public async Task<IEnumerable<CompliantCycle>> GetCompliantCyclesByIds(int departmentId, int financialYearId)
		{
			return await _compliantCycleRepository.GetCompliantCyclesByIds(departmentId, financialYearId);
		}

		public async Task Create(CompliantCycle model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.CreatedUserId = loggedInUser.Id;
			model.CreatedDateTime = DateTime.Now;

			await _compliantCycleRepository.CreateAsync(model);
		}

		public async Task Update(CompliantCycle model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.UpdatedUserId = loggedInUser.Id;
			model.UpdatedDateTime = DateTime.Now;

			await _compliantCycleRepository.UpdateAsync(model);
		}

		public async Task<IEnumerable<PaymentSchedule>> GetPaymentSchedulesByIds(int departmentId, int financialYearId)
		{
			return await _paymentScheduleRepository.GetPaymentSchedulesByIds(departmentId, financialYearId);
		}

		public async Task Create(PaymentSchedule model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.CreatedUserId = loggedInUser.Id;
			model.CreatedDateTime = DateTime.Now;

			await _paymentScheduleRepository.CreateAsync(model);
		}

		public async Task Update(PaymentSchedule model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.UpdatedUserId = loggedInUser.Id;
			model.UpdatedDateTime = DateTime.Now;

			await _paymentScheduleRepository.UpdateAsync(model);
		}

		#endregion
	}
}
