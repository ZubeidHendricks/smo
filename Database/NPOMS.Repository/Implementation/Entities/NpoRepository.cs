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
	public class NpoRepository : BaseRepository<Npo>, INpoRepository
	{
		#region Constructors

		public NpoRepository(RepositoryContext repositoryContext)
			: base(repositoryContext)
		{

		}

		#endregion

		#region Methods

		public async Task<IEnumerable<Npo>> GetEntities()
		{
			return await FindAll().Include(x => x.OrganisationType)
								  .Include(x => x.ApprovalStatus)
								  .Include(x => x.CreatedUser)
								  .Include(x => x.ApprovalUser)
								  .Include(x => x.RegistrationStatus)
							.Where(x => x.IsActive).OrderBy(x => x.Name).AsNoTracking().ToListAsync();
		}

        public async Task<IEnumerable<Npo>> GetQuickCapturers()
        {
            return await FindAll().Include(x => x.OrganisationType)
                                  .Include(x => x.ApprovalStatus)
                                  .Include(x => x.CreatedUser)
                                  .Include(x => x.ApprovalUser)
                                  .Include(x => x.RegistrationStatus)
                            .OrderBy(x => x.Name).AsNoTracking().ToListAsync();
        }

        public async Task<Npo> GetById(int id)
		{
			return await FindByCondition(x => x.Id.Equals(id))
							.AsNoTracking()
							.FirstOrDefaultAsync();
		}

		public async Task<IEnumerable<Npo>> SearchByName(string name)
		{
			return await FindByCondition(x => x.Name.Contains(name)).Where(x => x.IsActive).AsNoTracking().ToListAsync();
		}

		public async Task<IEnumerable<Npo>> SearchApprovedNpoByName(string name)
		{
			return await FindByCondition(x => x.Name.Contains(name) && x.IsActive && x.ApprovalStatusId.Equals((int)AccessStatusEnum.Approved)).AsNoTracking().ToListAsync();
		}

		public async Task<Npo> GetByNameAndOrgTypeId(string name, int organisationTypeId)
		{
			return await FindByCondition(x => x.Name.ToLower().Equals(name.ToLower()) && x.OrganisationTypeId.Equals(organisationTypeId))
							.Where(x => x.IsActive).AsNoTracking().FirstOrDefaultAsync();
		}

		public async Task CreateEntity(Npo model)
		{
			model.RefNo = StringExtensions.GenerateNewCode("NPO");
			await CreateAsync(model);
		}

		public async Task UpdateEntity(Npo model, int currentUserId)
		{
			//var oldEntity = await this.RepositoryContext.Npos.FindAsync(model.Id);
			await UpdateAsync(model, false, currentUserId);
		}

		public async Task<IEnumerable<Npo>> GetAssignedEntities(string emailAddress)
		{
			return await FindByCondition(x => x.ContactInformation.Any(y => y.EmailAddress.Equals(emailAddress)))
							.Include(x => x.OrganisationType)
							.Where(x => x.IsActive)
							.OrderBy(x => x.Name).AsNoTracking().ToListAsync();
		}

		#endregion
	}
}
