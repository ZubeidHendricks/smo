using NPOMS.Domain.Dropdown;
using NPOMS.Domain.Entities;
using NPOMS.Domain.Indicator;
using NPOMS.Services.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPOMS.Services.Interfaces
{
	public interface IIndicatorService
	{
		Task<IEnumerable<WorkplanTarget>> GetTargetsByActivityId(int activityId);

        Task<IEnumerable<WorkplanTarget>> GetTargetsByActivityIds(List<int> activityIds);
        Task<IEnumerable<WorkplanActual>> GetActualsByActivityIds(List<int> activityIds);
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

		Task CreateWorkplanActualAudit(WorkplanActualAudit model, string userIdentifier);

		Task<IEnumerable<WorkplanActualAudit>> GetWorkplanActualAudits(int workplanActualId);

		Task<IEnumerable<WorkplanActual>> GetWorkplanActualsByIds(List<int> activityIds, int financialYearId, int frequencyPeriodId);

        Task<IEnumerable<IndicatorReport>> GetIndicatorReports();

        Task<IndicatorReport> GetIndicatorReportById(int id);

        Task<IEnumerable<IndicatorReport>> GetIndicatorReportByPeriodId(int applicationPeriodId);

        Task<IEnumerable<IndicatorReport>> GetIndicatorReportByNpoId(int npoId);

        Task<IndicatorReport> GetByIds(int financialYearId, int applicationTypeId);

        Task CreateIndicatorReportEntity(IndicatorReport model, string userIdentifier);

        Task UpdateIndicatorReportEntity(IndicatorReport model, string currentUserId);
        Task UpdateIndicatorReportEntityQC(IndicatorReport model, int currentUserId);
        Task loadindicatorsAsync(List<Indicators> data);

        Task loadNPOindicatorsAsync(List<NPOIndicators> data);
        Task UpdateIndicatorReportStatus(BaseCompleteViewModel model, string userIdentifier);
    }
}
