using NPOMS.Domain.Dropdown;

namespace NPOMS.Repository.Interfaces.Dropdown
{
    public interface ICalculationTypeRepository : IBaseRepository<CalculationType>
    {
        Task<IEnumerable<CalculationType>> GetEntities(bool returnInactive);

        Task<CalculationType> GetById(int id);
    }
}
