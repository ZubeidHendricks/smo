﻿using NPOMS.Services.Interfaces;

using Microsoft.Graph.Auth;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NPOMS.Services.Models;
using AutoMapper;
using NPOMS.Services.Extensions;
using NPOMS.Repository.Interfaces.Core;
using NPOMS.Repository.Interfaces.Mapping;
using NPOMS.Repository.Interfaces.Entities;
using NPOMS.Domain.Core;
using NPOMS.Domain.Mapping;
using NPOMS.Domain.Enumerations;
using NPOMS.Repository;

namespace NPOMS.Services.Implementation
{
	public class UserService : IUserService
	{
		#region Fields

		private IMapper _mapper;
		private GeneralConfiguration _generalConfiguration;
		private MSGraphConfiguration _msGraphConfiguration;
		private IUserRepository _userRepository;
		private IUserRoleRepository _userRoleRepository;
		private IRoleRepository _roleRepository;
		private IDepartmentRepository _departmentRepository;
		private IUserNpoRepository _userNpoRepository;
		private INpoRepository _npoRepository;

		private RepositoryContext _repositoryContext;

		#endregion

		#region Constructors

		public UserService(
			IMapper mapper,
			GeneralConfiguration generalConfiguration,
			MSGraphConfiguration msGraphConfiguration,
			IUserRepository userRepository,
			IUserRoleRepository userRoleRepository,
			IRoleRepository roleRepository,
			IDepartmentRepository departmentRepository,
			IUserNpoRepository userNpoRepository,
			INpoRepository npoRepository,
			RepositoryContext repositoryContext
			)
		{
			_mapper = mapper;
			_generalConfiguration = generalConfiguration;
			_msGraphConfiguration = msGraphConfiguration;
			_userRepository = userRepository;
			_userRoleRepository = userRoleRepository;
			_roleRepository = roleRepository;
			_departmentRepository = departmentRepository;
			_userNpoRepository = userNpoRepository;
			_npoRepository = npoRepository;
			_repositoryContext = repositoryContext;
		}

		#endregion

		#region Methods

		public async Task<List<UserViewModel>> GetAll()
		{
			List<UserViewModel> viewModel = new List<UserViewModel>();
			var users = await _userRepository.GetEntities();

			foreach (var user in users)
			{
				var userViewModel = _mapper.Map<UserViewModel>(user);
				userViewModel.Roles.AddRange(
						_mapper.Map<List<RoleViewModel>>(
							user.Roles.Select(x => x.Role)));

				userViewModel.Departments.AddRange(
					_mapper.Map<List<DepartmentViewModel>>(
						user.Departments.Select(x => x.Department)));

				viewModel.Add(userViewModel);
			}

			return viewModel;
		}

		public async Task<UserViewModel> Get(string userName, string givenName, string surname, bool autoCreateB2CUser = false)
		{
			var user = await _userRepository.GetByUserName(userName);

			//check if user is B2C and then create if not exist
			if (user == null && !IsValidWCGInternalDomain(userName) && autoCreateB2CUser)
				user = await CreateB2CUser(userName, givenName, surname);

			// Get user with all updated details
			user = await _userRepository.GetByUserName(userName);

			await CreateNpoUserMappings(user);

			var viewModel = _mapper.Map<UserViewModel>(user);

			if (user != null)
			{
				var roles = user.Roles.Select(r => r.Role);
				viewModel.Roles = _mapper.Map<List<RoleViewModel>>(roles);

				var departments = user.Departments.Select(r => r.Department);
				viewModel.Departments = _mapper.Map<List<DepartmentViewModel>>(departments);

				var mappings = await _userNpoRepository.GetApprovedEntities(user.Id);
				viewModel.UserNpos = _mapper.Map<List<UserNpoViewModel>>(mappings);
			}

			viewModel.Permissions = GetPermissions(user);

			return viewModel;
		}

