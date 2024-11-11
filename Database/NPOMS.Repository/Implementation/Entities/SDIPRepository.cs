using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Entities;
using NPOMS.Repository.Interfaces.Entities;
namespace NPOMS.Repository.Implementation.Entities
{
    public class SDIPRepository : BaseRepository<SDIPReport>, ISDIPRepository 
    {
        public SDIPRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<SDIPReport>> CompleteSDIPReport(int applicationId, int financialId, int quarterId, int currentUserId)
        {
            // Retrieve the records to be updated
            var sdiReports = await FindByCondition(x => x.FinancialYearId == financialId && x.ApplicationId == applicationId && x.QaurterId == quarterId)
                                  .ToListAsync(); // No need for AsNoTracking here, as we want to modify the entities

            // Update the status of each record
            foreach (var report in sdiReports)
            {
                report.UpdatedUserId = currentUserId;
                report.UpdatedDateTime = DateTime.Now;
                report.StatusId = 24; // Replace "Status" with the actual property name for status in your entity
            }

            foreach (var report in sdiReports)
            {
                await UpdateAsync(null, report, false, currentUserId);
            }
            return sdiReports;  

        }

        public async Task CreateEntity(SDIPReport model)
        {
            await CreateAsync(model);
        }

        public async Task<SDIPReport> GetById(int id)
        {
            return await FindByCondition(x => x.Id.Equals(id)).AsNoTracking().FirstOrDefaultAsync();
        }

        public async  Task<SDIPReport> GetByIds(int financialYearId, int applicationTypeId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SDIPReport>> GetByNpoId(int npoId)
        {
            return null;
        }

        public async Task<IEnumerable<SDIPReport>> GetByPeriodId(int applicationPeriodId)
        {
            return await FindByCondition(x => x.ApplicationId == applicationPeriodId && x.IsActive)
                        .Include(x => x.Status)
                        .Include(x => x.SDIPReportAudits)
                        .AsNoTracking()
                        .ToListAsync();
        }

        public async Task<IEnumerable<SDIPReport>> GetEntities()
        {
            return await FindByCondition(x => x.IsActive).Include(x => x.Status).AsNoTracking().ToListAsync();
        }

        public async Task UpdateEntity(SDIPReport model, int currentUserId)
        {
            model.UpdatedDateTime = DateTime.Now;
            model.UpdatedUserId = currentUserId;
            await UpdateAsync(null, model, false, currentUserId);
        }


        public async Task<IEnumerable<SDIPReport>> UpdateSDIPStatus(int applicationId, int financialId, int quarterId, int currentUserId)
        {
            // Retrieve the records to be updated
            var sdiReports = await FindByCondition(x => x.FinancialYearId == financialId && x.ApplicationId == applicationId && x.QaurterId == quarterId)
                                  .ToListAsync(); // No need for AsNoTracking here, as we want to modify the entities

            // Update the status of each record
            foreach (var report in sdiReports)
            {
                report.UpdatedUserId = currentUserId;
                report.UpdatedDateTime = DateTime.Now;
                report.StatusId = 24; // Replace "Status" with the actual property name for status in your entity
            }

            foreach (var report in sdiReports)
            {
                await UpdateAsync(null, report, false, currentUserId);
            }

            return sdiReports;

            // Save all changes in one transaction
            //await this.RepositoryContext.SaveChangesAsync();
        }
    }
}
