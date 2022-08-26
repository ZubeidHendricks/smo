using NPOMS.Domain.Dropdown;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Indicator
{
	[Table("WorkplanActuals", Schema = "indicator")]
	public class WorkplanActual : BaseEntity
	{
		public int ActivityId { get; set; }

		public int FinancialYearId { get; set; }

		public int FrequencyPeriodId { get; set; }

		public int StatusId { get; set; }

		public int? Actual { get; set; }

		public string Statement { get; set; }

		public string DeviationReason { get; set; }

		public string Action { get; set; }

		public int CreatedUserId { get; set; }

		public DateTime CreatedDateTime { get; set; }

		public int? UpdatedUserId { get; set; }

		public DateTime? UpdatedDateTime { get; set; }

		public int WorkplanTargetId { get; set; }

		public FrequencyPeriod FrequencyPeriod { get; set; }
	}
}
