using NPOMS.Domain.Entities;
using NPOMS.Repository.Interfaces.Entities;
using NPOMS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Services.Implementation
{

    public class ProgrameDeliveryService : IProgrameDeliveryService
    {
        private IProgrameDeliveryRepository _programeDeliveryRepository;

        public ProgrameDeliveryService(
            IProgrameDeliveryRepository programeDeliveryRepository)
        {
            _programeDeliveryRepository = programeDeliveryRepository;

        }

        public Task<IEnumerable<ProgrammeServiceDelivery>> GetDeliveryDetailsByProgramId(int progId)
        {
            return _programeDeliveryRepository.GetDeliveryDetailsByProgramId(progId);
        }
    }
}
