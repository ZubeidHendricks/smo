using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Mapping;
using NPOMS.Repository.Interfaces.Mapping;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Mapping
{
	public class NpoProfileFacilityListRepository : BaseRepository<NpoProfileFacilityList>, INpoProfileFacilityListRepository
	{
		#region Constructors

		public NpoProfileFacilityListRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{

		}

		#endregion

		#region Methods

		public async Task<IEnumerable<NpoProfileFacilityList>> GetByNpoProfileId(int npoProfileId)
		{
			return await FindByCondition(x => x.NpoProfileId.Equals(npoProfileId) && x.IsActive)
							.Include(x => x.FacilityList)
								.ThenInclude(x => x.FacilitySubDistrict)
									.ThenInclude(x => x.FacilityDistrict)
							.Include(x => x.FacilityList)
								.ThenInclude(x => x.FacilityClass)
							.Include(x => x.FacilityList)
								.ThenInclude(x => x.FacilityType)
							.AsNoTracking().ToListAsync();
		}

		public async Task DeleteEntity(int id)
		{
			var model = await FindByCondition(x => x.Id.Equals(id)).AsNoTracking().FirstOrDefaultAsync();
			model.IsActive = false;
			await UpdateAsync(model);
		}

		#endregion
	}
}
