using NPOMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
    public interface ISDIPRepository : IBaseRepository<SDIPReport>
    {

        Task<IEnumerable<SDIPReport>> GetEntities();

        Task<SDIPReport> GetById(int id);

        Task<IEnumerable<SDIPReport>> GetByPeriodId(int applicationPeriodId);

        Task<IEnumerable<SDIPReport>> GetByNpoId(int npoId);

        Task<SDIPReport> GetByIds(int financialYearId, int applicationTypeId);

        Task CreateEntity(SDIPReport model);

        Task UpdateEntity(SDIPReport model, int currentUserId);
        Task<IEnumerable<SDIPReport>> UpdateSDIPStatus(int applicationId, int finYear, int quarterId, int id);
        Task<IEnumerable<SDIPReport>> CompleteSDIPReport(int applicationId, int financialId, int quarterId, int currentUserId);
    }
}
