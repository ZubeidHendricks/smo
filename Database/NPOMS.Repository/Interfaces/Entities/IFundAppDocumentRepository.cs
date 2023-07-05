using NPOMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
    public interface IFundAppDocumentRepository : IBaseRepository<FundAppDocuments>
    {
        Task<IEnumerable<FundAppDocuments>> GetFundAppDocumentsAsync();

        Task<IEnumerable<FundAppDocuments>> GetFundAppDocumentByIdAsync(int id);

        Task CreateFundAppDcoument(FundAppDocuments sp);

        Task DeleteFundAppDocument(FundAppDocuments sp);
    }
}
