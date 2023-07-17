using NPOMS.Domain.Entities;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
	public interface IOrganisationalProfileRepository : IBaseRepository<OrganisationalProfile>
	{
		Task<OrganisationalProfile> GetByFundingApplicationIdAsync(int id);
	}
}
