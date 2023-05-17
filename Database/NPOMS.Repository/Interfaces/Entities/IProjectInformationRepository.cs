using NPOMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
    public interface IProjectInformationRepository :IBaseRepository<ProjectInformation>
    {
        Task<IEnumerable<ProjectInformation>> GetEntities(int applicationId);

        Task CreateEntity(ProjectInformation model);

        Task UpdateEntity(ProjectInformation model, int currentUserId);

        Task<ProjectInformation> GetById(int id);
    }
}
