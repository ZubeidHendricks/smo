using NPOMS.Domain.Dropdown;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Dropdown
{
    public interface IPropertyTypeRepository : IBaseRepository<PropertyType>
    {
        Task<IEnumerable<PropertyType>> GetEntities(bool returnInactive);

        Task<PropertyType> GetById(int id);

    }
}
