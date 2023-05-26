using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Dropdown;

using NPOMS.Repository.Interfaces.Dropdown;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Dropdown
{
    public class SubPlaceRepositoy : BaseRepository<SubPlace>, ISubPlaceRepository
    {
        public SubPlaceRepositoy(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<SubPlace> GetById(int id)
        {
            return await FindByCondition(x => x.Id.Equals(id)).AsNoTracking().FirstOrDefaultAsync();
        }

        public async  Task<IEnumerable<SubPlace>> GetEntities(bool returnInactive)
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
