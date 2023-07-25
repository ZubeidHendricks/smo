using NPOMS.Domain.Mapping;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Entities
{
	[Table("Cashflows", Schema = "dbo")]
	public class Cashflow : BaseEntity
	{
		#region Properties

		public int FundingApplicationId { get; set; }

		[Column(TypeName = "nvarchar(MAX)")]
		public string ProjectItem { get; set; }

		public int AprilAmount { get; set; }

		public int MayAmount { get; set; }

		public int JuneAmount { get; set; }

		public int JulyAmount { get; set; }

		public int AugustAmount { get; set; }

		public int SeptemberAmount { get; set; }

		public int OctoberAmount { get; set; }

		public int NovemberAmount { get; set; }

		public int DecemberAmount { get; set; }

		public int JanuaryAmount { get; set; }

		public int FebruaryAmount { get; set; }

		public int MarchAmount { get; set; }

		public int TotalAmount { get; set; }

		public DateTime? CreatedDateTime { get; set; }

		public bool IsActive { get; set; }

		public virtual FoundationalEnergyStudyCashflow FoundationalEnergyStudyCashflowMapping { get; set; }

		#endregion
	}
}
