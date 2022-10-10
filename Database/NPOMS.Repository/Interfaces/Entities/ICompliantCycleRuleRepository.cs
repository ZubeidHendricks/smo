using NPOMS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
	public interface ICompliantCycleRuleRepository : IBaseRepository<CompliantCycleRule>
	{
		Task<IEnumerable<CompliantCycleRule>> GetEntities(bool returnInactive);

		Task<CompliantCycleRule> GetById(int id);
	}
}
