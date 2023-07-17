using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Entities
{
	[Table("Budgets", Schema = "dbo")]
	public class Budget : BaseEntity
	{
		public int FundingApplicationId { get; set; }

		[Column(TypeName = "nvarchar(1000)")]
		public string BudgetItem { get; set; }

		[Column(TypeName = "nvarchar(MAX)")]
		public string Description { get; set; }

		public int NPOMSAmount { get; set; }

		public int OwnFundingAmount { get; set; }

		public int OtherFundingAmount { get; set; }

		public int TotalProjectFundingAmount { get; set; }

		public int? OrderOfPriority { get; set; }

		[Column(TypeName = "nvarchar(MAX)")]
		public string RequirementDescription { get; set; }

		[Column(TypeName = "nvarchar(MAX)")]
		public string ProjectBackground { get; set; }

		[Column(TypeName = "nvarchar(MAX)")]
		public string MotivationForDEDATSupport { get; set; }

		public DateTime? CreatedDateTime { get; set; }

		[Column(TypeName = "nvarchar(MAX)")]
		public string InternalExternalFundingUtilised { get; set; }

		public bool IsActive { get; set; }
	}
}
