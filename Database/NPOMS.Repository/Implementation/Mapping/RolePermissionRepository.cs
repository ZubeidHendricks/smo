using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Mapping;
using NPOMS.Repository.Interfaces.Mapping;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Mapping
{
	public class RolePermissionRepository : BaseRepository<RolePermission>, IRolePermissionRepository
	{
		#region Constructors

		public RolePermissionRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{

		}

		#endregion

		#region Methods

		public async Task<RolePermission> GetByIds(int permissionId, int roleId)
		{
			return await FindByCondition(x => x.PermissionId == permissionId && x.RoleId == roleId).FirstOrDefaultAsync();
		}

		public async Task CreateEntity(RolePermission entity)
		{
			await CreateAsync(entity);
		}

		public async Task UpdateEntity(RolePermission entity)
		{
			await UpdateAsync(entity);
		}

		public async Task DeleteEntity(RolePermission entity)
		{
			await DeleteAsync(entity);
		}

		#endregion
	}
}
