using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Mapping;
using NPOMS.Repository.Interfaces.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Implementation.Mapping
{
    public class UserProgramMappingRepository : BaseRepository<UserProgramMapping>, IUserProgramMappingRepository
    {
        #region Constructors

        public UserProgramMappingRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {

        }

        #endregion

        #region Methods

        public async Task<IEnumerable<UserProgramMapping>> GetEntities()
        {
            return await FindAll().AsNoTracking()
               .OrderBy(ow => ow.Id).ToListAsync();
        }

        public IEnumerable<UserProgramMapping> GetUserPrograms()
        {
            return FindAll().AsNoTracking()
               .OrderBy(ow => ow.Id).ToList();
        }

        public async Task<UserProgramMapping> GetByUserIdAndProgramId(int userId, int programId)
        {
            return await FindByCondition(x => x.UserId.Equals(userId) && x.ProgramId.Equals(programId))
                                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<UserProgramMapping>> GetByProgramIds(List<int> programIds)
        {
            return await FindByCondition(x => programIds.Contains(x.ProgramId) && x.IsActive).AsNoTracking().ToListAsync();
        }

        #endregion
    }
}
