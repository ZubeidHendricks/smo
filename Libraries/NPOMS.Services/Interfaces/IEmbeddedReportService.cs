using NPOMS.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Services.Interfaces
{
	public interface IEmbeddedReportService
	{
		Task<List<EmbeddedReportViewModel>> GetEmbeddedReports();

		Task<EmbeddedReportViewModel> GetEmbeddedReportById(int id);
	}
}
