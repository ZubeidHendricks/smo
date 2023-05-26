using NPOMS.Domain.Dropdown;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Dropdown
{
    public interface IDistrictCouncilRepository : IBaseRepository<DistrictCouncil>
    {
        Task<IEnumerable<DistrictCouncil>> GetEntities(bool returnInactive);
        Task<DistrictCouncil> GetById(int id);

    }
}
