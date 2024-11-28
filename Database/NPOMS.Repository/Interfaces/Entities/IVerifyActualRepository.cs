using NPOMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
    public interface IVerifyActualRepository: IBaseRepository<VerifyActual>
    {
        Task<IEnumerable<VerifyActual>> GetEntities();

        Task<VerifyActual> GetById(int id);

        Task<VerifyActual> GetVerifiedActualsByPeriodId(int actualId);

        Task<IEnumerable<VerifyActual>> GetByNpoId(int npoId);

        Task<VerifyActual> GetByIds(int financialYearId, int applicationTypeId);

        Task CreateEntity(VerifyActual model);

        Task UpdateEntity(VerifyActual model, int currentUserId);
        Task<IEnumerable<VerifyActual>> UpdateSDIPStatus(int applicationId, int finYear, int quarterId, int id);
       
    }
}
