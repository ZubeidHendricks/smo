using NPOMS.Domain.Entities;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
	public interface IMunicipalityInformationRepository : IBaseRepository<MunicipalityInformation>
	{
		Task<MunicipalityInformation> GetByFundingApplicationIdAsync(int id);
	}
}
