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
    public class SDIPAuditRepository : BaseRepository<SDIPReportAudit>, ISDIPAuditRepository
    {
        public SDIPAuditRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task CreateEntity(SDIPReportAudit model)
        {
            await CreateAsync(model);
        }

        public async Task<SDIPReportAudit> GetById(int id)
        {
            return await FindByCondition(x => x.Id.Equals(id)).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<SDIPReportAudit> GetByIds(int financialYearId, int applicationTypeId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<SDIPReportAudit>> GetByNpoId(int npoId)
        {
            return null;
        }

        public async Task UpdateEntity(SDIPReportAudit model, int currentUserId)
        {
            await UpdateAsync(null, model, false, currentUserId);
        }

        public async Task UpdateEntityQC(SDIPReportAudit model, int currentUserId)
        {
            throw new NotImplementedException();
        }
    }
}
