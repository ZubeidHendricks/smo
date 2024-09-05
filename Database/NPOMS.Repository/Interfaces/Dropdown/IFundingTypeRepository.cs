using NPOMS.Domain.Dropdown;

namespace NPOMS.Repository.Interfaces.Dropdown
{
    public interface IFundingTypeRepository : IBaseRepository<FundingType>
    {
        Task<IEnumerable<FundingType>> GetEntities(bool returnInactive);

        Task<FundingType> GetById(int id);
    }
}
