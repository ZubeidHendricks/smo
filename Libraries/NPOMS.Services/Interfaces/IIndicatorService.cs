using NPOMS.Domain.Indicator;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Services.Interfaces
{
	public interface IIndicatorService
	{
		Task<IEnumerable<WorkplanTarget>> GetTargetsByActivityId(int activityId);

		/// <summary>
		/// Get Workplan Targets by Activity, Financial Year and Frequency Id
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		Task<WorkplanTarget> GetTargetByIds(WorkplanTarget model);

		Task CreateTarget(WorkplanTarget model, string userIdentifier);

		Task UpdateTarget(WorkplanTarget model, string userIdentifier);

		Task<IEnumerable<WorkplanActual>> GetActualsByActivityId(int activityId);

		/// <summary>
		/// Get Workplan Actuals by Activity, Financial Year and Frequency Period Id
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		Task<WorkplanActual> GetActualsByIds(WorkplanActual model);

		Task CreateActual(WorkplanActual model, string userIdentifier);

		Task UpdateActual(WorkplanActual model, string userIdentifier);

		Task<IEnumerable<WorkplanComment>> GetWorkplanComments(int workplanActualId);

		Task CreateWorkplanComment(WorkplanComment model, string userIdentifier);
	}
}
