using NPOMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
    public interface IMonitoringEvaluationRepository : IBaseRepository<MonitoringEvaluation>
    {
        Task<IEnumerable<MonitoringEvaluation>> GetEntities(int applicationId);

        Task CreateEntity(MonitoringEvaluation model);

        Task UpdateEntity(MonitoringEvaluation model, int currentUserId);

        Task<MonitoringEvaluation> GetById(int? id);
    }
}
