using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Entities;
using NPOMS.Domain.Mapping;
using NPOMS.Repository.Interfaces.Mapping;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace NPOMS.Repository.Implementation.Mapping
{
    public class DepartmentRoleRepository : BaseRepository<DepartmentRoleMapping>, IDepartmentRoleRepository
    {
        public DepartmentRoleRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<List<int>> ReturnRoleIds(int id)
        {
            return await FindByCondition(x => x.DepartmentId.Equals(id))
                         .AsNoTracking()
                         .Select(x => x.RoleId)
                         .ToListAsync();
        }
    }
}
