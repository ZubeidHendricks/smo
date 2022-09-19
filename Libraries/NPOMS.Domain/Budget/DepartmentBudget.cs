using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Budget
{
	[Table("DepartmentBudgets", Schema = "budget")]
	public class DepartmentBudget : BaseEntity
	{
		public int DepartmentId { get; set; }

		public int FinancialYearId { get; set; }

		public decimal Amount { get; set; }

		public bool IsActive { get; set; }

		public int CreatedUserId { get; set; }

		public DateTime CreatedDateTime { get; set; }

		public int? UpdatedUserId { get; set; }

		public DateTime? UpdatedDateTime { get; set; }
	}
}
