using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Lookup;
using NPOMS.Repository.Interfaces.Lookup;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Lookup
{
	public class ResourceListRepository : BaseRepository<ResourceList>, IResourceListRepository
	{
		#region Constructors

		public ResourceListRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{

		}

		#endregion

		#region Methods

		public async Task<IEnumerable<ResourceList>> GetEntities(bool returnInactive)
		{
			if (returnInactive)
			{
				return await FindAll()
								.AsNoTracking()
								.OrderBy(x => x.Name)
								.ToListAsync();
			}
			else
			{
				return await FindAll()
								.Where(x => x.IsActive)
								.AsNoTracking()
								.OrderBy(x => x.Name)
								.ToListAsync();
			}
		}

		public async Task CreateEntity(ResourceList model)
		{
			await CreateAsync(model);
		}

		public async Task UpdateEntity(ResourceList model, int currentUserId)
		{
			await UpdateAsync(null, model, false, currentUserId);
		}

		public async Task DeleteEntity(int id, int currentUserId)
		{
			var model = await FindByCondition(x => x.Id.Equals(id)).FirstOrDefaultAsync();
			model.IsActive = false;

			await UpdateAsync(null, model, false, currentUserId);
		}

		public async Task<ResourceList> GetByName(string name)
		{
			return await FindByCondition(x => x.Name.Equals(name)).AsNoTracking().FirstOrDefaultAsync();
		}

		#endregion
	}
}
