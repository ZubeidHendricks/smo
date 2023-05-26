using NPOMS.Domain.Dropdown;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Dropdown
{
    public interface ILocalMunicipalityRepository : IBaseRepository<LocalMunicipality>
    {
        Task<IEnumerable<LocalMunicipality>> GetEntities(bool returnInactive);
        Task<LocalMunicipality> GetById(int id);
    }
}
