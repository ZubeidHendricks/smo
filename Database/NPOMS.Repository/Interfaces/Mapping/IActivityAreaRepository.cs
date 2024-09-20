using NPOMS.Domain.Mapping;

namespace NPOMS.Repository.Interfaces.Mapping
{
    public interface IActivityAreaRepository : IBaseRepository<ActivityArea>
    {
        Task<ActivityArea> GetByModel(ActivityArea model);

        Task<IEnumerable<ActivityArea>> GetByActivityId(int activityId, bool isActive);
    }
}
