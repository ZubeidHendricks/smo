using NPOMS.Domain.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Mapping
{
    public interface IUserProgramMappingRepository : IBaseRepository<UserProgramMapping>
    {

        Task<IEnumerable<UserProgramMapping>> GetEntities();

        IEnumerable<UserProgramMapping> GetUserPrograms();

        Task<UserProgramMapping> GetByUserIdAndProgramId(int userId, int userProgramId);

        /// <summary>
        /// Get UserRoles by RoleIds
        /// </summary>
        /// <param name="roleIds"></param>
        /// <returns></returns>
        Task<IEnumerable<UserProgramMapping>> GetByProgramIds(List<int> userProgramIds);
    }
}
