using NPOMS.Domain.Entities;
using NPOMS.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Services.Interfaces
{
    public interface IVerifyActualService 
    {
        Task<IEnumerable<VerifyActual>> GetVerifiedActuals();

        Task<VerifyActual> GetVerifiedActualsById(int id);

        Task<VerifyActual> GetVerifiedActualsByPeriodId(int actualId, int quarterId);

        Task<IEnumerable<VerifyActual>> GetVerifiedActualsByNpoId(int npoId);

        Task<VerifyActual> GetVerifiedActualsByIds(int financialYearId, int applicationTypeId);

        Task CreateVerifiedActualsEntity(VerifyActual model, string userIdentifier);

        Task UpdateVerifiedActualsEntity(VerifyActual model, string currentUserId);
        Task<IEnumerable<VerifyActual>> UpdateVerifiedActualsStatus(BaseCompleteViewModel model, string userIdentifier);


        Task CreateAudit(VerifyActual audit, string currentUderId);
    }
}
