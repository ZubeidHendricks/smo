using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NPOMS.Domain.ResourceParameters;
using NPOMS.Services.Interfaces;
using NPOMS.Services.Models;
using System;
using System.Threading.Tasks;

namespace NPOMS.API.Controllers
{
	[Route("api/role-permissions")]
	[ApiController]
	public class RolePermissionController : ExternalBaseController
    {
        #region Fields

        private ILogger<RolePermissionController> _logger;
        private IRolePermissionService _rolePermissionService;

        #endregion

        #region Constructors

        public RolePermissionController(
            ILogger<RolePermissionController> logger,
            IRolePermissionService rolePermissionService
            )
        {
            _logger = logger;
            this._rolePermissionService = rolePermissionService;
        }

        #endregion

        #region Methods

        [HttpGet(Name = "GetAllFeaturePermissions")]
        public async Task<IActionResult> GetAllFeaturePermissions([FromQuery] PermissionResourceParameters permissionResourceParameters)
        {
            try
            {
                var featurePermissions = await this._rolePermissionService.GetAll(permissionResourceParameters);
                //add paging header
                //Response.Headers.Add(base.GeneratePaginationHeader<Permission>(featurePermissions, permissionResourceParameters, "GetAllFeaturePermissions"));

                return Ok(featurePermissions);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllFeaturePermissions action: {ex.Message} Inner Exception: { ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("matrix", Name = "GetFeaturePermissionRoleMappings")]
        public IActionResult GetFeaturePermissionRoleMappings()
        {
            try
            {
                var featurePermissions = this._rolePermissionService.GetMatrix();
                return Ok(featurePermissions);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetFeaturePermissionRoleMappings action: {ex.Message} Inner Exception: { ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("matrix/permissions/{permissionId}/roles/{roleId}", Name = "DeleteFeaturePermissionRoleMapping")]
        public async Task<IActionResult> DeleteFeaturePermissionRoleMapping(int permissionId, int roleId)
        {
            try
            {
                await this._rolePermissionService.DeleteMapping(permissionId, roleId);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteFeaturePermissionRoleMapping action: {ex.Message} Inner Exception: { ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("matrix/permissions/{permissionId}/roles/{roleId}", Name = "CreateFeaturePermissionRoleMapping")]
        public async Task<IActionResult> CreateFeaturePermissionRoleMapping(int permissionId, int roleId)
        {
            try
            {
                await this._rolePermissionService.CreateMapping(permissionId, roleId);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateFeaturePermissionRoleMapping action: {ex.Message} Inner Exception: { ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{permissionId}")]
        public async Task<IActionResult> GetFeaturePermissionById(int permissionId)
        {
            try
            {
                var featurePermission = await this._rolePermissionService.GetById(permissionId);
                return Ok(featurePermission);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetFeaturePermissionById action: {ex.Message} Inner Exception: { ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost()]
        public async Task<IActionResult> CreateCreateFeaturePermission([FromBody] PermissionViewModel viewModel)
        {
            try
            {
                await this._rolePermissionService.Create(viewModel);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateCreateFeaturePermission action: {ex.Message} Inner Exception: { ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{permissionId}")]
        public async Task<IActionResult> UpdateFeaturePermission(int permissionId, [FromBody] PermissionViewModel viewModel)
        {
            try
            {
                await this._rolePermissionService.Update(viewModel, base.GetUserIdentifier());
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateFeaturePermission action: {ex.Message} Inner Exception: { ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete()]
        public async Task<IActionResult> DeleteFeaturePermission([FromBody] PermissionViewModel viewModel)
        {
            try
            {
                await this._rolePermissionService.Delete(viewModel);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteFeaturePermission action: {ex.Message} Inner Exception: { ex.InnerException}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        #endregion
    }
}
