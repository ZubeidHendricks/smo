using NPOMS.Domain.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Core
{
	public interface IUserRepository : IBaseRepository<User>
	{
		Task<User> GetById(int id);

		Task<IEnumerable<User>> GetEntities();

		IEnumerable<User> GetUsers();

		Task CreateEntity(User user);

		Task UpdateEntity(User user);

		Task DeleteEntity(User user);

		Task<User> GetByIdWithDetails(int id);

		Task<User> GetByUserNameWithDetails(string userName);

		Task<User> GetByUserName(string userName);

		Task<IEnumerable<User>> GetByIds(int roleId, int departmentId);

		Task<IEnumerable<User>> GetByRoleId(int roleId);
	}
}
