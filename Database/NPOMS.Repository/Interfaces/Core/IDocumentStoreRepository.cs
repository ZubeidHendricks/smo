using NPOMS.Domain.Core;
using System.Linq;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Core
{
	public interface IDocumentStoreRepository : IBaseRepository<DocumentStore>
	{
		IQueryable<DocumentStore> GetEntities();
        IQueryable<DocumentStore> GetEntitiesByDocId(int docTypeId);
        IQueryable<DocumentStore> GetDocumentByRefNo(string docTypeId);        

        Task CreateEntity(DocumentStore entity);

		Task UpdateEntity(DocumentStore entity, int currentUserId);

		Task DeleteEntity(DocumentStore entity);
	}
}
