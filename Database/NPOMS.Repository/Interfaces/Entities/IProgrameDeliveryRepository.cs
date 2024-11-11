using NPOMS.Domain.Dropdown;
using NPOMS.Domain.Entities;

namespace NPOMS.Repository.Interfaces.Entities
{
    public interface IProgrameDeliveryRepository : IBaseRepository<ProgrammeServiceDelivery>
    {
        Task<IEnumerable<ProgrammeServiceDelivery>> GetDeliveryDetailsByProgramId(int programmeId, int npoProfileId);
        Task<IEnumerable<ServiceDeliveryArea>> GetServiveDeliveryMasterByProgramId(int programmeId, int npoId);
       
        Task<IEnumerable<ProgrammeServiceDelivery>> GetProgrammeDeliveryArea();
        Task<IEnumerable<ProgrammeServiceDelivery>> GetDeliveryByProgramId(int programmeId, int npoProfileId);
        Task<IEnumerable<ProgrammeServiceDelivery>> GetDeliveryDetails(int npoProfileId);
        Task<IEnumerable<ProgrammeServiceDelivery>> GetDeliveryDetailsByIds(int programmeId, int npoProfileId, int subProgramId, int subProgramTypeId);


    }
}
