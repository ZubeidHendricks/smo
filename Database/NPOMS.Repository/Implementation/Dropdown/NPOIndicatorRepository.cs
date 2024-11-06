using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Dropdown;
using NPOMS.Repository.Interfaces.Dropdown;

namespace NPOMS.Repository.Implementation.Dropdown
{
    public class NPOIndicatorRepository : BaseRepository<NPOIndicators>, INPOIndicatorRepository
    {
        public NPOIndicatorRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<NPOIndicators>> GetEntities(bool returnInactive)
        {
            if (returnInactive)
            {
                return await FindAll()
                                .AsNoTracking()
                                .ToListAsync();
            }
            else
            {
                return await FindAll()
                                .Where(x => x.IsActive)
                                .AsNoTracking()
                                .ToListAsync();
            }
        }

        public async Task loadindicatorsAsync(List<NPOIndicators> data)
        {
            await InsertMultiItemsAsync(data);
        }
    }
}
