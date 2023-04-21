using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Enumerations;
using NPOMS.Domain.Mapping;
using NPOMS.Repository.Interfaces.Mapping;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Mapping
{
	public class UserNpoRepository : BaseRepository<UserNpo>, IUserNpoRepository
	{
		#region Constructors

		public UserNpoRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{

		}

		#endregion

		#region Methods

		public async Task<IEnumerable<UserNpo>> GetEntities()
		{
			return await FindAll()
							.Include(x => x.Npo)
							.Include(x => x.AccessStatus)
							.Include(x => x.CreatedUser)
							.Include(x => x.UpdatedUser)
							.Include(x => x.User)
							.OrderBy(x => x.AccessStatusId)
								.ThenBy(x => x.Npo.Name)
							.Where(x => x.Npo.IsActive)
							.AsNoTracking()
							.ToListAsync();
		}

		public async Task<IEnumerable<UserNpo>> GetByCurrentUserId(int currentUserId)
		{
			return await FindByCondition(x => x.UserId.Equals(currentUserId))
							.Include(x => x.Npo)
							.Include(x => x.AccessStatus)
							.Include(x => x.UpdatedUser)
							.OrderBy(x => x.AccessStatusId)
								.ThenBy(x => x.Npo.Name)
							.Where(x => x.Npo.IsActive)
							.AsNoTracking()
							.ToListAsync();
		}

		public async Task<IEnumerable<UserNpo>> GetApprovedEntities(int currentUserId)
		{
			return await FindByCondition(x => x.UserId.Equals(currentUserId) && x.AccessStatusId.Equals((int)AccessStatusEnum.Approved))
							.AsNoTracking()
							.ToListAsync();
		}

		public async Task CreateEntity(UserNpo model)
		{
			await CreateAsync(model);
		}

		public async Task UpdateEntity(UserNpo model, int currentUserId)
		{
			var oldEntity = await this.RepositoryContext.UserNpos.FindAsync(model.Id);
			await UpdateAsync(oldEntity, model, true, currentUserId);
		}

		public async Task<UserNpo> GetById(int id)
		{
			return await FindByCondition(x => x.Id.Equals(id))
							.Include(x => x.CreatedUser)
							.AsNoTracking()
							.FirstOrDefaultAsync();
		}

		public async Task<UserNpo> GetByUserAndNpoId(int userId, int NpoId)
		{
			return await FindByCondition(x => x.UserId.Equals(userId) && x.NpoId.Equals(NpoId))
							.AsNoTracking().FirstOrDefaultAsync();
		}

		#endregion
	}
}
