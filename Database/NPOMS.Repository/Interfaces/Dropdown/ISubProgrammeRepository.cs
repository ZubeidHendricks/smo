using NPOMS.Domain.Dropdown;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Dropdown
{
	public interface ISubProgrammeRepository : IBaseRepository<SubProgramme>
	{
		Task<IEnumerable<SubProgramme>> GetEntities(bool returnInactive);
	}
}
