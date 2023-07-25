using NPOMS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
	public interface ISuccessStoryRepository : IBaseRepository<SuccessStory>
	{
		/// <summary>
		/// Gets the SuccessStories by ProjectImpactId
		/// </summary>
		/// <param name="projectImpactId"></param>
		/// <returns></returns>
		Task<IEnumerable<SuccessStory>> GetSuccessStoriesByIdAsync(int projectImpactId);

		/// <summary>
		/// Deletes the SuccessStory by Id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task DeleteSuccessStoryByIdAsync(int id);
	}
}
