using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Entities;
using NPOMS.Repository.Interfaces.Entities;

namespace NPOMS.Repository.Implementation.Entities
{
    public class AuditPostRepository : BaseRepository<PostAudit>, IAuditPostRepository
    {
        public AuditPostRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task CreateEntity(PostAudit model)
        {
            await CreateAsync(model);
        }

        public async Task<PostAudit> GetById(int id)
        {

            return await FindByCondition(x => x.Id.Equals(id)).AsNoTracking().FirstOrDefaultAsync();
        }

        public Task<PostAudit> GetByIds(int financialYearId, int applicationTypeId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PostAudit>> GetByNpoId(int npoId)
        {
            return null;
            //return await FindByCondition(x => x.Id.Equals(npoId)).AsNoTracking().ToListAsync();
        }

        public async Task UpdateEntity(PostAudit model, int currentUserId)
        {
            await UpdateAsync(null, model, false, currentUserId);
        }

        public Task UpdateEntityQC(PostAudit model, int currentUserId)
        {
            throw new NotImplementedException();
        }
    }
}
