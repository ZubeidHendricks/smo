using NPOMS.Domain.Entities;
using NPOMS.Domain.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
    public interface IProjectImplementationPlaceRepository : IBaseRepository<ProjectImplementationPlace>
    {
        Task<ProjectImplementationPlace> GetById(int id, int i);

        Task<IEnumerable<ProjectImplementationPlace>> GetImplementationPlaceByImplementationId(int geographicalDetailId);
        Task<IEnumerable<ProjectImplementationPlace>> GetAllImplementationPlaceByImplementationId(int geographicalDetailId);
    }
}
