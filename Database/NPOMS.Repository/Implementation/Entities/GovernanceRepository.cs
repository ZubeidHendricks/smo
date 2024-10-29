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
    public class GovernanceRepository : BaseRepository<GovernanceReport>, IGovernanceRepository
    {
        public GovernanceRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task CompleteGovernanceReportPost(int applicationId, int financialId, int quarterId, int currentUserId)
        {
            // Retrieve the records to be updated
            var governanceReports = await FindByCondition(x => x.FinancialYearId == financialId && x.ApplicationId == applicationId && x.QaurterId == quarterId)
                                  .ToListAsync(); // No need for AsNoTracking here, as we want to modify the entities

            // Update the status of each record
            foreach (var report in governanceReports)
            {
                report.UpdatedUserId = currentUserId;
                report.UpdatedDateTime = DateTime.Now;
                report.StatusId = 24; // Replace "Status" with the actual property name for status in your entity
            }

            foreach (var report in governanceReports)
            {
                await UpdateAsync(null, report, false, currentUserId);
            }

            // Save all changes in one transaction
            //await this.RepositoryContext.SaveChangesAsync();
        }

        public async Task CreateEntity(GovernanceReport model)
        {
            await CreateAsync(model);
        }

        public async Task<GovernanceReport> GetById(int id)
        {
            return await FindByCondition(x => x.Id.Equals(id)).AsNoTracking().FirstOrDefaultAsync();
        }

        public Task<GovernanceReport> GetByIds(int financialYearId, int applicationTypeId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<GovernanceReport>> GetByNpoId(int npoId)
        {
            return null;
           // return await FindByCondition(x => x.Id.Equals(npoId)).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<GovernanceReport>> GetByPeriodId(int applicationPeriodId)
        {
            return await FindByCondition(x => x.ApplicationId == applicationPeriodId && x.IsActive).Include(x => x.Status)
                          .AsNoTracking()
                          .ToListAsync();
        }

        public async Task<IEnumerable<GovernanceReport>> GetEntities()
        {
            return await FindByCondition(x => x.IsActive).Include(x => x.Status).AsNoTracking().ToListAsync();
        }

        public async Task UpdateEntity(GovernanceReport model, int currentUserId)
        {
            await UpdateAsync(null, model, false, currentUserId);
        }
    }
}
