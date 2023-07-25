using NPOMS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
	public interface IImplementationTimelineRepository : IBaseRepository<ImplementationTimeline>
	{
		Task<IEnumerable<ImplementationTimeline>> GetByFundingApplicationIdAsync(int fundingApplicationId);

		Task DeleteImplementationTimelineByIdAsync(int id);
	}
}
