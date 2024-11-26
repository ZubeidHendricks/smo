using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Entities;
using NPOMS.Repository.Interfaces.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Entities
{
    public class ControlRepository : BaseRepository<Control>, IControlRepository
    {
        #region Constructors

        public ControlRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

        #endregion

        #region Methods

        public async Task<IEnumerable<Control>> GetEntities(bool returnInactive)
        {
            if (returnInactive)
            {
                return await FindAll()
                                .AsNoTracking()
                                .OrderBy(x => x.ControlID)
                                .ToListAsync();
            }
            else
            {
                return await FindAll()
                                //.Where(x => x.IsActive)
                                .AsNoTracking()
                                .OrderBy(x => x.ControlID)
                                .ToListAsync();
            }
        }

        public async Task<Control> GetById(int id)
        {
            return await FindByCondition(x => x.ControlID.Equals(id)).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<Control> GetByType(string type)
        {
            return await FindByCondition(x => x.Type.Equals(type)).AsNoTracking().FirstOrDefaultAsync();
        }

        #endregion
    }
}


