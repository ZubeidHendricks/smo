using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Entities;
using NPOMS.Repository.Interfaces.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Entities
{
	public class ContactInformationRepository : BaseRepository<ContactInformation>, IContactInformationRepository
	{
		#region Constructors

		public ContactInformationRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{

		}

		#endregion

		#region Methods

		public async Task<IEnumerable<ContactInformation>> GetByNpoId(int NpoId)
		{
			return await FindByCondition(x => x.NpoId.Equals(NpoId) && x.IsActive)
							.Include(x => x.Title)
							.Include(x => x.Position)
							.AsNoTracking()
							.ToListAsync();
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
