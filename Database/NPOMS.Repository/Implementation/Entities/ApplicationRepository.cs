﻿using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Entities;
using NPOMS.Repository.Extensions;
using NPOMS.Repository.Interfaces.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Entities
{
    public class ApplicationRepository : BaseRepository<Application>, IApplicationRepository
    {
        #region Constructors

        public ApplicationRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

        #endregion

        #region Methods

        public async Task<IEnumerable<Application>> GetEntities()
        {
            return await FindByCondition(x => x.IsActive).Include(x => x.Npo)
                            .Include(x => x.NpoUserTrackings)
                            .Include(x => x.NpoUserSatisfactionTrackings)
                            .Include(x => x.NpoWorkPlanApproverTrackings)
                            .Include(x => x.NpoWorkPlanReviewerTrackings)
                            .Include(x => x.ApplicationPeriod)
                                .ThenInclude(x => x.ApplicationType)
                            .Include(x => x.ApplicationPeriod)
                                .ThenInclude(x => x.FinancialYear)
                            .Include(x => x.ApplicationPeriod)
                                .ThenInclude(x => x.SubProgramme)
                            .Include(x => x.ApplicationPeriod)
                                .ThenInclude(x => x.SubProgrammeType)
                            .Include(x => x.Status)
                            .Where(x => x.Npo.IsActive).AsNoTracking().ToListAsync();
        }

        public async Task<Application> GetById(int id)
        {
            return await FindByCondition(x => x.Id.Equals(id))
                .Include(x => x.NpoUserTrackings)
                .Include(x => x.NpoUserSatisfactionTrackings)
                .Include(x => x.NpoWorkPlanReviewerTrackings)
                .Include(x => x.NpoWorkPlanApproverTrackings)
                .Include(x => x.ApplicationPeriod)
                .ThenInclude(x => x.FinancialYear).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<Application> GetByNpoIdAndPeriodId(int NpoId, int applicationPeriodId)
        {
            return await FindByCondition(x => x.NpoId.Equals(NpoId) && x.ApplicationPeriodId.Equals(applicationPeriodId) && x.IsActive)
                            .AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<Application> GetByNpoIdAndPeriodIdAndYear(int NpoId, int applicationPeriodId, string year)
        {
            return await FindByCondition(x => x.NpoId.Equals(NpoId) && x.ApplicationPeriodId.Equals(applicationPeriodId) && x.ApplicationPeriod.FinancialYear.Name.Equals(year) && x.IsActive)
                            .AsNoTracking().FirstOrDefaultAsync();
        }


        public async Task<IEnumerable<Application>> GetByNpoId(int npoId)
        {
            return await FindByCondition(x => x.NpoId.Equals(npoId) && x.IsActive)
                            .Include(x => x.ApplicationPeriod)
                                .ThenInclude(x => x.FinancialYear)
                            .AsNoTracking().ToListAsync();
        }

        public async Task<Application> GetByIds(int npoId, int financialYearId, int applicationTypeId)
        {
            return await FindByCondition(x => x.NpoId.Equals(npoId) && x.ApplicationPeriod.FinancialYearId.Equals(financialYearId) && x.ApplicationPeriod.ApplicationTypeId.Equals(applicationTypeId))
                            .AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task CreateEntity(Application model)
        {
            model.RefNo = StringExtensions.GenerateNewCode("APP");
            await CreateAsync(model);
        }

        public async Task UpdateEntity(Application model, int currentUserId)
        {
            var oldEntity = await this.RepositoryContext.Applications.FindAsync(model.Id);
            await UpdateAsync(oldEntity, model, true, currentUserId);
        }

        public async Task UpdateEntityQC(Application model, int currentUserId)
        {
            await UpdateAsync(model, false, currentUserId);
        }

        public async Task CreateNpoUserTracking(IEnumerable<NpoUserTracking> npoUserTrackings)
        {
            await this.RepositoryContext.NpoUserTrackings.AddRangeAsync(npoUserTrackings);
        }

        public async Task CreateNpoUserSatisfactionTracking(IEnumerable<NpoUserSatisfactionTracking> npoUserSatisfactionTracking)
        {
            await this.RepositoryContext.NpoUserSatisfactionTrackings.AddRangeAsync(npoUserSatisfactionTracking);
        }

        public async Task CreateNpoWorkPlanApproverTracking(IEnumerable<NpoWorkPlanApproverTracking> npoWorkPlanApproverTracking)
        {
            await this.RepositoryContext.NpoWorkPlanApproverTrackings.AddRangeAsync(npoWorkPlanApproverTracking);
        }

        public async Task CreateNpoUserReviewerTracking(IEnumerable<NpoWorkPlanReviewerTracking> npoWorkPlanReviewerTrackingList)
        {
            await this.RepositoryContext.NpoWorkPlanReviewerTrackings.AddRangeAsync(npoWorkPlanReviewerTrackingList);
        }

        #endregion
    }
}
