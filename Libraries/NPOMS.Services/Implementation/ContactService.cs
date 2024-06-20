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

        public Task<IEnumerable<ProgramContactInformation>> GetContactDetailsByProgramId(int progId)
        {
            return _programeContactDetailRepository.GetContactDetailsByProgramId(progId);
        }
    }
}
