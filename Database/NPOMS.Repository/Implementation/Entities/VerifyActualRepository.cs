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
    public class VerifyActualRepository : BaseRepository<VerifyActual>, IVerifyActualRepository
    {
        RepositoryContext _repositoryContext;
        public VerifyActualRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public async Task CreateEntity(VerifyActual model)
        {
            await CreateAsync(model);
            var actual = await _repositoryContext.IndicatorReports.Where(i =>  i.Id == model.IndicatorReportId).FirstOrDefaultAsync();
            if (actual != null)
            {
                actual.StatusId = 14;
            }

            await _repositoryContext.SaveChangesAsync();
        }

        public async Task<VerifyActual> GetById(int id)
        {
            return await FindByCondition(x => x.Id.Equals(id)).AsNoTracking().FirstOrDefaultAsync();
        }

        public Task<VerifyActual> GetByIds(int financialYearId, int applicationTypeId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<VerifyActual>> GetByNpoId(int npoId)
        {
            return null;
        }

        public async Task<VerifyActual> GetVerifiedActualsByPeriodId(int actualId, int quarterId)
        {
            return await FindByCondition(x => x.IndicatorReportId == actualId && x.IsActive && x.QaurterId == quarterId)
                  .Include(x => x.Status)
                  .AsNoTracking()
                  .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<VerifyActual>> GetEntities()
        {
            return await FindByCondition(a =>a.IsActive).AsNoTracking().ToListAsync();
        }

        public async Task UpdateEntity(VerifyActual model, int currentUserId)
        {
            model.UpdatedDateTime = DateTime.Now;
            model.UpdatedUserId = currentUserId;
            await UpdateAsync(null, model, false, currentUserId);
        }

        public Task<IEnumerable<VerifyActual>> UpdateSDIPStatus(int applicationId, int finYear, int quarterId, int id)
        {
            throw new NotImplementedException();
        }
    }
}
