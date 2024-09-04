using NPOMS.Domain.FundingManagement;

namespace NPOMS.Repository.Interfaces.FundingManagement
{
    public interface IDocumentRepository : IBaseRepository<Document>
    {
        Task<Document> GetByFundingCaptureId(int fundingCaptureId);
    }
}
