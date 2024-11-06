using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Dropdown;
using NPOMS.Repository.Interfaces.Dropdown;

namespace NPOMS.Repository.Implementation.Dropdown
{
    public class IndicatorRepository : BaseRepository<Indicators>, IIndicatorRepository
    {
        public IndicatorRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Indicators>> GetEntities(bool returnInactive)
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

        public async Task loadindicatorsAsync(List<Indicators> data)
        {
             await InsertMultiItemsAsync(data);
        }
    }
}
