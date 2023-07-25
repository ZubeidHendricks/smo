using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Entities
{
	[Table("ImplementationRisks", Schema = "dbo")]
	public class ImplementationRisk : BaseEntity
	{
		public int FundingApplicationId { get; set; }

		[Required]
		[Column(TypeName = "nvarchar(255)")]
		public string ProjectRisk { get; set; }

		[Required]
		[Column(TypeName = "nvarchar(255)")]
		public string ProbabilityOfOccurrence { get; set; }

		[Required]
		[Column(TypeName = "nvarchar(255)")]
		public string ImpactOfRisk { get; set; }

		[Required]
		[Column(TypeName = "nvarchar(MAX)")]
		public string MitigationPlan { get; set; }

		[Required]
		[Column(TypeName = "nvarchar(255)")]
		public string PersonResponsible { get; set; }

		public bool IsActive { get; set; }
	}
}
