using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Core;
using NPOMS.Domain.Enumerations;
using NPOMS.Repository.Interfaces.Core;
using System.Linq;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Core
{
	public class EmailTemplateRepository : BaseRepository<EmailTemplate>, IEmailTemplateRepository
	{
		#region Constructors

		public EmailTemplateRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{

		}

		#endregion

		#region Methods

		public IQueryable<EmailTemplate> GetEntities()
		{
			return FindAll();
		}

		public async Task<EmailTemplate> GetById(int id)
		{
			return await FindByCondition(x => x.Id == id).FirstOrDefaultAsync();
		}

		public async Task<EmailTemplate> GetByType(EmailTemplateTypeEnum emailTemplateTypeEnum)
		{
			string emailTemplateName = emailTemplateTypeEnum.ToString();
			return await FindByCondition(x => x.Name == emailTemplateName)
				.Include(x => x.EmailAccount)
				.FirstOrDefaultAsync();
		}

		public async Task CreateEntity(EmailTemplate entity)
		{
			await CreateAsync(entity);
		}

		public async Task UpdateEntity(EmailTemplate entity)
		{
			await UpdateAsync(null, entity, false);
		}

		public async Task DeleteEntity(EmailTemplate entity)
		{
			await DeleteAsync(entity);
		}

		#endregion
	}
}
