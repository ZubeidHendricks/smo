using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Dropdown;
using NPOMS.Domain.Entities;
using NPOMS.Repository.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Entities
{
    public class ProgrameContactDetailRepository : BaseRepository<ProgramContactInformation>, IProgrameContactDetailRepository
    {

        public ProgrameContactDetailRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

        public async Task<IEnumerable<ProgramContactInformation>> GetContactDetailsByProgramId(int programmeId, int npoProfileId)
        {
            return await FindByCondition(x => x.ProgrammeId.Equals(programmeId) && x.IsActive && x.NpoProfileId == npoProfileId)
                           .Include(x => x.Title)
                           .Include(x => x.Position)
                           .Include(x => x.Gender)
                           .Include(x => x.Race)
                           .Include(x => x.Language)
                           .Include(x => x.ApprovalStatus)
                           .AsNoTracking()
                           .ToListAsync();
        }

        public async Task<IEnumerable<ProgramContactInformation>> GetContactDetails(int npoProfileId)
        {
            return await FindByCondition(x => x.IsActive && x.NpoProfileId == npoProfileId)
                           .Include(x => x.Title)
                           .Include(x => x.Position)
                           .Include(x => x.Gender)
                           .Include(x => x.Race)
                           .Include(x => x.Language)
                           .Include(x => x.ApprovalStatus)
                           .AsNoTracking()
                           .ToListAsync();
        }

        public async Task<IEnumerable<ProgramContactInformation>> GetContactDetailsByIds(int programmeId, int npoProfileId, int subProgramId, int subProgramTypeId)
        {
            return await FindByCondition(x => x.IsActive
                            && x.SubProgrammeId.Equals(subProgramId)
                            && x.SubProgrammeTypeId.Equals(subProgramTypeId)        
                            && x.NpoProfileId == npoProfileId)
                           .Include(x => x.Title)
                           .Include(x => x.Position)
                           .Include(x => x.Gender)
                           .Include(x => x.Race)
                           .Include(x => x.Language)
                           .Include(x => x.ApprovalStatus)
                           .AsNoTracking()
                           .ToListAsync();
        }

    }
}
