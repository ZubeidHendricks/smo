using NPOMS.Domain.Entities;
using NPOMS.Domain.Enumerations;
using NPOMS.Domain.Mapping;
using NPOMS.Repository.Interfaces.Core;
using NPOMS.Repository.Interfaces.Entities;
using NPOMS.Repository.Interfaces.Mapping;
using NPOMS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPOMS.Services.Implementation
{
	public class UserNpoService : IUserNpoService
	{
		#region Fields

		private IUserNpoRepository _userNpoRepository;
		private IUserRepository _userRepository;

		#endregion

		#region Constructorrs

		public UserNpoService(
			IUserNpoRepository userNpoRepository,
			IUserRepository userRepository
			)
		{
			_userNpoRepository = userNpoRepository;
			_userRepository = userRepository;
		}

		#endregion

		#region Methods

		public async Task Create(UserNpo model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);
			var mapping = await _userNpoRepository.GetByUserAndNpoId(loggedInUser.Id, model.NpoId);

			if (mapping == null)
			{
				model.UserId = loggedInUser.Id;
				model.CreatedUserId = loggedInUser.Id;
				model.CreatedDateTime = DateTime.Now;

				if (model.AccessStatusId == (int)AccessStatusEnum.Approved)
				{
					var systemUser = await _userRepository.GetByUserNameWithDetails("npoms.admin@westerncape.gov.za");
					model.UpdatedUserId = systemUser.Id;
					model.UpdatedDateTime = DateTime.Now;
				}

				await _userNpoRepository.CreateEntity(model);
			}
		}

		public async Task<IEnumerable<UserNpo>> Get(string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			if (loggedInUser.Roles.Any(x => x.IsActive && (x.RoleId.Equals((int)RoleEnum.SystemAdmin) || x.RoleId.Equals((int)RoleEnum.Admin))))
				return await _userNpoRepository.GetEntities();
			else
				return await _userNpoRepository.GetByCurrentUserId(loggedInUser.Id);
		}

		public async Task Update(UserNpo model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.UpdatedUserId = loggedInUser.Id;
			model.UpdatedDateTime = DateTime.Now;

			await _userNpoRepository.UpdateEntity(model, loggedInUser.Id);
		}

		/// <summary>
		/// Update an existing Access Request to appear as a new request.
		/// </summary>
		/// <param name="model"></param>
		/// <param name="userIdentifier"></param>
		/// <returns></returns>
		public async Task UpdateEntity(UserNpo model, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

			model.CreatedUserId = loggedInUser.Id;
			model.CreatedDateTime = DateTime.Now;
			model.AccessStatusId = (int)AccessStatusEnum.Pending;
			model.UpdatedUserId = null;
			model.UpdatedDateTime = null;
			await _userNpoRepository.UpdateEntity(model, loggedInUser.Id);
		}

		public async Task<UserNpo> GetByUserIdAndNpoId(int userId, int NpoId)
		{
			return await _userNpoRepository.GetByUserAndNpoId(userId, NpoId);
		}

		#endregion
	}
}
