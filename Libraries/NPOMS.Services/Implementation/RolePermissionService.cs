using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NPOMS.Domain.Core;
using NPOMS.Domain.Enumerations;
using NPOMS.Domain.Mapping;
using NPOMS.Domain.ResourceParameters;
using NPOMS.Repository.Implementation.Core;
using NPOMS.Repository.Interfaces.Core;
using NPOMS.Repository.Interfaces.Mapping;
using NPOMS.Services.Helpers.Paging;
using NPOMS.Services.Interfaces;
using NPOMS.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPOMS.Services.Implementation
{
	public class RolePermissionService : IRolePermissionService
	{
		private IPermissionRepository _permissionRepository;
		private IRoleRepository _roleRepository;
		private IRolePermissionRepository _rolePermissionRepository;
		private IMapper _mapper;
		private ILogger<RolePermissionService> _logger;
		private IUserRepository _userRepository;
		private IDepartmentRepository _departmentRepository;


        public RolePermissionService(
			IMapper mapper,
			ILogger<RolePermissionService> logger,
			IPermissionRepository permissionRepository,
			IRoleRepository roleRepository,
			IRolePermissionRepository rolePermissionRepository,
			IUserRepository userRepository,
            IDepartmentRepository departmentRepository)
		{
			this._mapper = mapper;
			this._logger = logger;
			this._permissionRepository = permissionRepository;
			this._roleRepository = roleRepository;
			this._rolePermissionRepository = rolePermissionRepository;
			this._userRepository = userRepository;
			this._departmentRepository = departmentRepository;

        }

        public async Task<RolePermissionsMatrix> GetMatrix(string userIdentifier)
        {
            try
            {
                // Retrieve the logged-in user details
                var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

                if (loggedInUser == null)
                {
                    // Log and handle the case where the user is not found
                    _logger.LogWarning($"User with identifier {userIdentifier} not found.");
                    return null; // Handle appropriately based on your application's requirements
                }

                // Retrieve department IDs for the logged-in user
                var departmentIds = await _departmentRepository.GetDepartmentIdOfLogggedInUserAsync(loggedInUser.Id);

                if (departmentIds == null || !departmentIds.Any())
                {
                    // Log a warning if no departments are found for the user
                    _logger.LogWarning($"No departments found for user {loggedInUser.Id}.");
                    return null; // Handle appropriately based on your application's requirements
                }

                // Retrieve role IDs by department IDs
                var rolesByDepartment = await _roleRepository.GetRoleIdsByDepartmentIdsAsync(departmentIds);

                // Retrieve all roles (consider making this asynchronous if it's a database call)
                var roles = _roleRepository.GetRoles();

                // Initialize the role permissions matrix
                var matrix = new RolePermissionsMatrix(this._mapper);

                // Retrieve and order permissions asynchronously
                var permissions = await this._permissionRepository.GetEntities()
                                                                  .OrderBy(o => o.CategoryName)
                                                                  .ThenBy(o => o.Name)
                                                                  .ToListAsync();

                // Check if the logged-in user has the SystemAdmin role
                if (loggedInUser.Roles.Any(x => x.IsActive && (x.RoleId.Equals((int)RoleEnum.SystemAdmin))))
                {
                    matrix.Init(permissions, roles.ToList());
                }
                else
                {
                    matrix.Init(permissions, rolesByDepartment.ToList());
                }

                return matrix;
            }
            catch (Exception ex)
            {
                // Log the exception with detailed information
                _logger.LogError(ex, "Error occurred in GetMatrix method.");
                throw; // Re-throw the exception to be handled by the caller or middleware
            }
        }

        public async Task CreateMapping(int permissionId, int roleId)
		{
			var mapping = await this._rolePermissionRepository.GetByIds(permissionId, roleId);

			if (mapping == null)
			{
				RolePermission entity = new RolePermission() { PermissionId = permissionId, RoleId = roleId };
				await this._rolePermissionRepository.CreateEntity(entity);
			}
		}

		public async Task DeleteMapping(int permissionId, int roleId)
		{
			var mapping = await this._rolePermissionRepository.GetByIds(permissionId, roleId);

			if (mapping != null)
			{
				await this._rolePermissionRepository.DeleteEntity(mapping);
			}
		}

		public async Task Create(PermissionViewModel viewModel)
		{
			try
			{
				if (viewModel == null)
					throw new ArgumentNullException(nameof(viewModel));

				var entity = new Permission()
				{
					CategoryName = viewModel.CategoryName,
					IsActive = viewModel.IsActive,
					Name = viewModel.Name,
					SystemName = viewModel.SystemName
				};

				await _permissionRepository.CreateEntity(entity);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside CreateFeaturePermission action: {ex.Message} Inner Exception: { ex.InnerException}");
				throw;
			}
		}

		public async Task<PagedList<Permission>> GetAll(PermissionResourceParameters permissionResourceParameters)
		{
			try
			{
				if (permissionResourceParameters == null)
				{
					throw new ArgumentNullException(nameof(permissionResourceParameters));
				}

				var query = _permissionRepository.GetEntities();
				var pageList = await PagedList<Permission>.Create(query, permissionResourceParameters.PageNumber, permissionResourceParameters.PageSize);

				return pageList;
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside GetAllFeaturePermissions action: {ex.Message} Inner Exception: { ex.InnerException}");
				throw;
			}
		}

		public async Task<PermissionViewModel> GetById(int permissionId)
		{
			try
			{
				var featurePermission = await _permissionRepository.GetById(permissionId);

				if (featurePermission == null)
				{
					throw new ArgumentNullException(nameof(featurePermission));
				}

				return _mapper.Map<PermissionViewModel>(featurePermission);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside GetById action: {ex.Message} Inner Exception: { ex.InnerException}");
				throw;
			}
		}

		public async Task Update(PermissionViewModel viewModel, string userIdentifier)
		{
			try
			{
				var loggedInUser = await _userRepository.GetByUserNameWithDetails(userIdentifier);

				if (viewModel == null)
					throw new ArgumentNullException(nameof(viewModel));

				var entity = await _permissionRepository.GetById(viewModel.Id);

				if (entity != null)
				{
					entity.CategoryName = viewModel.CategoryName;
					entity.IsActive = viewModel.IsActive;
					entity.Name = viewModel.Name;
					entity.SystemName = viewModel.SystemName;

					await _permissionRepository.UpdateEntity(entity, loggedInUser.Id);
				}
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside UpdateFeaturePermission action: {ex.Message} Inner Exception: { ex.InnerException}");
				throw;
			}
		}

		public async Task Delete(PermissionViewModel viewModel)
		{
			try
			{
				if (viewModel == null)
					throw new ArgumentNullException(nameof(viewModel));

				var entity = await _permissionRepository.GetById(viewModel.Id);

				if (entity != null)
				{
					await _permissionRepository.DeleteEntity(entity);
				}
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong inside DeleteFeaturePermission action: {ex.Message} Inner Exception: { ex.InnerException}");
				throw;
			}
		}
        
    }
}
