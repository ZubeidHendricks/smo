using NPOMS.Domain.Mapping;

namespace NPOMS.Repository.Interfaces.Mapping
{
    public interface IActivitySubStructureRepository : IBaseRepository<ActivitySubStructure>
    {
        Task<ActivitySubStructure> GetByModel(ActivitySubStructure model);

        Task<IEnumerable<ActivitySubStructure>> GetByActivityId(int activityId, bool isActive);
    }
}
