using NPOMS.Domain.Evaluation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Evaluation
{
	public interface IResponseTypeRepository : IBaseRepository<ResponseType>
	{
		Task<IEnumerable<ResponseType>> GetAllAsync(bool returnInactive);
	}
}
