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

        public async Task<IEnumerable<ProgramBankDetails>> GetBankDetailsByProgramId(int progId)
        {
            return await FindByCondition(x => x.ProgramId.Equals(progId) && x.IsActive)
                             .AsNoTracking().ToListAsync();
        }
    }
}
