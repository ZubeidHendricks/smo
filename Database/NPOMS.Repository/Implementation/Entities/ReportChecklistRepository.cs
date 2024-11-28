using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Entities;
using NPOMS.Repository.Interfaces.Entities;

namespace NPOMS.Repository.Implementation.Entities
{
    public class ReportChecklistRepository : BaseRepository<ReportChecklist>, IReportChecklistRepository 
    {
        public ReportChecklistRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public Task<IEnumerable<ReportChecklist>> CompletePost(int applicationId, int financialId, int quarter, int currentUserId)
        {
            throw new NotImplementedException();
        }

        public async  Task<ReportChecklist> GetById(int id)
        {
            return await FindByCondition(x => x.Id.Equals(id)).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<ReportChecklist> GetByPeriodIdAndqtrId(int applicationPeriodId, int qterId)
        {
                return  await FindByCondition(x => x.ApplicationId == applicationPeriodId && x.IsActive && x.QaurterId == qterId)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ReportChecklist>> GetEntities()
        {
            return await FindByCondition(x => x.IsActive)

               .AsNoTracking().ToListAsync();
        }

        public async  Task UpdateEntity(ReportChecklist model, int currentUserId)
        {
            model.UpdatedDateTime = DateTime.Now;
            model.UpdatedUserId = currentUserId;
            await UpdateAsync(null, model, false, currentUserId);
        }
    }
}
