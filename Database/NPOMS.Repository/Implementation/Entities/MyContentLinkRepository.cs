using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Entities;
using NPOMS.Repository.Interfaces.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Entities
{
	public class MyContentLinkRepository : BaseRepository<MyContentLink>, IMyContentLinkRepository
	{
		#region Constructors

		public MyContentLinkRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{

		}

		#endregion

		#region Methods

		public async Task<IEnumerable<MyContentLink>> GetByApplicationId(int applicationId)
		{
			return await FindByCondition(x => x.ApplicationId.Equals(applicationId) && x.IsActive).Include(x => x.CreatedUser).ToListAsync();
		}

		#endregion
	}
}
