using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Core;
using NPOMS.Repository.Interfaces.Core;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Core
{
	public class EmbeddedReportRepository : BaseRepository<EmbeddedReport>, IEmbeddedReportRepository
	{
		#region Constructors

		public EmbeddedReportRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{

		}

		#endregion

		#region Methods

		public async Task<IEnumerable<EmbeddedReport>> GetEntities()
		{
			return await FindAll()
							.Where(x => x.IsActive)
							.AsNoTracking()
							.OrderBy(x => x.Id)
							.ToListAsync();
		}

		public async Task<EmbeddedReport> GetById(int id)
		{
			return await FindByCondition(x => x.Id.Equals(id)).FirstOrDefaultAsync();
		}

		#endregion
	}
}
