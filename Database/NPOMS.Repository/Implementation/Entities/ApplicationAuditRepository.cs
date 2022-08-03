using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Entities;
using NPOMS.Repository.Interfaces.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Entities
{
	public class ApplicationAuditRepository : BaseRepository<ApplicationAudit>, IApplicationAuditRepository
	{
		#region Constructors

		public ApplicationAuditRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{

		}

		#endregion

		#region Methods

		public async Task<IEnumerable<ApplicationAudit>> GetByApplicationId(int applicationId)
		{
			return await FindByCondition(x => x.ApplicationId.Equals(applicationId))
							.Include(x => x.Status).Include(x => x.CreatedUser)
							.OrderByDescending(x => x.CreatedDateTime).AsNoTracking().ToListAsync();
		}

		public async Task CreateEntity(ApplicationAudit model)
		{
			await CreateAsync(model);
		}

		#endregion
	}
}
