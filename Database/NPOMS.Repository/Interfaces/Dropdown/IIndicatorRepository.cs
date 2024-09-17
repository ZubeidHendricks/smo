using NPOMS.Domain.Dropdown;

namespace NPOMS.Repository.Interfaces.Dropdown
{
        public interface IIndicatorRepository : IBaseRepository<Indicators>
        {
            Task<IEnumerable<Indicators>> GetEntities(bool returnInactive);
        }
}
