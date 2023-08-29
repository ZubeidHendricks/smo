using NPOMS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
	public interface IMyContentLinkRepository : IBaseRepository<MyContentLink>
	{
		Task<IEnumerable<MyContentLink>> GetByApplicationId(int applicationId);
	}
}
