using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Entities;
using NPOMS.Repository.Interfaces.Entities;

namespace NPOMS.Repository.Implementation.Entities
{
    public class PostRepository : BaseRepository<PostReport>, IPostRepository
    {
        public PostRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
        public async Task<IEnumerable<PostReport>> CompletePost(int applicationId, int financialId, int quarterId, int currentUserId)
        {
            // Retrieve the records to be updated
            var postReports = await FindByCondition(x => x.FinancialYearId == financialId && x.ApplicationId == applicationId && x.QaurterId == quarterId)
                                  .ToListAsync(); // No need for AsNoTracking here, as we want to modify the entities

            // Update the status of each record
            foreach (var report in postReports)
            {
                report.UpdatedUserId = currentUserId;   
                report.UpdatedDateTime = DateTime.Now;  
                report.StatusId = 24; // Replace "Status" with the actual property name for status in your entity
            }

            foreach (var report in postReports)
            {
                await UpdateAsync(null, report, false, currentUserId);
            }

            return postReports;
        }

        public async Task CreateEntity(PostReport model)
        {
            await CreateAsync(model);
        }

        public async Task<PostReport> GetById(int id)
        {

            return await FindByCondition(x => x.Id.Equals(id)).AsNoTracking().FirstOrDefaultAsync();
        }

        public Task<PostReport> GetByIds(int financialYearId, int applicationTypeId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PostReport>> GetByNpoId(int npoId)
        {
            return null;
            //return await FindByCondition(x => x.Id.Equals(npoId)).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<PostReport>> GetByPeriodId(int applicationPeriodId)
        {
            return await FindByCondition(x => x.ApplicationId == applicationPeriodId && x.IsActive).Include(x => x.Status)
                         .Include(x => x.PostAudits)
                         .AsNoTracking()
                         .ToListAsync();
        }


        public async Task<IEnumerable<PostReport>> GetEntities()
        {
            return await FindByCondition(x => x.IsActive)
                .Include(x =>x.StaffCategory)
                .Include(x => x.Status)
                .AsNoTracking().ToListAsync();
        }

        public async Task UpdateEntity(PostReport model, int currentUserId)
        {  
            model.UpdatedDateTime = DateTime.Now;
            model.UpdatedUserId = currentUserId;
            await UpdateAsync(null, model, false, currentUserId);
        }

        public Task UpdateEntityQC(PostReport model, int currentUserId)
        {
            throw new NotImplementedException();
        }
    }
}
