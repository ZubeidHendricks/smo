using NPOMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
    public interface IProgrameDeliveryRepository : IBaseRepository<ProgrammeServiceDelivery>
    {
        Task<IEnumerable<ProgrammeServiceDelivery>> GetDeliveryDetailsByProgramId(int programmeId, int npoProfileId);
        Task<IEnumerable<ProgrammeServiceDelivery>> GetDeliveryyProgramId(int programmeId, int npoProfileId);

    }
}
