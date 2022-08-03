using NPOMS.Domain.Core;
using NPOMS.Domain.Enumerations;
using System.Linq;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Core
{
    public interface IEmailTemplateRepository
    {
        IQueryable<EmailTemplate> GetEntities();

        Task<EmailTemplate> GetById(int id);

        Task<EmailTemplate> GetByType(EmailTemplateTypeEnum emailTemplateTypeEnum);

        Task CreateEntity(EmailTemplate entity);

        Task UpdateEntity(EmailTemplate entity);

        Task DeleteEntity(EmailTemplate entity);
    }
}
