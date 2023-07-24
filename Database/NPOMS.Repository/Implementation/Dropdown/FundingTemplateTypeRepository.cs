using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Dropdown;
using NPOMS.Repository.Interfaces.Dropdown;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace NPOMS.Repository.Implementation.Dropdown
{
    public class FundingTemplateTypeRepository : BaseRepository<FundingTemplateType>, IFundingTemplateTypeRepository
    {
        #region Constructors

        public FundingTemplateTypeRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

        #endregion

        #region Methods

        public async Task<IEnumerable<FundingTemplateType>> GetAllAsync(bool returnInactive)
        {
            if (returnInactive)
                return await FindAll().AsNoTracking().ToListAsync();
            else
                return await FindAll().Where(x => x.IsActive).AsNoTracking().ToListAsync();
        }

        #endregion
    }
}