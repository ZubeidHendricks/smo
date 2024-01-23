using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Indicator;
using NPOMS.Repository.Interfaces.Indicator;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Indicator
{
	public class WorkplanActualAuditRepository : BaseRepository<WorkplanActualAudit>, IWorkplanActualAuditRepository
	{
		#region Constructors

		public WorkplanActualAuditRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{

		}

		#endregion

		#region Methods

		public async Task<IEnumerable<WorkplanActualAudit>> GetByWorkplanActualId(int workplanActualId)
		{
			return await FindByCondition(x => x.WorkplanActualId.Equals(workplanActualId))
							.Include(x => x.StatusId)
							.Include(x => x.CreatedUser)
							.OrderByDescending(x => x.CreatedDateTime).AsNoTracking().ToListAsync();
		}

		public async Task CreateEntity(WorkplanActualAudit model)
		{
			await CreateAsync(model);
		}

		#endregion
	}
}
