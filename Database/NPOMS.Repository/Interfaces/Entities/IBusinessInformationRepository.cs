using NPOMS.Domain.Entities;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
	public interface IBusinessInformationRepository : IBaseRepository<BusinessInformation>
	{
		Task<BusinessInformation> GetByFundingApplicationIdAsync(int id);
	}
}
