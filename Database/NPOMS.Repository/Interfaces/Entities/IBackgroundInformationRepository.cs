using NPOMS.Domain.Entities;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
	public interface IBackgroundInformationRepository : IBaseRepository<BackgroundInformation>
	{
		Task<BackgroundInformation> GetByFundingApplicationIdAsync(int id);
	}
}
