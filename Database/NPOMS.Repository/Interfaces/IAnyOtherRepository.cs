using NPOMS.Domain.Entities;

namespace NPOMS.Repository.Interfaces
{
    public interface IAnyOtherRepository : IBaseRepository<AnyOtherInformationReport>
    {
        Task<IEnumerable<AnyOtherInformationReport>> GetEntities();

        Task<AnyOtherInformationReport> GetById(int id);

        Task<IEnumerable<AnyOtherInformationReport>> GetByPeriodId(int applicationPeriodId);

        Task<IEnumerable<AnyOtherInformationReport>> GetByNpoId(int npoId);

        Task<AnyOtherInformationReport> GetByIds(int financialYearId, int applicationTypeId);

        Task CreateEntity(AnyOtherInformationReport model);

        Task UpdateEntity(AnyOtherInformationReport model, int currentUserId);
        Task UpdateEntityQC(AnyOtherInformationReport model, int currentUserId);
        Task<IEnumerable<AnyOtherInformationReport>> UpdateAnyOtherStatus(int applicationId, int finYear, int quarterId, int id);
    }
}
