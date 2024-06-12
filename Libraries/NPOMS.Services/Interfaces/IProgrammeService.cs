using NPOMS.Domain.Entities;
using System.Threading.Tasks;

namespace NPOMS.Services.Interfaces
{
    public interface IProgrammeService
    {
        Task CreateContact(ProgramContactInformation model, string userId);
        Task UpdateContact(ProgramContactInformation model, string userId);
        Task CreateBankDetails(ProgramBankDetails model, string userId);
        Task UpdateBankDetails(ProgramBankDetails model, string userId);
        Task CreateDelivery(ProgrammeServiceDelivery model, string userId);
        Task UpdateDelivery(ProgrammeServiceDelivery model, string userId);
    }
}
