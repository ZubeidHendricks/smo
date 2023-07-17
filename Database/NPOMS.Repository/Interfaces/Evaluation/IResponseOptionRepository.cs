using NPOMS.Domain.Evaluation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Evaluation
{
	public interface IResponseOptionRepository : IBaseRepository<ResponseOption>
	{
		Task<IEnumerable<ResponseOption>> GetAllAsync(bool returnInactive);
	}
}
