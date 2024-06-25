using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Mapping
{
    public interface IDepartmentRoleRepository
    {
        Task<List<int>> ReturnRoleIds(int id);
    }
}
