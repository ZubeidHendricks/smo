using NPOMS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
	public interface IBusinessesSupportedListRepository : IBaseRepository<BusinessesSupportedList>
	{
		/// <summary>
		/// Gets the BusinessesSupportedList by ProjectDescriptionId
		/// </summary>
		/// <param name="projectDescriptionId"></param>
		/// <returns></returns>
		Task<IEnumerable<BusinessesSupportedList>> GetByProjectDescriptionIdAsync(int projectDescriptionId);

		/// <summary>
		/// Deletes the BusinessesSupportedList by Id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task DeleteBusinessesSupportedListByIdAsync(int id);
	}
}
