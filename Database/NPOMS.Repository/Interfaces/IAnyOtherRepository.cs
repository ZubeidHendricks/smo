using NPOMS.Domain.Entities;
using NPOMS.Repository.Implementation.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces
{
    public interface IAnyOtherRepository : IBaseRepository<AnyOtherInformationReport>
    {
        Task<IEnumerable<AnyOtherInformationReport>> GetEntities();

        Task<AnyOtherInformationReport> GetById(int id);

        Task<IEnumerable<AnyOtherInformationReport>> GetByPeriodId(int applicationPeriodId);

        Task<IEnumerable<AnyOtherInformationReport>> GetByNpoId(int npoId);

        Task<AnyOtherInformationReport> GetByIds(int financialYearId, int applicationTypeId);

        Task CreateEntity(AnyOtherInformationReport model);

        Task UpdateEntity(AnyOtherInformationReport model, int currentUserId);
        Task UpdateEntityQC(AnyOtherInformationReport model, int currentUserId);
        Task UpdateAnyOtherStatus(int applicationId, int finYear, int quarterId, int id);
    }
}
