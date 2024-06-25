using NPOMS.Domain.Entities;
using NPOMS.Services.Models;
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
    }
}
