using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Budget
{
	[Table("DirectorateBudgets", Schema = "budget")]
	public class DirectorateBudget : BaseEntity
	{
		public int DepartmentId { get; set; }

		public int FinancialYearId { get; set; }

		public int DepartmentBudgetId { get; set; }

		public int DirectorateId { get; set; }

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
