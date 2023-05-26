using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Dropdown;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Dropdown
{
    public interface IRegionRepository : IBaseRepository<Region>
    {
        Task<IEnumerable<Region>> GetEntities(bool returnInactive);
        Task<Region> GetById(int id);
        
    }
}