		public async Task<List<UserViewModel>> Search(string searchTerm)
		{
			List<UserViewModel> accounts = new List<UserViewModel>();

			// Initialize the client credential auth provider
			IConfidentialClientApplication confidentialClientApplication = ConfidentialClientApplicationBuilder
				.Create(_msGraphConfiguration.ClientId)
				.WithTenantId(_msGraphConfiguration.TenantId)
				.WithClientSecret(_msGraphConfiguration.Secret)
				.Build();

			ClientCredentialProvider authProvider = new ClientCredentialProvider(confidentialClientApplication);

			// Set up the Microsoft Graph service client with client credentials
			var graphClient = new Microsoft.Graph.GraphServiceClient(authProvider);

			var users = await graphClient.Users.Request().Filter($"startsWith(displayName, '{searchTerm}')").GetAsync();

			foreach (var user in users)
			{
				var userName = user.OnPremisesSamAccountName ?? user.UserPrincipalName;

				if (IsValidWCGInternalDomain(userName))
				{
					UserViewModel account = new UserViewModel()
					{
						FirstName = user.GivenName,
						LastName = user.Surname,
						Email = user.Mail,
						FullName = $"{user.DisplayName} ({user.OnPremisesSamAccountName ?? user.UserPrincipalName})",
						UserName = user.OnPremisesSamAccountName ?? user.UserPrincipalName
					};

					if (accounts.Count < 25)
					{
						accounts.Add(account);
					}
					else
					{
						continue;
					}
				}
			}

			return accounts;
		}

		public async Task<UserViewModel> Create(UserViewModel user, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);
			var newUser = await _userRepository.GetByUserNameWithDetails(user.UserName);
			var roles = await _roleRepository.GetEntities(false);
			var departments = await _departmentRepository.GetEntities(false);

			if (newUser != null)
			{
				throw new Exception($"{user.UserName} already exists");
			}

			newUser = _mapper.Map<User>(user);
			newUser.IsB2C = false;
			newUser.IsActive = user.IsActive;
			newUser = _mapper.Map<User>(user);
			newUser.CreatedUserId = loggedInUser.Id;
			newUser.CreatedDateTime = DateTime.Now;
			newUser.UpdatedUserId = null;
			newUser.UpdatedDateTime = null;
			newUser.Roles = new List<UserRole>();
			newUser.Departments = new List<UserDepartment>();

			foreach (var role in user.Roles)
			{
				if (roles.Any(r => r.Id == role.Id))
				{
					newUser.Roles.Add(new UserRole() { RoleId = role.Id, IsActive = user.IsActive });
				}
			}

			foreach (var department in user.Departments)
			{
				if (departments.Any(d => d.Id == department.Id))
				{
					newUser.Departments.Add(new UserDepartment() { DepartmentId = department.Id });
				}
			}

			await _userRepository.CreateAsync(newUser);
			user = _mapper.Map<UserViewModel>(newUser);

			return user;
		}

		public async Task<UserViewModel> Update(UserViewModel user, string userIdentifier)
		{
			var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);
			var existingUser = await _userRepository.GetByUserNameWithDetails(user.UserName);

			if (existingUser == null)
			{
				throw new Exception($"{user.UserName} does not exists");
			}

			existingUser.IsActive = user.IsActive;
			existingUser.UpdatedUserId = loggedInUser.Id;
			existingUser.UpdatedDateTime = DateTime.Now;

			//not supporting multiple departments
			existingUser.Departments.FirstOrDefault().DepartmentId = user.Departments.FirstOrDefault().Id;
			existingUser.Departments.FirstOrDefault().Department = null;

