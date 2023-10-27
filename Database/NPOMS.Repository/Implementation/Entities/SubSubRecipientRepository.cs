using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Entities;
using NPOMS.Repository.Interfaces.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Entities
{
	public class SubSubRecipientRepository : BaseRepository<SubSubRecipient>, ISubSubRecipientRepository
	{
		#region Constructors

		public SubSubRecipientRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{

		}

		#endregion

		#region Methods

		public async Task<SubSubRecipient> GetById(int id)
		{
			return await FindByCondition(x => x.Id.Equals(id)).AsNoTracking().FirstOrDefaultAsync();
		}

		public async Task<IEnumerable<SubSubRecipient>> GetBySubRecipientId(int subRecipientId)
		{
			return await FindByCondition(x => x.SubRecipientId.Equals(subRecipientId) && x.IsActive).AsNoTracking().ToListAsync();
		}

		#endregion
	}
}
