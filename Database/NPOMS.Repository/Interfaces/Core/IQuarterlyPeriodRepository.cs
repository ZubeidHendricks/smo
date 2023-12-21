using NPOMS.Domain.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Core
{
    public interface IQuarterlyPeriodRepository : IBaseRepository<QuarterlyPeriod>
    {
        Task<IEnumerable<QuarterlyPeriod>> GetEntities(bool returnInactive);

       // Task<IEnumerable<QuarterlyPeriod>> GetFromCurrentQuarterlyPeriod();

        Task<QuarterlyPeriod> GetById(int id);
    }
}
