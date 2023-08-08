using NPOMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Services.Interfaces
{
    public interface IFundAppDocumentService
    {
        Task<IEnumerable<FundAppDocuments>> GetFundAppDocumentsAsync();

        Task<IEnumerable<FundAppDocuments>> GetFundAppDocumentByIdAsync(int id);

        Task CreateFundAppDocument(FundAppDocuments sp);

        Task DeleteFundAppDocument(FundAppDocuments sp);
    }
}
