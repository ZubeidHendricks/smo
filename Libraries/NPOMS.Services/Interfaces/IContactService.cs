using NPOMS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Services.Interfaces
{
    public interface IContactService
    {
        Task<IEnumerable<ProgramContactInformation>> GetContactDetailsByProgramId(int programmeId, int npoProfileId);
    }
}
