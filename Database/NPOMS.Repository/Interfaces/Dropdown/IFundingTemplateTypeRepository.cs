using NPOMS.Domain.Dropdown;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Dropdown
{
    public interface IFundingTemplateTypeRepository : IBaseRepository<FundingTemplateType>
    {
        Task<IEnumerable<FundingTemplateType>> GetAllAsync(bool returnInactive);
    }
}
