using NPOMS.Domain.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Core
{
	public interface IDocumentTypeRepository : IBaseRepository<DocumentType>
	{
		Task<IEnumerable<DocumentType>> GetEntities(bool returnInactive);
	}
}
