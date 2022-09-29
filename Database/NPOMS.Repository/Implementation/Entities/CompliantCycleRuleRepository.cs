using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Entities;
using NPOMS.Repository.Interfaces.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Entities
{
	public class CompliantCycleRuleRepository : BaseRepository<CompliantCycleRule>, ICompliantCycleRuleRepository
	{
		#region Constructors

		public CompliantCycleRuleRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{

		}

		#endregion

		#region Methods

		public async Task<IEnumerable<CompliantCycleRule>> GetEntities(bool returnInactive)
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

		public async Task<CompliantCycleRule> GetById(int id)
		{
			return await FindByCondition(x => x.Id.Equals(id)).FirstOrDefaultAsync();
		}

		#endregion
	}
}
