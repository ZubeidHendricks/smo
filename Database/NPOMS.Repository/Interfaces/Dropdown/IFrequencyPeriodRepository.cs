using NPOMS.Domain.Dropdown;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Dropdown
{
	public interface IFrequencyPeriodRepository : IBaseRepository<FrequencyPeriod>
	{
		Task<IEnumerable<FrequencyPeriod>> GetEntities(bool returnInactive);

		Task<IEnumerable<FrequencyPeriod>> GetByFrequencyId(int frequencyId);
	}
}
