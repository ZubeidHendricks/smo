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

        public async Task<IEnumerable<ProgramBankDetails>> GetBankDetailsByIds(int npoProfileId)
        {
            return await FindByCondition(x => x.IsActive && x.NpoProfileId == npoProfileId)
                             .Include(x => x.ApprovalStatus)
                             .AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<ProgramBankDetails>> GetBankDetailsByIds(int programmeId, int npoProfileId, int subProgramId, int subProgramTypeId)
        {
            return await FindByCondition(x => x.IsActive
                            && x.SubProgrammeId.Equals(subProgramId)
                            && x.SubProgrammeTypeId.Equals(subProgramTypeId)
                            && x.NpoProfileId == npoProfileId)
                             .Include(x => x.ApprovalStatus)
                             .AsNoTracking().ToListAsync();
        }

        public async Task<ProgramBankDetails> GetById(int id)
        {
            return await FindByCondition(x => x.Id.Equals(id)).AsNoTracking().FirstOrDefaultAsync();
        }
    }
}
