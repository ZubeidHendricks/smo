using NPOMS.Domain.Mapping;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Mapping
{
	public interface IUserRoleRepository : IBaseRepository<UserRole>
	{
		Task<IEnumerable<UserRole>> GetEntities();

		IEnumerable<UserRole> GetUserRoles();

		Task<UserRole> GetByUserIdAndRoleId(int userId, int roleId);
	}
}
