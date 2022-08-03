using NPOMS.Domain.Mapping;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Mapping
{
	public interface IObjectiveProgrammeRepository : IBaseRepository<ObjectiveProgramme>
	{
		Task<ObjectiveProgramme> GetByModel(ObjectiveProgramme model);

		Task<IEnumerable<ObjectiveProgramme>> GetByObjectiveId(int objectiveId);

		Task DeleteEntity(int objectiveId);
	}
}
