using NPOMS.Domain.Entities;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
	public interface IProjectDescriptionRepository : IBaseRepository<ProjectDescription>
	{
		Task<ProjectDescription> GetByFundingApplicationIdAsync(int id);
	}
}
