using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Mapping;
using NPOMS.Repository.Interfaces.Mapping;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Mapping
{
	public class ActivityRecipientRepository : BaseRepository<ActivityRecipient>, IActivityRecipientRepository
	{
		#region Constructors

		public ActivityRecipientRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{

		}

		#endregion

		#region Methods

		public async Task<IEnumerable<ActivityRecipient>> GetByActivityId(int activityId)
		{
			return await FindByCondition(x => x.ActivityId.Equals(activityId)).AsNoTracking().ToListAsync();
		}

		public async Task DeleteEntity(int activityId)
		{
			var recipients = await FindByCondition(x => x.ActivityId.Equals(activityId)).AsNoTracking().ToListAsync();

			foreach (var recipient in recipients)
			{
				await DeleteAsync(recipient);
			}
		}

		#endregion
	}
}
