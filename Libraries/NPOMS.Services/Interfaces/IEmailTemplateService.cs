using NPOMS.Domain.Enumerations;
using NPOMS.Domain.ResourceParameters;
using NPOMS.Services.Helpers.Paging;
using NPOMS.Services.Models;
using System.Threading.Tasks;

namespace NPOMS.Services.Interfaces
{
	public interface IEmailTemplateService
    {
        Task<PagedList<EmailTemplateViewModel>> GetAll(EmailTemplateResourceParameters emailTemplateResourceParameters);

        Task<EmailTemplateViewModel> GetById(int emailAccountId);

        Task<EmailTemplateViewModel> GetByType(EmailTemplateTypeEnum emailTemplateTypeEnum);

        Task Create(EmailTemplateViewModel viewModel);

        Task Update(EmailTemplateViewModel viewModel, string userIdentifier);

        Task Delete(EmailTemplateViewModel viewModel);
    }
}