			await UpdateUserRoles(user, existingUser);
			var oldEntity = await this._repositoryContext.Users.FindAsync(user.Id);
			await _userRepository.UpdateAsync(oldEntity, existingUser, true);
			return _mapper.Map<UserViewModel>(existingUser);
		}

		private async Task UpdateUserRoles(UserViewModel user, User existingUser)
		{
			foreach (var role in user.Roles)
			{
				var userRole = await _userRoleRepository.GetByUserIdAndRoleId(existingUser.Id, role.Id);

				if (userRole == null)
					existingUser.Roles.Add(new UserRole { UserId = existingUser.Id, RoleId = role.Id, IsActive = true });
			}

			var newRoleIds = user.Roles.Select(x => x.Id);

			foreach (var userRole in existingUser.Roles)
			{
				if (newRoleIds.Contains(userRole.RoleId))
					userRole.IsActive = true;
				else
					userRole.IsActive = false;

				userRole.Role = null;
			}
		}

		public async Task Delete(UserViewModel user, string userIdentifier)
		{
			throw new NotImplementedException();
		}

		public async Task<User> CreateB2CUser(string userName, string firstName, string lastName)
		{
			//todo: changed the default role for B2C user
			var role = _roleRepository.FindByCondition(x => x.SystemName == "Applicant").First();
			var department = _departmentRepository.FindByCondition(x => x.Abbreviation == "NONE").First();

			if (role == null || department == null)
				throw new Exception("The role and/or department doesn't exists");

			var systemUser = await _userRepository.GetByUserNameWithDetails("npoms.admin@westerncape.gov.za");

			var newUser = new User()
			{
				UserName = userName,
				Email = userName,
				FirstName = firstName,
				LastName = lastName,
				IsB2C = true,
				IsActive = true,
				CreatedDateTime = DateTime.Now,
				CreatedUserId = systemUser.Id
			};

			List<UserRole> userRoles = new List<UserRole>();
			userRoles.Add(new UserRole() { RoleId = role.Id, IsActive = true });
			newUser.Roles = userRoles;

			List<UserDepartment> userDepartments = new List<UserDepartment>();
			userDepartments.Add(new UserDepartment() { DepartmentId = department.Id }); ;
			newUser.Departments = userDepartments;

			await _userRepository.CreateEntity(newUser);

			return newUser;
		}

		private async Task CreateNpoUserMappings(User user)
		{
			var assignedNpos = await _npoRepository.GetAssignedEntities(user.Email);
			var existingMappings = await _userNpoRepository.GetByCurrentUserId(user.Id);
			var existingNpoIds = existingMappings.Select(x => x.NpoId);

			foreach (var npo in assignedNpos)
			{
				if (!existingNpoIds.Contains(npo.Id))
				{
					var systemUser = await _userRepository.GetByUserNameWithDetails("npoms.admin@westerncape.gov.za");

					var model = new UserNpo()
					{
						NpoId = npo.Id,
						UserId = user.Id,
						CreatedUserId = npo.IsNew ? npo.CreatedUserId : Convert.ToInt32(npo.UpdatedUserId),
						CreatedDateTime = npo.IsNew ? npo.CreatedDateTime : Convert.ToDateTime(npo.UpdatedDateTime),
						UpdatedUserId = systemUser.Id,
						UpdatedDateTime = DateTime.Now,
						AccessStatusId = (int)AccessStatusEnum.Approved
					};

					await _userNpoRepository.CreateEntity(model);
				}
			}
		}

		private List<PermissionViewModel> GetPermissions(User user)
		{
			List<PermissionViewModel> permissions = new List<PermissionViewModel>();

			foreach (var role in user.Roles.Select(x => x.Role))
			{
				foreach (var permission in role.Permissions.Select(x => x.Permission))
				{
					if (!permissions.Any(x => x.Id == permission.Id))
					{
						permissions.Add(_mapper.Map<PermissionViewModel>(permission));
					}
				}
			}
			return permissions;
		}

		private bool IsValidWCGInternalDomain(string username)
		{
			//only get @westerncape.gov.za users for now, but making provision for extending the list
			bool isValid = false;
			var validDomains = this._generalConfiguration.ValidWCGInternalEmailDomains;
			string domain = "";

			var emailAddressParts = username.Split('@');
			if (emailAddressParts.Length == 2)
			{
				isValid = true;

				domain = $"@{emailAddressParts[1]}";

				isValid = validDomains.Contains(domain);
			}

			return isValid;
		}

		#endregion
	}
}
