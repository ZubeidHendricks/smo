using NPOMS.Domain.Entities;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
	public interface IApplicationInformationRepository : IBaseRepository<ApplicationInformation>
	{
		Task<ApplicationInformation> GetByFundingApplicationIdAsync(int id);
	}
}
