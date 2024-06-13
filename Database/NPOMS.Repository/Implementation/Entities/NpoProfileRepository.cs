using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Entities;
using NPOMS.Domain.Enumerations;
using NPOMS.Repository.Extensions;
using NPOMS.Repository.Interfaces.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Entities
{
	public class NpoProfileRepository : BaseRepository<NpoProfile>, INpoProfileRepository
	{
		#region Constructors

		public NpoProfileRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{

		}

		#endregion

		#region Methods

		public async Task<IEnumerable<NpoProfile>> GetEntities()
		{
			return await FindAll().Include(x => x.Npo).ThenInclude(x => x.OrganisationType)
								  .Include(x => x.Npo).ThenInclude(x => x.ApprovalStatus)
								  .Include(x => x.AccessStatus)
								  .Where(x => x.Npo.IsActive && x.IsActive).AsNoTracking().ToListAsync();
		}

		public async Task<NpoProfile> GetById(int id)
		{
			return await FindByCondition(x => x.Id.Equals(id))
							.Include(x => x.AddressInformation)
							.AsNoTracking()
							.FirstOrDefaultAsync();
		}

		public async Task CreateEntity(NpoProfile model)
		{
            model.AccessStatusId = (int)AccessStatusEnum.New;

            model.RefNo = StringExtensions.GenerateNewCode("PRO");
			await CreateAsync(model);
		}

		public async Task UpdateEntity(NpoProfile model, int currentUserId)
		{
			this.RepositoryContext.AddressInformation.Update(model.AddressInformation);
			var oldEntity = await this.RepositoryContext.NpoProfiles.FindAsync(model.Id);
            model.AccessStatusId = (int)AccessStatusEnum.Pending;
            await UpdateAsync(oldEntity, model, true, currentUserId);
		}

		public async Task<NpoProfile> GetByNpoId(int NpoId)
		{
			return await FindByCondition(x => x.NpoId.Equals(NpoId) && x.IsActive)
							.Include(x => x.AddressInformation)
							.AsNoTracking()
							.FirstOrDefaultAsync();
		}

		#endregion
	}
}
