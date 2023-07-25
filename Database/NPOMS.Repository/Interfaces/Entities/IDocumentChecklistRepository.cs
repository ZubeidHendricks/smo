using NPOMS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
	public interface IDocumentChecklistRepository : IBaseRepository<DocumentChecklist>
	{
		Task<IEnumerable<DocumentChecklist>> GetByFundingApplicationIdAsync(int fundingApplicationId);
	}
}
