using NPOMS.Domain.Indicator;
using NPOMS.Repository.Interfaces.Core;
using NPOMS.Repository.Interfaces.Indicator;
using NPOMS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Services.Implementation
{
	public class IndicatorService : IIndicatorService
	{
		#region Fields

		private IWorkplanTargetRepository _workplanTargetRepository;
		private IUserRepository _userRepository;

		#endregion

		#region Constructors

		public IndicatorService(
			IWorkplanTargetRepository workplanTargetRepository,
			IUserRepository userRepository
			)
		{
			_workplanTargetRepository = workplanTargetRepository;
			_userRepository = userRepository;
		}

		#endregion

		#region Methods

		public async Task<IEnumerable<WorkplanTarget>> GetTargetsByActivityId(int activityId)
		{
			return await _workplanTargetRepository.GetByActivityId(activityId);
		}

		public async Task<WorkplanTarget> GetTargetByIds(WorkplanTarget model)
		{
			return await _workplanTargetRepository.GetByIds(model);
		}

		public async Task CreateTarget(WorkplanTarget model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.CreatedUserId = loggedInUser.Id;
			model.CreatedDateTime = DateTime.Now;

			await _workplanTargetRepository.CreateAsync(model);
		}

		public async Task UpdateTarget(WorkplanTarget model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.UpdatedUserId = loggedInUser.Id;
			model.UpdatedDateTime = DateTime.Now;

			await _workplanTargetRepository.UpdateAsync(model);
		}

		#endregion
	}
}
