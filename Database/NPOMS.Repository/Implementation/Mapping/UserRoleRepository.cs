using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Mapping;
using NPOMS.Repository.Interfaces.Mapping;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Mapping
{
	public class UserRoleRepository : BaseRepository<UserRole>, IUserRoleRepository
	{
		#region Constructors

		public UserRoleRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{

		}

		#endregion

		#region Methods

		public async Task<IEnumerable<UserRole>> GetEntities()
		{
			return await FindAll().AsNoTracking()
			   .OrderBy(ow => ow.Id).ToListAsync();
		}

		public IEnumerable<UserRole> GetUserRoles()
		{
			return FindAll().AsNoTracking()
			   .OrderBy(ow => ow.Id).ToList();
		}

		public async Task<UserRole> GetByUserIdAndRoleId(int userId, int roleId)
		{
			return await FindByCondition(x => x.UserId.Equals(userId) && x.RoleId.Equals(roleId))
								.FirstOrDefaultAsync();
		}

		#endregion
	}
}
