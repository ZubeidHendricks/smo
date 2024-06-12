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
    public class ProgrameDeliveryRepository : BaseRepository<ProgrammeServiceDelivery>, IProgrameDeliveryRepository
    {

        public ProgrameDeliveryRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

        public async Task<IEnumerable<ProgrammeServiceDelivery>> GetDeliveryDetailsByProgramId(int progId)
        {
            return await FindByCondition(x => x.ProgramId.Equals(progId))
                           .AsNoTracking().ToListAsync();
        }
    }
}
