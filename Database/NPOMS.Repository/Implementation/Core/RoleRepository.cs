using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Core;
using NPOMS.Domain.Dropdown;
using NPOMS.Repository.Interfaces.Core;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Core
{
	public class RoleRepository : BaseRepository<Role>, IRoleRepository
	{
        private IUserRepository _userRepository;
        private IDepartmentRepository _departmentRepository;
        #region Constructors

        public RoleRepository(RepositoryContext repositoryContext,
            IUserRepository userRepository,
            IDepartmentRepository departmentRepository)
			: base(repositoryContext)
		{
			_userRepository = userRepository;
			_departmentRepository = departmentRepository;

        }

		#endregion

		#region Methods

		public async Task<IEnumerable<Role>> GetEntities(bool returnInactive)
		{
			if (returnInactive)
			{
				return await FindAll()
								.AsNoTracking()
								.OrderBy(x => x.Name)
								.ToListAsync();
			}
			else
			{
				return await FindAll()
								.Where(x => x.IsActive)
								.AsNoTracking()
								.OrderBy(x => x.Name)
								.ToListAsync();
			}
		}

		public IEnumerable<Role> GetRoles()
		{
			return FindAll().AsNoTracking()
             .OrderBy(x => x.DepartmentCode)
                    .ThenBy(x => x.Id).ToList();
		}

        public async Task<IEnumerable<Role>> GetRolesByDepartment(string name, List<int> roleIds)
        {
            switch (name.ToLower())
            {
                default:
                    var query = FindAll()
                                .AsNoTracking();

                    if (roleIds != null && roleIds.Any())
                    {
                        query = query.Where(x => roleIds.Contains(x.Id));
                    }
					else
					{
                        return Enumerable.Empty<Role>();
                    }

                 
					return await query.OrderBy(x => x.Name).ToListAsync();

            }
        }

        public async Task<IEnumerable<Role>> GetRoleIdsByDepartmentIdsAsync(List<int> departmentIds)
        {
            // Retrieve distinct role IDs associated with the specified department IDs
            var roleIds = await RepositoryContext.DepartmentRoleMappings
                .Where(drm => departmentIds.Contains(drm.DepartmentId))
                .Select(drm => drm.RoleId)
                .Distinct()
                .ToListAsync();

            // Fetch role entities based on the retrieved role IDs
            var roles = await RepositoryContext.Roles
                .Where(role => roleIds.Contains(role.Id))
                .ToListAsync();

            // Convert List<Role> to IEnumerable<Role>
            return roles.AsEnumerable();
        }







        #endregion
    }
}
