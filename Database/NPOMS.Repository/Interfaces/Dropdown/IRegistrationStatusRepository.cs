using NPOMS.Domain.Dropdown;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Dropdown
{
	public interface IRegistrationStatusRepository : IBaseRepository<RegistrationStatus>
	{
		Task<IEnumerable<RegistrationStatus>> GetEntities(bool returnInactive);

		Task<RegistrationStatus> GetById(int id);
	}
}
