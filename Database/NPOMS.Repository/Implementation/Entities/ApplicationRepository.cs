using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Entities;
using NPOMS.Repository.Extensions;
using NPOMS.Repository.Interfaces.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Entities
{
	public class ApplicationRepository : BaseRepository<Application>, IApplicationRepository
	{
		#region Constructors

		public ApplicationRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{

		}

		#endregion

		#region Methods

		public async Task<IEnumerable<Application>> GetEntities()
		{
			return await FindByCondition(x => x.IsActive).Include(x => x.Npo)
							.Include(x => x.ApplicationPeriod)
								.ThenInclude(x => x.ApplicationType)
							.Include(x => x.Status)
							.Where(x => x.Npo.IsActive).AsNoTracking().ToListAsync();
		}

		public async Task<Application> GetById(int id)
		{
			return await FindByCondition(x => x.Id.Equals(id)).Include(x => x.ApplicationPeriod).AsNoTracking().FirstOrDefaultAsync();
		}

		public async Task<Application> GetByNpoIdAndPeriodId(int NpoId, int applicationPeriodId)
		{
			return await FindByCondition(x => x.NpoId.Equals(NpoId) && x.ApplicationPeriodId.Equals(applicationPeriodId))
							.AsNoTracking().FirstOrDefaultAsync();
		}

		public async Task CreateEntity(Application model)
		{
			model.RefNo = StringExtensions.GenerateNewCode("APP");
			await CreateAsync(model);
		}

		public async Task UpdateEntity(Application model)
		{
			await UpdateAsync(model);
		}

		#endregion
	}
}
