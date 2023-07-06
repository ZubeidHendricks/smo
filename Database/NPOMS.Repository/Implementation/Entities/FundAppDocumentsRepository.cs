using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Entities;
using NPOMS.Repository.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Entities
{
    public class FundAppDocumentsRepository : BaseRepository<FundAppDocuments>, IFundAppDocumentRepository
    {
        public FundAppDocumentsRepository(RepositoryContext repositoryContext)
    : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<FundAppDocuments>> GetFundAppDocumentsAsync()
        {
            return await FindAll().AsNoTracking()
               .OrderBy(ow => ow.ID).ToListAsync();
        }

        public async Task<IEnumerable<FundAppDocuments>> GetFundAppDocumentByIdAsync(int id)
        {
            return await FindByCondition(sp => sp.ID.Equals(id))
                .OrderByDescending(ow => ow.ID).ToListAsync();
        }

        public async Task CreateFundAppDcoument(FundAppDocuments sp)
        {
            sp.IsActive = true;
            await CreateAsync(sp);
        }

        public async Task DeleteFundAppDocument(FundAppDocuments sp)
        {
            await DeleteAsync(sp);

        }
    }
}
