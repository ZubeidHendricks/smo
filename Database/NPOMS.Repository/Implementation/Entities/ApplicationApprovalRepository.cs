using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Entities;
using NPOMS.Repository.Interfaces.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Entities
{
	public class ApplicationApprovalRepository : BaseRepository<ApplicationApproval>, IApplicationApprovalRepository
	{
		#region Constructors

		public ApplicationApprovalRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{

		}

		#endregion

		#region Methods

		public async Task<IEnumerable<ApplicationApproval>> GetByApplicationId(int applicationId)
		{
			return await FindByCondition(x => x.ApplicationId.Equals(applicationId) && x.isActive).Include(x => x.CreatedUser).AsNoTracking().ToListAsync();
		}

		public async Task CreateEntity(ApplicationApproval model)
		{
			await CreateAsync(model);
		}

		public async Task UpdateEntity(ApplicationApproval model)
		{
			await UpdateAsync(model);
		}

		#endregion
	}
}
