using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Core;
using NPOMS.Repository.Interfaces.Core;
using System.Linq;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Core
{
	public class DocumentStoreRepository : BaseRepository<DocumentStore>, IDocumentStoreRepository
    {
        #region Constructors

        public DocumentStoreRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

        #endregion

        #region Methods

        public IQueryable<DocumentStore> GetEntities()
        {
            return FindAll().Where(x => x.IsActive).Include(x => x.DocumentType);
        }

        public IQueryable<DocumentStore> GetEntitiesByDocId(int docTypeId)
        {
            return FindAll().Where(x => x.DocumentTypeId == docTypeId).Include(x => x.DocumentType);
        }

        public async Task CreateEntity(DocumentStore entity)
        {
            await CreateAsync(entity);
        }

        public async Task UpdateEntity(DocumentStore entity, int currentUserId)
        {
            await UpdateAsync(null, entity, false, currentUserId);
        }

        public async Task DeleteEntity(DocumentStore entity)
        {
            await DeleteAsync(entity);
        }

        #endregion
    }
}
