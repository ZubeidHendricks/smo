using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Entities
{
	[Table("BackgroundInformation", Schema = "dbo")]
	public class BackgroundInformation : BaseEntity
	{
		public int FundingApplicationId { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string KeyPositionFilled { get; set; }

		[Column(TypeName = "nvarchar(MAX)")]
		public string HRCapacitySupport { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string EnergyResilienceIncluded { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string SSEGAllowed { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string SSEGPolicy { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string CouncilApprovedPolicy { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string NumberOfElectricalInfrastructureProjects { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string NumberOfEnergyInfrastructureProjects { get; set; }

		[Column(TypeName = "nvarchar(MAX)")]
		public string ApprovedRenewableProjectsDescription { get; set; }

		[Column(TypeName = "nvarchar(MAX)")]
		public string StatusOfImplementation { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string HaveCarbonReductionTarget { get; set; }

		[Column(TypeName = "nvarchar(MAX)")]
		public string CarbonReductionTargetExplanation { get; set; }

		[Column(TypeName = "nvarchar(MAX)")]
		public string ElectricalInfrastructureProjectsDescription { get; set; }

		[Column(TypeName = "nvarchar(MAX)")]
		public string EnergyInfrastructureProjectsDescription { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string ApprovedRenewableProjects { get; set; }
	}
}
