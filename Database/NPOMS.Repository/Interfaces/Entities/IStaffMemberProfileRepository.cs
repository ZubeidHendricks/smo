using NPOMS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
	public interface IStaffMemberProfileRepository : IBaseRepository<StaffMemberProfile>
	{
		Task<IEnumerable<StaffMemberProfile>> GetByNpoProfileId(int npoProfileId);

		Task UpdateEntity(StaffMemberProfile model, int currentUserId);
	}
}
