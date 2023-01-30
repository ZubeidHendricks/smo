using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Core;
using NPOMS.Repository.Interfaces.Core;
using System.Linq;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Core
{
	public class EmailQueueRepository : BaseRepository<EmailQueue>, IEmailQueueRepository
	{
		#region Constructors

		public EmailQueueRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{

		}

		#endregion

		#region Methods

		public IQueryable<EmailQueue> GetEntities()
		{
			return FindAll()
					.Include(x => x.EmailTemplate)
					.ThenInclude(x => x.EmailAccount);
		}

		public async Task<EmailQueue> GetById(int id)
		{
			return await FindByCondition(x => x.Id == id).FirstOrDefaultAsync();
		}

		public async Task CreateEntity(EmailQueue entity)
		{
			await CreateAndDetachAsync(entity);
		}

		public async Task UpdateEntity(EmailQueue entity)
		{
			await UpdateAsync(null, entity, false);
		}

		public async Task DeleteEntity(EmailQueue entity)
		{
			await DeleteAsync(entity);
		}

		#endregion
	}
}
