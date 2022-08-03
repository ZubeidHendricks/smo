using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Entities;
using NPOMS.Repository.Interfaces.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Entities
{
	public class ObjectiveRepository : BaseRepository<Objective>, IObjectiveRepository
	{
		#region Constructors

		public ObjectiveRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{

		}

		#endregion

		#region Methods

		public async Task<IEnumerable<Objective>> GetEntities(int applicationId)
		{
			return await FindByCondition(x => x.ApplicationId.Equals(applicationId) && x.IsActive)
				.Include(x => x.RecipientType).AsNoTracking().ToListAsync();
		}

		public async Task CreateEntity(Objective model)
		{
			await CreateAsync(model);
		}

		public async Task UpdateEntity(Objective model)
		{
			await UpdateAsync(model);
		}

		public async Task<Objective> GetById(int id)
		{
			return await FindByCondition(x => x.Id.Equals(id)).Include(x => x.ObjectiveProgrammes).AsNoTracking().FirstOrDefaultAsync();
		}

		#endregion
	}
}
