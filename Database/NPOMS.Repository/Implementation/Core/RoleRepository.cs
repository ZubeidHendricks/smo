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
		#region Constructors

		public RoleRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{

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
			 .OrderBy(ow => ow.Id).ToList();
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
        #endregion
    }
}
