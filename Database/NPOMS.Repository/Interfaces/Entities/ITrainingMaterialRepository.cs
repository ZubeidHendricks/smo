using NPOMS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
	public interface ITrainingMaterialRepository : IBaseRepository<TrainingMaterial>
	{
		Task<IEnumerable<TrainingMaterial>> GetEntities(bool returnInactive);
	}
}
