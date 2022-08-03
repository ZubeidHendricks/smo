using NPOMS.Domain.Core;
using System.Linq;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Core
{
	public interface IPermissionRepository : IBaseRepository<Permission>
	{
        Task<Permission> GetBySystemName(string systemName);

        Task<Permission> GetById(int id);

        IQueryable<Permission> GetEntities();

        Task CreateEntity(Permission entity);

        Task UpdateEntity(Permission entity);

        Task DeleteEntity(Permission entity);
    }
}
