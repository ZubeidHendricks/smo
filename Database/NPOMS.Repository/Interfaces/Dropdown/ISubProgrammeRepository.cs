using NPOMS.Domain.Dropdown;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Dropdown
{
	public interface ISubProgrammeRepository : IBaseRepository<SubProgramme>
	{
		Task<IEnumerable<SubProgramme>> GetEntities(bool returnInactive);

		Task<IEnumerable<SubProgramme>> GetByProgrammeId(int programmeId);
        Task<List<SubProgramme>> GetByProgId(int programmeId);
    }
}
