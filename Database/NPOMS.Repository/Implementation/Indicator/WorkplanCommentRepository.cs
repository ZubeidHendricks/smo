using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Indicator;
using NPOMS.Repository.Interfaces.Indicator;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Indicator
{
	public class WorkplanCommentRepository : BaseRepository<WorkplanComment>, IWorkplanCommentRepository
	{
		#region Constructors

		public WorkplanCommentRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{

		}

		#endregion

		#region Methods

		public async Task<IEnumerable<WorkplanComment>> GetByWorkplanActualId(int workplanActualId)
		{
			return await FindByCondition(x => x.WorkplanActualId.Equals(workplanActualId))
				.Include(x => x.CreatedUser).OrderByDescending(x => x.CreatedDateTime).AsNoTracking().ToListAsync();
		}

		public async Task CreateEntity(WorkplanComment model)
		{
			await CreateAsync(model);
		}

		#endregion
	}
}
