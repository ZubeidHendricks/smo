using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Entities;
using NPOMS.Repository.Interfaces.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Entities
{
	public class AccessStatusRepository : BaseRepository<AccessStatus>, IAccessStatusRepository
	{
		#region Constructors

		public AccessStatusRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{

		}

		#endregion

		#region Methods

		public async Task<IEnumerable<AccessStatus>> GetEntities(bool returnInactive)
		{
			if (returnInactive)
			{
				return await FindAll()
								.AsNoTracking()
								.OrderBy(x => x.Id)
								.ToListAsync();
			}
			else
			{
				return await FindAll()
								.Where(x => x.IsActive)
								.AsNoTracking()
								.OrderBy(x => x.Id)
								.ToListAsync();
			}
		}

		public async Task<AccessStatus> GetById(int id)
		{
			return await FindByCondition(x => x.Id.Equals(id)).FirstOrDefaultAsync();
		}

		#endregion
	}
}
