using NPOMS.Domain.Core;
using NPOMS.Domain.Dropdown;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Dropdown
{
	public interface IProgrammeRepository : IBaseRepository<Programme>
	{
		Task<IEnumerable<Programme>> GetEntities(bool returnInactive);

		Task<Programme> GetById(int id);
        Task<IEnumerable<Programme>> GetProgramsByDepartment(string name, int id);

        Task<List<int>> GetProgrammesIdOfLoggenInUserAsync(int userid);
    }
}
