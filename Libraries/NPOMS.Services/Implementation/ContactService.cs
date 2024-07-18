using NPOMS.Repository.Interfaces.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using NPOMS.Services.Interfaces;
using NPOMS.Domain.Entities;

namespace NPOMS.Services.Implementation
{
    public class ContactService : IContactService
    {
        private IProgrameContactDetailRepository _programeContactDetailRepository;

        public ContactService(
            IProgrameContactDetailRepository programeContactDetailRepository)
        {
            _programeContactDetailRepository = programeContactDetailRepository;

        }

        public Task<IEnumerable<ProgramContactInformation>> GetContactDetailsByProgramId(int programmeId, int npoProfileId)
        {
            return _programeContactDetailRepository.GetContactDetailsByProgramId(programmeId,npoProfileId);
        }

        public Task<IEnumerable<ProgramContactInformation>> GetContactDetails(int npoProfileId)
        {
            return _programeContactDetailRepository.GetContactDetails(npoProfileId);
        }

    }
}
