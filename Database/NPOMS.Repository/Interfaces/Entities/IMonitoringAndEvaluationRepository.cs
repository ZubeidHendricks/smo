using NPOMS.Domain.Entities;
using System.Threading.Tasks;

namespace NPOMS.Repository.Interfaces.Entities
{
	public interface IMonitoringAndEvaluationRepository : IBaseRepository<MonitoringAndEvaluation>
	{
		Task<MonitoringAndEvaluation> GetByFundingApplicationIdAsync(int id);
	}
}
