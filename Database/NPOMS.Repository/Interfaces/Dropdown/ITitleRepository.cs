using NPOMS.Domain.Dropdown;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Dropdown
{
	public interface ITitleRepository : IBaseRepository<Title>
	{
		Task<IEnumerable<Title>> GetEntities(bool returnInactive);
	}
}
