using NPOMS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
    public interface IControlRepository : IBaseRepository<Control>
    {
        Task<IEnumerable<Control>> GetEntities(bool returnInactive);

        Task<Control> GetById(int id);

        Task<Control> GetByType(string type);
    }
}
