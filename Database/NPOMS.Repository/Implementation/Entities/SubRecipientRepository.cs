using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Entities;
using NPOMS.Repository.Interfaces.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Entities
{
	public class SubRecipientRepository : BaseRepository<SubRecipient>, ISubRecipientRepository
	{
		#region Constructors

		public SubRecipientRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{

		}

		#endregion

		#region Methods

		public async Task<SubRecipient> GetById(int id)
		{
			return await FindByCondition(x => x.Id.Equals(id)).AsNoTracking().FirstOrDefaultAsync();
		}

		public async Task<IEnumerable<SubRecipient>> GetByObjectiveId(int objectiveId)
		{
			return await FindByCondition(x => x.ObjectiveId.Equals(objectiveId) && x.IsActive).AsNoTracking().ToListAsync();
		}

		#endregion
	}
}
