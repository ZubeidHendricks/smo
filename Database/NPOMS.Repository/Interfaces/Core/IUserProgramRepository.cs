using NPOMS.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Core
{
    public interface IUserProgramRepository : IBaseRepository<UserProgram>
    {
        Task<IEnumerable<UserProgram>> GetEntities(bool returnInactive);
    }
}
