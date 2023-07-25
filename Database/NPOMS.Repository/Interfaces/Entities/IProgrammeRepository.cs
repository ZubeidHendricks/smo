using NPOMS.Domain.Dropdown;
using NPOMS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
	public interface IProgrammeRepository : IBaseRepository<Domain.Dropdown.Programme>
	{
		Task<IEnumerable<Programme>> GetAllProgrammesAsync();

		Task CreateProgramme(Programme model);

		Task<Programme> GetProgrammeByIdAsync(int id);

		Task UpdateProgramme(Programme model);
	}
}
