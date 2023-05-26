using NPOMS.Domain.Entities;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
    public interface IApplicationDetailsRepository : IBaseRepository<ApplicationDetail>
    {
        Task<ApplicationDetail> GetById(int id);
    }
}
