using NPOMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Services.Interfaces
{
    public interface IProgrameDeliveryService
    {
        Task<IEnumerable<ProgrammeServiceDelivery>> GetDeliveryDetailsByProgramId(int progId);
    }
}
