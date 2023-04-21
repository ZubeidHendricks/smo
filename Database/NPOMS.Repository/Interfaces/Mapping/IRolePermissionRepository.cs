using NPOMS.Domain.Mapping;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Mapping
{
	public interface IRolePermissionRepository : IBaseRepository<RolePermission>
	{
		Task<RolePermission> GetByIds(int permissionId, int roleId);

		Task<IEnumerable<RolePermission>> GetByPermissionId(int permissionId);

		Task CreateEntity(RolePermission entity);

		Task UpdateEntity(RolePermission entity, int currentUserId);

		Task DeleteEntity(RolePermission entity);
	}
}
