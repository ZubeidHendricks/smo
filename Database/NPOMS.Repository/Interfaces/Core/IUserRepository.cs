using NPOMS.Domain.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Core
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetById(int id);
        Task<User> GetUserByIdAsync(int id);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetActiveUserById(int id);

        Task<IEnumerable<User>> GetEntities();

        IEnumerable<User> GetUsers();

        Task CreateEntity(User user);

        Task UpdateEntity(User user, int currentUserId);

        Task DeleteEntity(User user, int currentUserId);

        Task<User> GetByIdWithDetails(int id);

        Task<User> GetByUserNameWithDetails(string userName);
        Task<User> GetUserByUserNameWithDetailsAsync(string userName);
        Task<User> GetByUserName(string userName);

        Task<IEnumerable<User>> GetByIds(int roleId, int departmentId);

        Task<IEnumerable<User>> GetByRoleId(int roleId);
        Task<IEnumerable<User>> GetByRoleAndDepartmentId(int roleId, int departmentId);

        /// <summary>
        /// Get Users by UserIds
        /// </summary>
        /// <param name="roleIds"></param>
        /// <returns></returns>
        Task<IEnumerable<User>> GetByUserIds(List<int> userIds);
        Task<IEnumerable<User>> GetUsersByRoleId(int roleId);
    }
}
