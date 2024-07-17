using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Entities;
using NPOMS.Repository.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Entities
{
    public class ProgrameBankDetailRepository : BaseRepository<ProgramBankDetails>, IProgrameBankDetailRepository
    {

        public ProgrameBankDetailRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

        public async Task<IEnumerable<ProgramBankDetails>> GetBankDetailsByProgramId(int programmeId, int npoProfileId)
        {
            return await FindByCondition(x => x.ProgramId.Equals(programmeId) && x.IsActive && x.NpoProfileId == npoProfileId)
                             .Include(x => x.ApprovalStatus)
                             .AsNoTracking().ToListAsync();
        }
    }
}
