using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Entities;
using NPOMS.Repository.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Entities
{
	public class AuditorOrAffiliationRepository : BaseRepository<AuditorOrAffiliation>, IAuditorOrAffiliationRepository
	{
		#region Constructors

		public AuditorOrAffiliationRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{

		}

		#endregion

		#region Methods

		public async Task<IEnumerable<AuditorOrAffiliation>> GetByEntityId(int entityId)
		{
			return await FindByCondition(x => x.EntityId.Equals(entityId) && x.IsActive)
							.AsNoTracking()
							.ToListAsync();
		}

		public async Task UpdateEntity(AuditorOrAffiliation model, int currentUserId)
		{
			var oldEntity = await this.RepositoryContext.AuditorOrAffiliations.FindAsync(model.Id);
			await UpdateAsync(oldEntity, model, true, currentUserId);
		}

		#endregion
	}
}
