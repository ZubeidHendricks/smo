using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Dropdown;
using NPOMS.Repository.Interfaces.Dropdown;

namespace NPOMS.Repository.Implementation.Dropdown
{
    public class AreaRepository : BaseRepository<Area>, IAreaRepository
    {
        public AreaRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Area>> GetEntities(bool returnInactive)
        {
            if (returnInactive)
            {
                return await FindAll()
                                .AsNoTracking()
                                .OrderBy(x => x.Name)
                                .ToListAsync();
            }
            else
            {
                return await FindAll()
                                .Where(x => x.IsActive)
                                .AsNoTracking()
                                .OrderBy(x => x.Name)
                                .ToListAsync();
            }
        }
    }
}
