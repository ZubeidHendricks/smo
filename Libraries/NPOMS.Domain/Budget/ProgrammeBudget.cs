using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Budget
{
	[Table("ProgrammeBudgets", Schema = "budget")]
	public class ProgrammeBudget : BaseEntity
	{
		public int DepartmentId { get; set; }

		public int FinancialYearId { get; set; }

		public int DirectorateBudgetId { get; set; }

		public int ProgrammeId { get; set; }

		public decimal Amount { get; set; }

		[Column(TypeName = "nvarchar(2000)")]
		public string Description { get; set; }

		public bool IsActive { get; set; }

		public int CreatedUserId { get; set; }

		public DateTime CreatedDateTime { get; set; }

		public int? UpdatedUserId { get; set; }

		public DateTime? UpdatedDateTime { get; set; }
	}
}
