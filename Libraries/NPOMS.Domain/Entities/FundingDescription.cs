using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Entities
{
	[Table("FundingDescriptions", Schema = "dbo")]
	public class FundingDescription : BaseEntity
	{
		public int FundingApplicationId { get; set; }

		[Column(TypeName = "nvarchar(MAX)")]
		public string ProblemDescription { get; set; }

		[Column(TypeName = "nvarchar(MAX)")]
		public string HowProposedFoundationalStudiesUsed { get; set; }

		[Column(TypeName = "nvarchar(MAX)")]
		public string HowProposedFoundationalStudiesLinked { get; set; }

		[Column(TypeName = "nvarchar(MAX)")]
		public string HowFundingWillBeApplied { get; set; }
	}
}
