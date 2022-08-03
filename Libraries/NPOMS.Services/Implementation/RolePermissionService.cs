using AutoMapper;
using Microsoft.Extensions.Logging;
using NPOMS.Domain.Core;
using NPOMS.Domain.Mapping;
using NPOMS.Domain.ResourceParameters;
using NPOMS.Repository.Interfaces.Core;
using NPOMS.Repository.Interfaces.Mapping;
using NPOMS.Services.Helpers.Paging;
using NPOMS.Services.Interfaces;
using NPOMS.Services.Models;
using System;
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

		public RolePermissionService(
			IMapper mapper,
			ILogger<RolePermissionService> logger,
			IPermissionRepository permissionRepository,
			IRoleRepository roleRepository,
			IRolePermissionRepository rolePermissionRepository
			)
		{
			this._mapper = mapper;
			this._logger = logger;
			this._permissionRepository = permissionRepository;
			this._roleRepository = roleRepository;
			this._rolePermissionRepository = rolePermissionRepository;
		}

		public RolePermissionsMatrix GetMatrix()
		{
			var permissions = this._permissionRepository.GetEntities()
										.OrderBy(o => o.CategoryName)
										.ThenBy(o => o.Name)
										.ToList();

			var roles = this._roleRepository.GetRoles();

			var matrix = new RolePermissionsMatrix(this._mapper);
			matrix.Init(permissions, roles.ToList());

			return matrix;
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

		public async Task Update(PermissionViewModel viewModel)
		{
			try
			{
				if (viewModel == null)
					throw new ArgumentNullException(nameof(viewModel));

				var entity = await _permissionRepository.GetById(viewModel.Id);

				if (entity != null)
				{
					entity.CategoryName = viewModel.CategoryName;
					entity.IsActive = viewModel.IsActive;
					entity.Name = viewModel.Name;
					entity.SystemName = viewModel.SystemName;

					await _permissionRepository.UpdateEntity(entity);
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
