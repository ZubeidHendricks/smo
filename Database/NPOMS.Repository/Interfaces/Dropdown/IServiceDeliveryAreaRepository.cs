using NPOMS.Domain.Dropdown;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Dropdown
{
    public interface IServiceDeliveryAreaRepository : IBaseRepository<ServiceDeliveryArea>
    {
        Task<IEnumerable<ServiceDeliveryArea>> GetEntities(bool returnInactive);

        Task<ServiceDeliveryArea> GetById(int id);
    }
}
