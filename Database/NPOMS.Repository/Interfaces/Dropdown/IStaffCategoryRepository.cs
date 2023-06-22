using NPOMS.Domain.Dropdown;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Dropdown
{
	public interface IStaffCategoryRepository : IBaseRepository<StaffCategory>
	{
		Task<IEnumerable<StaffCategory>> GetEntities(bool returnInactive);
	}
}
