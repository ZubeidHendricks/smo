using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Entities;
using NPOMS.Repository.Interfaces.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Entities
{
	public class StaffMemberProfileRepository : BaseRepository<StaffMemberProfile>, IStaffMemberProfileRepository
	{
		#region Constructors

		public StaffMemberProfileRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{

		}

		#endregion

		#region Methods

		public async Task<IEnumerable<StaffMemberProfile>> GetByNpoProfileId(int npoProfileId)
		{
			return await FindByCondition(x => x.NpoProfileId.Equals(npoProfileId))
							.AsNoTracking()
							.ToListAsync();
		}

		public async Task UpdateEntity(StaffMemberProfile model, int currentUserId)
		{
			var oldEntity = await this.RepositoryContext.StaffMemberProfiles.FindAsync(model.Id);
			await UpdateAsync(oldEntity, model, true, currentUserId);
		}

		#endregion
	}
}
