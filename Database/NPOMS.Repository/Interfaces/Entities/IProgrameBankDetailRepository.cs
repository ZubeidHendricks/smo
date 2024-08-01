using NPOMS.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
    public interface IProgrameBankDetailRepository : IBaseRepository<ProgramBankDetails>
    {
        Task<IEnumerable<ProgramBankDetails>> GetBankDetailsByProgramId(int programmeId, int npoProfileId);
        Task<IEnumerable<ProgramBankDetails>> GetBankDetailsByIds(int npoProfileId);
        Task<IEnumerable<ProgramBankDetails>> GetBankDetailsByIds(int programmeId, int npoProfileId, int subProgramId, int subProgramTypeId);
    }
}
