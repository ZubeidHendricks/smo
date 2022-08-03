using NPOMS.Domain.Core;
using System.Linq;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Core
{
	public interface IEmailAccountRepository
    {
        IQueryable<EmailAccount> GetEntities();

        Task<EmailAccount> GetById(int id);

        Task CreateEntity(EmailAccount entity);

        Task UpdateEntity(EmailAccount entity);

        Task DeleteEntity(EmailAccount entity);
    }
}
