using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Entities
{
	[Table("CompliantCycles", Schema = "dbo")]
	public class CompliantCycle : BaseEntity
	{
		public int CompliantCycleRuleId { get; set; }

		public int DepartmentId { get; set; }

		public int FinancialYearId { get; set; }

		public DateTime StartDate { get; set; }

		public DateTime EndDate { get; set; }

		public bool HasSignedTPA { get; set; }

		public bool HasProgressReport { get; set; }

		public bool HasFinancialStatement { get; set; }

		public bool IsActive { get; set; }

		public int CreatedUserId { get; set; }

		public DateTime CreatedDateTime { get; set; }

		public int? UpdatedUserId { get; set; }

		public DateTime? UpdatedDateTime { get; set; }
	}
}
