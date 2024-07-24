using NPOMS.Domain.Mapping;

namespace NPOMS.Repository.Interfaces.Mapping
{

    public interface IActivitySubDistrictRepository : IBaseRepository<ActivitySubDistrict>
    {
        Task<ActivitySubDistrict> GetByModel(ActivitySubDistrict model);

        Task<IEnumerable<ActivitySubDistrict>> GetByActivityId(int activityId, bool isActive);
    }
}
