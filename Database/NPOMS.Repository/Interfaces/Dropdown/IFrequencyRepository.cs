using NPOMS.Domain.Dropdown;

namespace NPOMS.Repository.Interfaces.Dropdown
{
    public interface IFrequencyRepository : IBaseRepository<Frequency>
	{
		Task<IEnumerable<Frequency>> GetEntities(bool returnInactive);

		Task<Frequency> GetById(int id);
    }
}
