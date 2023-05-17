using NPOMS.Domain.Dropdown;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Dropdown
{
    public interface IPropertySubTypeRepository : IBaseRepository<PropertySubType>
    {
        Task<IEnumerable<PropertySubType>> GetEntities(bool returnInactive);
        Task<PropertySubType> GetById(int id);

    }
}
