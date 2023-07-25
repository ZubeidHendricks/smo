using NPOMS.Domain.Entities;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
	public interface IFundingDescriptionRepository : IBaseRepository<FundingDescription>
	{
		Task<FundingDescription> GetByFundingApplicationIdAsync(int id);
	}
}
