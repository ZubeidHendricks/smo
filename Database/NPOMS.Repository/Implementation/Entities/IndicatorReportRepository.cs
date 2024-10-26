using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Entities;
using NPOMS.Repository.Interfaces.Entities;
using System.Security.Cryptography.X509Certificates;

namespace NPOMS.Repository.Implementation.Entities
{
    public class IndicatorReportRepository : BaseRepository<IndicatorReport>, IIndicatorReportRepository
    {
        public IndicatorReportRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
        public async Task CreateEntity(IndicatorReport model)
        {
            await CreateAsync(model);
        }

        public async Task<IndicatorReport> GetById(int id)
        {
            return await FindByCondition(x => x.Id.Equals(id)).AsNoTracking().FirstOrDefaultAsync();
        }

        public Task<IndicatorReport> GetByIds(int financialYearId, int applicationTypeId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<IndicatorReport>> GetByNpoId(int npoId)
        {
            return await FindByCondition(x => x.Id.Equals(npoId)).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<IndicatorReport>> GetByPeriodId(int applicationPeriodId)
        {
            return await FindByCondition(x => x.ApplicationId == applicationPeriodId && x.IsActive)
                         .Include(x=>x.Status)
                         .AsNoTracking()
                         .ToListAsync();
        }

        public async Task<IEnumerable<IndicatorReport>> GetEntities()
        {
            return await FindByCondition(x => x.IsActive).AsNoTracking().ToListAsync();
        }

        public async Task UpdateEntity(IndicatorReport model, int currentUserId)
        {
            await UpdateAsync(null, model, false, currentUserId);
        }

        public async  Task UpdateEntityQC(IndicatorReport model, int currentUserId)
        {
            await UpdateAsync(null, model, false, currentUserId);
        }

        public async Task UpdateIndicatorReportStatus(int applicationId, int financialId, int quarterId, int currentUserId)
        {
            // Retrieve the records to be updated
            var indicatorReports = await FindByCondition(x => x.FinancialYearId == financialId && x.ApplicationId == applicationId && x.QaurterId == quarterId)
                                  .ToListAsync(); // No need for AsNoTracking here, as we want to modify the entities

            // Update the status of each record
            foreach (var report in indicatorReports)
            {
                report.UpdatedUserId = currentUserId;
                report.UpdatedDateTime = DateTime.Now;
                report.StatusId = 24; // Replace "Status" with the actual property name for status in your entity
            }

            // Save all changes in one transaction
            await this.RepositoryContext.SaveChangesAsync();
        }
    }
}
