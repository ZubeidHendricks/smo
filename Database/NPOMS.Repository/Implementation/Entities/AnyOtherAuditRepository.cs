using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Entities;
using NPOMS.Repository.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Entities
{
    public class AnyOtherAuditRepository : BaseRepository<AnyOtherReportAudit>, IAnyOtherAuditRepository
    {
        public AnyOtherAuditRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task CreateEntity(AnyOtherReportAudit model)
        {
            await CreateAsync(model);
        }

        public async Task<AnyOtherReportAudit> GetById(int id)
        {
            return await FindByCondition(x => x.Id.Equals(id)).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<AnyOtherReportAudit> GetByIds(int financialYearId, int applicationTypeId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AnyOtherReportAudit>> GetByNpoId(int npoId)
        {
            return null;
        }

        public async Task UpdateEntity(AnyOtherReportAudit model, int currentUserId)
        {
            await UpdateAsync(null, model, false, currentUserId);
        }

        public async Task UpdateEntityQC(AnyOtherReportAudit model, int currentUserId)
        {
            throw new NotImplementedException();
        }
    }
}
