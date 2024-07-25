using NPOMS.Domain.Mapping;

namespace NPOMS.Repository.Interfaces.Mapping
{
    public interface IActivityDistrictRepository : IBaseRepository<ActivityDistrict>
    {
        Task<ActivityDistrict> GetByModel(ActivityDistrict model);

        Task<IEnumerable<ActivityDistrict>> GetByActivityId(int activityId, bool isActive);
    }
}
