using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Entities;
using NPOMS.Repository.Interfaces.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Entities
{
	public class ServicesRenderedRepository : BaseRepository<ServicesRendered>, IServicesRenderedRepository
	{
		#region Constructors

		public ServicesRenderedRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{

		}

		#endregion

		#region Methods

		public async Task<IEnumerable<ServicesRendered>> GetByNpoProfileId(int npoProfileId)
		{
			return await FindByCondition(x => x.NpoProfileId.Equals(npoProfileId) && x.IsActive)
							.AsNoTracking()
							.ToListAsync();
		}

		public async Task DeleteEntity(int id, int currentUserId)
		{
			var model = await FindByCondition(x => x.Id.Equals(id)).AsNoTracking().FirstOrDefaultAsync();
			model.IsActive = false;

			var oldEntity = await this.RepositoryContext.ServicesRendered.FindAsync(model.Id);
			await UpdateAsync(oldEntity, model, true, currentUserId);
		}

		public async Task<ServicesRendered> GetByProperties(ServicesRendered model)
		{
			return await FindByCondition(x => x.ProgrammeId.Equals(model.ProgrammeId) &&
											  x.SubProgrammeId.Equals(model.SubProgrammeId) &&
											  x.SubProgrammeTypeId.Equals(model.SubProgrammeTypeId))
								.AsNoTracking().FirstOrDefaultAsync();
		}

		#endregion
	}
}
