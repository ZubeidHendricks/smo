using NPOMS.Domain.Dropdown;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Dropdown
{
    public interface INPOIndicatorRepository : IBaseRepository<NPOIndicators>
    {
        Task<IEnumerable<NPOIndicators>> GetEntities(bool returnInactive);
        Task loadindicatorsAsync(List<NPOIndicators> data);
    }
}
