using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Entities;
using NPOMS.Repository.Extensions;
using NPOMS.Repository.Interfaces.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Entities
{
	public class ApplicationPeriodRepository : BaseRepository<ApplicationPeriod>, IApplicationPeriodRepository
	{
		#region Constructors

		public ApplicationPeriodRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{

		}

		#endregion

		#region Methods

		public async Task<IEnumerable<ApplicationPeriod>> GetEntities()
		{
			return await FindAll().Include(x => x.ApplicationType)
								  .Include(x => x.Department)
								  .Include(x => x.FinancialYear)
								  .Include(x => x.SubProgramme)
								  .AsNoTracking()
								  .ToListAsync();
		}

		public async Task<ApplicationPeriod> GetById(int id)
		{
			return await FindByCondition(x => x.Id.Equals(id))
							.Include(x => x.Department)
							.Include(x => x.Programme)
							.Include(x => x.SubProgramme)
							.Include(x => x.FinancialYear)
							.Include(x => x.ApplicationType)
							.AsNoTracking()
							.FirstOrDefaultAsync();
		}

		public async Task CreateEntity(ApplicationPeriod model)
		{
			model.RefNo = StringExtensions.GenerateNewCode("PRD");
			await CreateAsync(model);
		}

		public async Task UpdateEntity(ApplicationPeriod model, int currentUserId)
		{
			var oldEntity = await this.RepositoryContext.ApplicationPeriods.FindAsync(model.Id);
			await UpdateAsync(oldEntity, model, true, currentUserId);
		}

		#endregion
	}
}
