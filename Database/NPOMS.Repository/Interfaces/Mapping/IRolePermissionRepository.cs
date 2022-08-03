using NPOMS.Domain.Mapping;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Mapping
{
	public interface IRolePermissionRepository : IBaseRepository<RolePermission>
	{
		Task<RolePermission> GetByIds(int permissionId, int roleId);

		Task CreateEntity(RolePermission entity);

		Task UpdateEntity(RolePermission entity);

		Task DeleteEntity(RolePermission entity);
	}
}
