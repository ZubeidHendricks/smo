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
    public class IncomeAuditRepository : BaseRepository<IncomeReportAudit>, IIncomeAuditRepository
    {
        public IncomeAuditRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task CreateEntity(IncomeReportAudit model)
        {
            await CreateAsync(model);
        }
    

        public async Task<IncomeReportAudit> GetById(int id)
        {
            return await FindByCondition(x => x.Id.Equals(id)).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<IncomeReportAudit> GetByIds(int financialYearId, int applicationTypeId)
        {
             return null;
        }

        public  async  Task<IEnumerable<IncomeReportAudit>> GetByNpoId(int npoId)
        {
            return null;
        }

        public async Task UpdateEntity(IncomeReportAudit model, int currentUserId)
        {
            await UpdateAsync(null, model, false, currentUserId);
        }

        public async  Task UpdateEntityQC(IncomeReportAudit model, int currentUserId)
        {
            throw new NotImplementedException();
        }
    }
}
