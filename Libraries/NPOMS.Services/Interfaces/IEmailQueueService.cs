using NPOMS.Domain.Core;
using NPOMS.Domain.ResourceParameters;
using NPOMS.Services.Helpers.Paging;
using NPOMS.Services.Models;
using System.Linq;
using System.Threading.Tasks;

namespace NPOMS.Services.Interfaces
{
	public interface IEmailQueueService
    {
        IQueryable<EmailQueue> Get(EmailQueueResourceParameters emailQueueResourceParameters);

        Task<PagedList<EmailQueueViewModel>> GetAll(EmailQueueResourceParameters emailQueueResourceParameters);

        Task<EmailQueueViewModel> GetById(int emailQueueId);

        Task Create(EmailQueue entity);

        Task Update(EmailQueueViewModel viewModel);
    }
}
