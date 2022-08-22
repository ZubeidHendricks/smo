using NPOMS.Domain.Core;
using NPOMS.Domain.Dropdown;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Indicator
{
	[Table("WorkplanTargets", Schema = "indicator")]
	public class WorkplanTarget : BaseEntity
	{
		public int ActivityId { get; set; }

		public int FinancialYearId { get; set; }

		public int FrequencyId { get; set; }

		public int? Annual { get; set; }

		public int? Apr { get; set; }

		public int? May { get; set; }

		public int? Jun { get; set; }

		public int? Jul { get; set; }

		public int? Aug { get; set; }

		public int? Sep { get; set; }

		public int? Oct { get; set; }

		public int? Nov { get; set; }

		public int? Dec { get; set; }

		public int? Jan { get; set; }

		public int? Feb { get; set; }

		public int? Mar { get; set; }

		public int? Quarter1 { get; set; }

		public int? Quarter2 { get; set; }

		public int? Quarter3 { get; set; }

		public int? Quarter4 { get; set; }

		public int CreatedUserId { get; set; }

		public DateTime CreatedDateTime { get; set; }

		public int? UpdatedUserId { get; set; }

		public DateTime? UpdatedDateTime { get; set; }

		public FinancialYear FinancialYear { get; set; } 

		public Frequency Frequency { get; set; }
	}
}
