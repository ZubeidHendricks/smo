using NPOMS.Domain.Mapping;

namespace NPOMS.Repository.Interfaces.Mapping
{
	public interface IActivitySubProgrammeRepository : IBaseRepository<ActivitySubProgramme>
	{
		Task<ActivitySubProgramme> GetByModel(ActivitySubProgramme model);

		Task<IEnumerable<ActivitySubProgramme>> GetByActivityId(int activityId, bool isActive);
	}
}
