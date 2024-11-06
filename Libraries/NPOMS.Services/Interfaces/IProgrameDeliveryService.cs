using NPOMS.Domain.Dropdown;
using NPOMS.Domain.Entities;
using NPOMS.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Services.Interfaces
{
    public interface IProgrameDeliveryService
    {
        Task<IEnumerable<ProgrammeServiceDeliveryVM>> GetDeliveryDetailsByProgramId(int programmeId, int npoProfileId);
        Task<IEnumerable<ServiceDeliveryArea>> GetServiveDeliveryMasterByProgramId(int programmeId, int npoProfileId);
        
        Task<IEnumerable<ProgrammeServiceDeliveryVM>> GetDeliveryDetails(int npoProfileId);
    }
}
