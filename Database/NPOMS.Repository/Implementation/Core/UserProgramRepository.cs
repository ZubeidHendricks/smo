using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Core;
using NPOMS.Domain.Mapping;
using NPOMS.Repository.Interfaces.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Core
{
    public class UserProgramRepository : BaseRepository<UserProgram>, IUserProgramRepository
    {

        #region Constructors

        public UserProgramRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

        #endregion

        #region Methods

        public async Task<IEnumerable<UserProgram>> GetEntities(bool returnInactive)
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

        #endregion

    }
}
