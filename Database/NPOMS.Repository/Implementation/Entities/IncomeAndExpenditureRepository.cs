using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Entities;
using NPOMS.Repository.Interfaces.Entities;
using NPOMS.Repository.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Entities
{
    public class IncomeAndExpenditureRepository :BaseRepository<IncomeAndExpenditureReport>, IIncomeAndExpenditureRepository
    {
        public IncomeAndExpenditureRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task CreateEntity(IncomeAndExpenditureReport model)
        {
            await CreateAsync(model);
        }

   

        public async Task<IncomeAndExpenditureReport> GetById(int id)
        {

            return await FindByCondition(x => x.Id.Equals(id)).AsNoTracking().FirstOrDefaultAsync();
        }

        public Task<IncomeAndExpenditureReport> GetByIds(int financialYearId, int applicationTypeId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<IncomeAndExpenditureReport>> GetByNpoId(int npoId)
        {
            return await FindByCondition(x => x.Id.Equals(npoId)).AsNoTracking().ToListAsync();
        }

        public  async Task<IEnumerable<IncomeAndExpenditureReport>> GetByPeriodId(int applicationPeriodId)
        {
            return await FindByCondition(x => x.ApplicationId.Equals(applicationPeriodId)).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<IncomeAndExpenditureReport>> GetEntities()
        {
            return await FindByCondition(x => x.IsActive).AsNoTracking().ToListAsync();
        }

        public  async Task UpdateEntity(IncomeAndExpenditureReport model, int currentUserId)
        {
            model.UpdatedDateTime = DateTime.Now;
            model.UpdatedUserId = currentUserId;
            await UpdateAsync(null, model, false, currentUserId);
        }

        public Task UpdateEntityQC(IncomeAndExpenditureReport model, int currentUserId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<IncomeAndExpenditureReport>> UpdateIncomeReportStatus(int applicationId, int financialId, int quarterId, int currentUserId)
        {
            // Retrieve the records to be updated
            var incomeReports = await FindByCondition(x => x.FinancialYearId == financialId && x.ApplicationId == applicationId && x.QaurterId == quarterId)
                                  .ToListAsync(); // No need for AsNoTracking here, as we want to modify the entities

            // Update the status of each record
            foreach (var report in incomeReports)
            {
                report.UpdatedUserId = currentUserId;
                report.UpdatedDateTime = DateTime.Now;
                report.StatusId = 24; // Replace "Status" with the actual property name for status in your entity
            }
            foreach (var report in incomeReports)
            {
                await UpdateAsync(null, report, false, currentUserId);
            }
            return incomeReports;

            // Save all changes in one transaction
            //await this.RepositoryContext.SaveChangesAsync();
        }

        Task<IncomeAndExpenditureReport> IIncomeAndExpenditureRepository.GetById(int id)
        {
            throw new NotImplementedException();
        }

        Task<IncomeAndExpenditureReport> IIncomeAndExpenditureRepository.GetByIds(int financialYearId, int applicationTypeId)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<IncomeAndExpenditureReport>> IIncomeAndExpenditureRepository.GetByNpoId(int npoId)
        {
            throw new NotImplementedException();
        }

        async Task<IEnumerable<IncomeAndExpenditureReport>> IIncomeAndExpenditureRepository.GetByPeriodId(int applicationPeriodId)
        {
            return await FindByCondition(x => x.ApplicationId == applicationPeriodId && x.IsActive)
                          .Include(x => x.Status)
                          .Include(x => x.IncomeReportAudits)
                          .AsNoTracking()
                          .ToListAsync();
        }

        Task<IEnumerable<IncomeAndExpenditureReport>> IIncomeAndExpenditureRepository.GetEntities()
        {
            throw new NotImplementedException();
        }

    }
}
