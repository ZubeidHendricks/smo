using NPOMS.Domain.Dropdown;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Dropdown
{
	public interface IFrequencyRepository : IBaseRepository<Frequency>
	{
		Task<IEnumerable<Frequency>> GetEntities(bool returnInactive);
	}
}
