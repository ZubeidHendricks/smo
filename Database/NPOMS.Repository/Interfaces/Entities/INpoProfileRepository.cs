using NPOMS.Domain.Entities;

namespace NPOMS.Repository.Interfaces.Entities
{
    public interface INpoProfileRepository : IBaseRepository<NpoProfile>
	{
		Task<IEnumerable<NpoProfile>> GetEntities();

        Task<IEnumerable<NpoProfile>> GetEntitiesForFundingCapture();

        Task<NpoProfile> GetById(int id);

		Task CreateEntity(NpoProfile model);

		Task UpdateEntity(NpoProfile model, int currentUserId);

		Task<NpoProfile> GetByNpoId(int NpoId);
	}
}
