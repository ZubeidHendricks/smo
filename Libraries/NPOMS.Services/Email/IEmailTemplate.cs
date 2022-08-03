using System.Threading.Tasks;

namespace NPOMS.Services.Email
{
	public interface IEmailTemplate
    {
        Task SubmitToQueue();
    }
}
