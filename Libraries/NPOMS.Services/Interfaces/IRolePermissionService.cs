using NPOMS.Domain.Core;
using NPOMS.Domain.ResourceParameters;
using NPOMS.Services.Helpers.Paging;
using NPOMS.Services.Models;
using System.Threading.Tasks;

namespace NPOMS.Services.Interfaces
{
	public interface IRolePermissionService
	{
		RolePermissionsMatrix GetMatrix();

		Task CreateMapping(int permissionId, int roleId);

		Task DeleteMapping(int permissionId, int roleId);

		Task Create(PermissionViewModel viewModel);

		Task<PagedList<Permission>> GetAll(PermissionResourceParameters permissionResourceParameters);

		Task<PermissionViewModel> GetById(int permissionId);

		Task Update(PermissionViewModel viewModel, string userIdentifier);

		Task Delete(PermissionViewModel viewModel);
	}
}
