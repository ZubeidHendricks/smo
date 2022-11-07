using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Dropdown;
using NPOMS.Repository.Interfaces.Dropdown;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Dropdown
{
	public class FrequencyPeriodRepository : BaseRepository<FrequencyPeriod>, IFrequencyPeriodRepository
	{
		#region Constructors

		public FrequencyPeriodRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{

		}

		#endregion

		#region Methods

		public async Task<IEnumerable<FrequencyPeriod>> GetEntities(bool returnInactive)
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

		public async Task<IEnumerable<FrequencyPeriod>> GetByFrequencyId(int frequencyId)
		{
			return await FindByCondition(x => x.FrequencyId.Equals(frequencyId) && x.IsActive)
							.OrderBy(x => x.Id).AsNoTracking().ToListAsync();
		}

		public async Task<FrequencyPeriod> GetById(int id)
		{
			return await FindByCondition(x => x.Id.Equals(id)).AsNoTracking().FirstOrDefaultAsync();
		}

		#endregion
	}
}