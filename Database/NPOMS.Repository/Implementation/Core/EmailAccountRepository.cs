using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Core;
using NPOMS.Repository.Interfaces.Core;
using System.Linq;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Core
{
	public class EmailAccountRepository : BaseRepository<EmailAccount>, IEmailAccountRepository
	{
		#region Constructors

		public EmailAccountRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{

		}

		#endregion

		#region Methods

		public IQueryable<EmailAccount> GetEntities()
		{
			return FindAll();
		}

		public async Task<EmailAccount> GetById(int id)
		{
			return await FindByCondition(x => x.Id == id).FirstOrDefaultAsync();
		}

		public async Task CreateEntity(EmailAccount entity)
		{
			await CreateAsync(entity);
		}

		public async Task UpdateEntity(EmailAccount entity, int currentUserId)
		{
			await UpdateAsync(null, entity, false, currentUserId);
		}

		public async Task DeleteEntity(EmailAccount entity)
		{
			await DeleteAsync(entity);
		}

		#endregion
	}
}
