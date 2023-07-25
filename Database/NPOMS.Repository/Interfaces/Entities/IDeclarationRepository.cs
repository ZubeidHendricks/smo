using NPOMS.Domain.Entities;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
	public interface IDeclarationRepository : IBaseRepository<Declaration>
	{
		Task<Declaration> GetByFundingApplicationIdAsync(int id);
	}
}
