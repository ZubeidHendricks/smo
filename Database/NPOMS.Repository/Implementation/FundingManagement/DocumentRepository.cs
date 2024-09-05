using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.FundingManagement;
using NPOMS.Repository.Interfaces.FundingManagement;

namespace NPOMS.Repository.Implementation.FundingManagement
{
    public class DocumentRepository : BaseRepository<Document>, IDocumentRepository
    {
        #region Constructors

        public DocumentRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

        #endregion

        #region Methods

        public async Task<Document> GetByFundingCaptureId(int fundingCaptureId)
        {
            return await FindByCondition(x => x.FundingCaptureId.Equals(fundingCaptureId)).AsNoTracking().FirstOrDefaultAsync();
        }

        #endregion
    }
}
