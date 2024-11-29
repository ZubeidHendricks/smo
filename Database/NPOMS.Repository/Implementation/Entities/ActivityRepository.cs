using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Entities;
using NPOMS.Domain.Mapping;
using NPOMS.Repository.Interfaces.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Entities
{
    public class ActivityRepository : BaseRepository<Activity>, IActivityRepository
    {
        #region Constructors

        public ActivityRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

        #endregion

        #region Methods

        //public async Task<IEnumerable<Activity>> GetByApplicationId(int applicationId)
        //{
        //    return await FindByCondition(x => x.ApplicationId.Equals(applicationId))
        //              .Include(x => x.ActivityDistrict)
        //              .Include(x => x.ActivitySubDistrict)
        //              .Include(x => x.ActivitySubStructure)
        //              .Include(x => x.ActivityManicipality)
        //              .Include(x => x.ActivityArea)
        //              .Include(x => x.Objective).Include(x => x.ActivityType)
        //              .Include(x => x.ActivityList).AsNoTracking().ToListAsync();
        //}

        public async Task<IEnumerable<Activity>> GetByApplicationId(int applicationId)
        {
            var activities = await FindByCondition(x => x.ApplicationId.Equals(applicationId))
                        .Include(x => x.ActivityDistrict)
                        .Include(x => x.ActivitySubDistrict)
                        .Include(x => x.ActivitySubStructure)
                        .Include(x => x.ActivityManicipality)
                        .Include(x => x.ActivityArea)
                        .Include(x => x.Objective).Include(x => x.ActivityType)
                        .Include(x => x.ActivityList).AsNoTracking().ToListAsync();

            // Apply filtering for active related entities
            foreach (var activity in activities)
            {
                activity.ActivityDistrict = activity?.ActivityDistrict?.Where(d => d.IsActive).ToList();
                activity.ActivitySubDistrict = activity?.ActivitySubDistrict?.Where(sd => sd.IsActive).ToList();
                activity.ActivitySubStructure = activity?.ActivitySubStructure?.Where(ss => ss.IsActive).ToList();
                activity.ActivityManicipality = activity?.ActivityManicipality?.Where(m => m.IsActive).ToList();
                activity.ActivityArea = activity?.ActivityArea?.Where(a => a.IsActive).ToList();
            }

            return activities;
        }

        public async Task<IEnumerable<Activity>> GetByCfpApplicationId(int applicationId)
        {
            var activities = await FindByCondition(x => x.ApplicationId.Equals(applicationId))
                        .Include(x => x.ActivityDistrict)
                        .Include(x => x.ActivitySubDistrict)
                        .Include(x => x.ActivitySubStructure)
                        .Include(x => x.ActivityManicipality)
                        .Include(x => x.ActivityArea)
                        .Include(x => x.Objective).Include(x => x.ActivityType)
                        .Include(x => x.ActivityList).AsNoTracking().ToListAsync();

            return activities;
        }
        public async Task<IEnumerable<Activity>> GetByObjectiveId(int objectiveId)
        {
            return await FindByCondition(x => x.ObjectiveId.Equals(objectiveId) && x.IsActive).AsNoTracking().ToListAsync();
        }

        public async Task CreateEntity(Activity model)
        {
            await CreateAsync(model);
        }
       
        public async Task UpdateEntity(Activity model, int currentUserId)
		{
			var oldEntity = await this.RepositoryContext.Activities.FindAsync(model.Id);
			await UpdateAsync(oldEntity, model, true, currentUserId);
		}

        public async Task<Activity> GetById(int id)
        {
            var activity =  await FindByCondition(x => x.Id.Equals(id))
                            .Include(x => x.ActivitySubProgrammes)
                            .Include(x => x.ActivityFacilityLists)
                            .Include(x => x.ActivityList)
                            .Include(x => x.ActivityRecipients)
                            .Include(x => x.ActivityDistrict)
                            .Include(x => x.ActivitySubDistrict)
                            .Include(x => x.ActivitySubStructure)
                            .Include(x => x.ActivityManicipality)
                                  .Include(x => x.ActivityArea)
                                  .AsNoTracking().FirstOrDefaultAsync();

            if (activity != null)
            {
                activity.ActivityDistrict = activity?.ActivityDistrict?.Where(d => d.IsActive).ToList();
                activity.ActivitySubDistrict = activity?.ActivitySubDistrict?.Where(sd => sd.IsActive).ToList();
                activity.ActivitySubStructure = activity?.ActivitySubStructure?.Where(ss => ss.IsActive).ToList();
                activity.ActivityManicipality = activity?.ActivityManicipality?.Where(m => m.IsActive).ToList();
                activity.ActivityArea = activity?.ActivityArea?.Where(a => a.IsActive).ToList();
            }

            return activity;
        }

        public async Task<Activity> GetCfpActivityById(int id)
        {
            var activity = await FindByCondition(x => x.Id.Equals(id))
                            .Include(x => x.ActivitySubProgrammes)
                            .Include(x => x.ActivityFacilityLists)
                            .Include(x => x.ActivityList)
                            .Include(x => x.ActivityRecipients)
                            .Include(x => x.ActivityDistrict)
                            .Include(x => x.ActivitySubDistrict)
                            .Include(x => x.ActivitySubStructure)
                            .Include(x => x.ActivityManicipality)
                                  .Include(x => x.ActivityArea)
                                  .AsNoTracking().FirstOrDefaultAsync();

            return activity;
        }
        public async Task<IEnumerable<Activity>> GetByAll()
        {
            return await FindByCondition(x => x.IsActive).AsNoTracking().ToListAsync();
        }

        //public async Task<Activity> GetById(int id)
        //{
        //    var activity = await FindByCondition(x => x.Id == id)
        //        .Include(x => x.ActivitySubProgrammes)
        //        .Include(x => x.ActivityFacilityLists)
        //        .Include(x => x.ActivityList)
        //        .Include(x => x.ActivityRecipients)
        //        .Include(x => x.ActivityDistrict)
        //        .Include(x => x.ActivitySubDistrict)
        //        .Include(x => x.ActivitySubStructure)
        //        .Include(x => x.ActivityManicipality)
        //        .Include(x => x.ActivityArea)
        //        .AsNoTracking()
        //        .FirstOrDefaultAsync();

        //    // Filter out inactive entities after retrieval
        //    if (activity != null)
        //    {
        //        activity.ActivityDistrict = activity.ActivityDistrict.Where(d => d.IsActive).ToList();
        //        activity.ActivitySubDistrict = activity.ActivitySubDistrict.Where(sd => sd.IsActive).ToList();
        //        activity.ActivitySubStructure = activity.ActivitySubStructure.Where(ss => ss.IsActive).ToList();
        //        activity.ActivityManicipality = activity.ActivityManicipality.Where(m => m.IsActive).ToList();
        //        activity.ActivityArea = activity.ActivityArea.Where(a => a.IsActive).ToList();
        //    }

        //    return activity;
        //}


        #endregion
    }
}
