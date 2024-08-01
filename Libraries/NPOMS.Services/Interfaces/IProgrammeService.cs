using NPOMS.Domain.Entities;
using NPOMS.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Services.Interfaces
{
    public interface IProgrammeService
    {
        Task CreateContact(ProgramContactInformation model, string userId, int npoProfileId);
        Task UpdateContact(ProgramContactInformation model, string userId, int npoProfileId);
        Task CreateBankDetails(ProgramBankDetails model, string userId, int npoProfileId);
        Task UpdateBankDetails(ProgramBankDetails model, string userId, int npoProfileId);
        Task CreateDelivery(ProgrammeServiceDeliveryVM model, string userId, int npoProfileId);
        Task UpdateDelivery(ProgrammeServiceDeliveryVM model, string userId, int npoProfileId);
        Task UpdateDeliveryAreaSelection(string userId, int id, bool selection);
        Task UpdateBankSelection(string userId, int id, bool selection, int npoId);
        Task<IEnumerable<ProgramBankDetails>> GetBankDetailsByIds(int programmeId, int npoProfileId, int subProgramId, int subProgramTypeId);
        Task<IEnumerable<ProgrammeServiceDelivery>> GetDeliveryDetailsByIds(int programmeId, int npoProfileId, int subProgramId, int subProgramTypeId);
        Task<IEnumerable<ProgramContactInformation>> GetContactDetailsByIds(int programmeId, int npoProfileId, int subProgramId, int subProgramTypeId);
    }
}
