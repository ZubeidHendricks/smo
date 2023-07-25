using NPOMS.Domain.Entities;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
	public interface IProjectManagerContactInformationRepository : IBaseRepository<ProjectManagerContactInformation>
	{
		Task<ProjectManagerContactInformation> GetByFundingApplicationIdAsync(int id);
	}
}
