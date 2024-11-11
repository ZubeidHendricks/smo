using NPOMS.Domain.Entities;

namespace NPOMS.Repository.Interfaces.Entities
{
        public interface IAuditPostRepository : IBaseRepository<PostAudit>
        {
            Task<PostAudit> GetById(int id);
            Task<IEnumerable<PostAudit>> GetByNpoId(int npoId);

            Task<PostAudit> GetByIds(int financialYearId, int applicationTypeId);

            Task CreateEntity(PostAudit model);

            Task UpdateEntity(PostAudit model, int currentUserId);

            Task UpdateEntityQC(PostAudit model, int currentUserId);
        }
}
