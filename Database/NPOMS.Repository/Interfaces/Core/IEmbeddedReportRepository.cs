using NPOMS.Domain.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Core
{
	public interface IEmbeddedReportRepository
	{
		Task<IEnumerable<EmbeddedReport>> GetEntities();

		Task<EmbeddedReport> GetById(int id);
	}
}
