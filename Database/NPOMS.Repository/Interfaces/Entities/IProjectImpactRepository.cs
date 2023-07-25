using NPOMS.Domain.Entities;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
	public interface IProjectImpactRepository : IBaseRepository<ProjectImpact>
	{
		Task<ProjectImpact> GetByFundingApplicationIdAsync(int id);
	}
}
