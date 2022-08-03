using System.Threading.Tasks;

namespace NPOMS.Services.Interfaces
{
	public interface IEmailService
	{
		Task SendEmailFromQueue();
	}
}
