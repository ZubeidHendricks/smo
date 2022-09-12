using NPOMS.Domain.Indicator;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Indicator
{
	public interface IWorkplanCommentRepository : IBaseRepository<WorkplanComment>
	{
		Task<IEnumerable<WorkplanComment>> GetByWorkplanActualId(int workplanActualId);

		Task CreateEntity(WorkplanComment model);
	}
}
