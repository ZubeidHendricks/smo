using NPOMS.Domain.Mapping;

namespace NPOMS.Repository.Interfaces.Mapping
{

    public interface IActivityManicipalityRepository : IBaseRepository<ActivityManicipality>
    {
        Task<ActivityManicipality> GetByModel(ActivityManicipality model);

        Task<IEnumerable<ActivityManicipality>> GetByActivityId(int activityId, bool isActive);
    }
}
