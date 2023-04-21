using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Lookup;
using NPOMS.Repository.Interfaces.Lookup;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Lookup
{
	public class FacilityListRepository : BaseRepository<FacilityList>, IFacilityListRepository
	{
		#region Constructors

		public FacilityListRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{

		}

		#endregion

		#region Methods

		public async Task<IEnumerable<FacilityList>> GetEntities(bool returnInactive)
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

		public async Task<IEnumerable<FacilityList>> SearchByName(string name)
		{
			return await FindByCondition(x => x.Name.Contains(name)).AsNoTracking().ToListAsync();
		}

		public async Task CreateEntity(FacilityList model)
		{
			await CreateAsync(model);
		}

		public async Task UpdateEntity(FacilityList model, int currentUserId)
		{
			await UpdateAsync(null, model, false, currentUserId);
		}

		public async Task DeleteEntity(int id, int currentUserId)
		{
			var model = await FindByCondition(x => x.Id.Equals(id)).FirstOrDefaultAsync();
			model.IsActive = false;

			await UpdateAsync(null, model, false, currentUserId);
		}

		public async Task<FacilityList> GetByProperties(FacilityList model)
		{
			return await FindByCondition(x => x.Name.Equals(model.Name) &&
							x.FacilitySubDistrictId.Equals(model.FacilitySubDistrictId) &&
							x.FacilityClassId.Equals(model.FacilityClassId) &&
							x.FacilityTypeId.Equals(model.FacilityTypeId))
								.AsNoTracking().FirstOrDefaultAsync();
		}

		#endregion
	}
}
