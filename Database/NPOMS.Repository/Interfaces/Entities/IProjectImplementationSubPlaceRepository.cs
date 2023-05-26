using NPOMS.Domain.Entities;
using NPOMS.Domain.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
    public interface IProjectImplementationSubPlaceRepository : IBaseRepository<ProjectImplementationSubPlace>
    {
        Task<ProjectImplementationSubPlace> GetById(int id, int i);

        Task<IEnumerable<ProjectImplementationSubPlace>> GetImplementationSubPlaceByImplementationId(int geographicalDetailId);
        Task<IEnumerable<ProjectImplementationSubPlace>> GetAllImplementationSubPlaceByImplementationId(int geographicalDetailId);
    }
}
