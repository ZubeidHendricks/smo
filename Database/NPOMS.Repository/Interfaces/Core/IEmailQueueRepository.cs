using NPOMS.Domain.Core;
using System.Linq;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Core
{
    public interface IEmailQueueRepository
    {
        IQueryable<EmailQueue> GetEntities();

        Task<EmailQueue> GetById(int id);

        Task CreateEntity(EmailQueue entity);

        Task UpdateEntity(EmailQueue entity, int currentUserId);

        Task DeleteEntity(EmailQueue entity);
    }
}
