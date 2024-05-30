using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Core;
using NPOMS.Repository.Interfaces.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Core
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        #region Constructors

        public UserRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

        #endregion

        #region Methods

        public async Task<User> GetById(int id)
        {
            return await FindByCondition(sp => sp.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task<User> GetActiveUserById(int id)
        {
            return await FindByCondition(sp => sp.Id.Equals(id) && sp.IsActive).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<User>> GetEntities()
        {
            return await FindAll().AsNoTracking()
                .Include(x => x.Roles.Where(y => y.IsActive)).ThenInclude(x => x.Role)
                .Include(x => x.Departments).ThenInclude(x => x.Department)
                //.Include(x => x.UserPrograms).ThenInclude(x => x.Program)
                .OrderBy(ow => ow.UserName).ToListAsync();
        }

        public IEnumerable<User> GetUsers()
        {
            return FindAll().AsNoTracking().Where(x => x.IsActive).OrderBy(ow => ow.UserName).ToList();
        }

        public async Task CreateEntity(User user)
        {
            await CreateAsync(user);
        }
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await FindAll().AsNoTracking()
                .Include(x => x.Roles).ThenInclude(x => x.Role)
                .OrderBy(ow => ow.UserName).ToListAsync();
        }
        public async Task UpdateEntity(User user, int currentUserId)
        {
            var oldEntity = await this.RepositoryContext.Users.FindAsync(user.Id);
            await UpdateAsync(oldEntity, user, true, currentUserId);
        }

        public async Task DeleteEntity(User user, int currentUserId)
        {
            var oldEntity = await this.RepositoryContext.Users.FindAsync(user.Id);
            await UpdateAsync(oldEntity, user, true, currentUserId);
        }

        public async Task<User> GetByIdWithDetails(int id)
        {
            return await FindByCondition(sp => sp.Id.Equals(id))
                            .Include(x => x.Roles)
                                .ThenInclude(x => x.Role)
                            .Include(x => x.Departments)
                                .ThenInclude(x => x.Department)
                             //.Include(x => x.UserPrograms)
                             //   .ThenInclude(x => x.Program)
                            .FirstOrDefaultAsync();
        }

        public async Task<User> GetUserByUserNameWithDetailsAsync(string userName)
        {
            return await FindByCondition(sp => sp.UserName.Equals(userName))
                                        .Include(x => x.Roles)
                                            .ThenInclude(x => x.Role)
                                                .ThenInclude(x => x.Permissions)
                                                    .ThenInclude(x => x.Permission)
                                        .FirstOrDefaultAsync();
        }
        public async Task<User> GetByUserNameWithDetails(string userName)
        {
            return await FindByCondition(sp => sp.UserName.Equals(userName))
                            .Include(x => x.Roles)
                                .ThenInclude(x => x.Role)
                                    .ThenInclude(x => x.Permissions)
                                        .ThenInclude(x => x.Permission)
                            .Include(x => x.Departments)
                                .ThenInclude(x => x.Department)
                                    //.Include(x => x.UserPrograms)
                                    //    .ThenInclude(x => x.Program)
                            .FirstOrDefaultAsync();
        }

        public async Task<User> GetByUserName(string userName)
        {
            try
            {
                return await FindByCondition(sp => sp.UserName.Equals(userName))
                        .Include(x => x.Roles.Where(y => y.IsActive))
                            .ThenInclude(x => x.Role)
                                .ThenInclude(x => x.Permissions)
                                    .ThenInclude(x => x.Permission)
                        .Include(x => x.Departments)
                            .ThenInclude(x => x.Department)
                        //.Include(x => x.UserPrograms)
                        //    .ThenInclude(x => x.Program)
                        .FirstOrDefaultAsync();
            }
            catch(Exception ex)
            {

            }
            return null;
        }

        public async Task<IEnumerable<User>> GetByIds(int roleId, int departmentId)
        {
            return await FindByCondition(x => x.Roles.Where(z => z.IsActive).Any(y => y.RoleId.Equals(roleId)) &&
                                              x.Departments.Any(y => y.DepartmentId.Equals(departmentId)))
                            .Where(x => x.IsActive).ToListAsync();
        }

        public async Task<IEnumerable<User>> GetByRoleId(int roleId)
        {
            return await FindByCondition(x => x.Roles.Where(z => z.IsActive).Any(y => y.RoleId.Equals(roleId)))
                            .Where(x => x.IsActive).ToListAsync();
        }

        public async Task<IEnumerable<User>> GetByRoleAndDepartmentId(int roleId, int departmentId)
        {
            return await FindByCondition(x => x.Roles.Where(z => z.IsActive).Any(y => y.RoleId.Equals(roleId)) && x.Departments.Any(y => y.DepartmentId.Equals(departmentId)))
                            .Include(x=>x.Roles)
                            .Include(x=>x.Departments)
                            .Where(x => x.IsActive).ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await FindByCondition(sp => sp.Id.Equals(id))
                .FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<User>> GetByUserIds(List<int> userIds)
        {
            return await FindByCondition(x => userIds.Contains(x.Id) && x.IsActive).AsNoTracking().ToListAsync();
        }
        public async Task<IEnumerable<User>> GetUsersByRoleId(int roleId)
        {
            return await FindByCondition(x => x.Roles.Any(x => x.RoleId.Equals(roleId))).AsNoTracking().ToListAsync();
        }

        #endregion
    }
}
