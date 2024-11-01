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
    public class AuditIndicatorRepository : BaseRepository<IndicatorReportAudit>, IAuditIndicatorRepository
    {
        public AuditIndicatorRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task CreateEntity(IndicatorReportAudit model)
        {
            await CreateAsync(model);
        }

        public async Task<IndicatorReportAudit> GetById(int id)
        {

            return await FindByCondition(x => x.Id.Equals(id)).AsNoTracking().FirstOrDefaultAsync();
        }

        public Task<IndicatorReportAudit> GetByIds(int financialYearId, int applicationTypeId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<IndicatorReportAudit>> GetByNpoId(int npoId)
        {
            return null;
        }

        public async Task UpdateEntity(IndicatorReportAudit model, int currentUserId)
        {
            await UpdateAsync(null, model, false, currentUserId);
        }

        public Task UpdateEntityQC(IndicatorReportAudit model, int currentUserId)
        {
            throw new NotImplementedException();
        }
    }
}
