using NPOMS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
	public interface ICompliantCycleRepository : IBaseRepository<CompliantCycle>
	{
		Task<IEnumerable<CompliantCycle>> GetCompliantCyclesByIds(int departmentId, int financialYearId);
	}
}
