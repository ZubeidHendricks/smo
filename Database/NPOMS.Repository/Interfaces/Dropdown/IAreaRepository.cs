using NPOMS.Domain.Dropdown;

namespace NPOMS.Repository.Interfaces.Dropdown
{
    public interface IAreaRepository : IBaseRepository<Area>
    {
        Task<IEnumerable<Area>> GetEntities(bool returnInactive);
    }
}
