using NPOMS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
	public interface IMemberDetailRepository : IBaseRepository<MemberDetail>
	{
		/// <summary>
		/// Gets the MemberDetails by OrganisationalProfileId
		/// </summary>
		/// <param name="organisationalProfileId"></param>
		/// <returns></returns>
		Task<IEnumerable<MemberDetail>> GetMemberDetailsByIdAsync(int organisationalProfileId);

		/// <summary>
		/// Deletes the MemberDetail by Id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task DeleteMemberDetailByIdAsync(int id);
	}
}
