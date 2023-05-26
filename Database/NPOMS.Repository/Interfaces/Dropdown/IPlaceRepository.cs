using NPOMS.Domain.Dropdown;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Dropdown
{
    public interface IPlaceRepository : IBaseRepository<Place>
    {
        Task<IEnumerable<Place>> GetEntities(bool returnInactive);
        Task<Place> GetById(int id);
    }
}
