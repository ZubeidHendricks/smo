using NPOMS.Domain.Mapping;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Entities
{
	[Table("ProjectDescriptions", Schema = "dbo")]
	public class ProjectDescription : BaseEntity
	{
		#region Properties

		public int FundingApplicationId { get; set; }

		[Column(TypeName = "nvarchar(MAX)")]
		public string DescribeTheProject { get; set; }

		[Column(TypeName = "nvarchar(MAX)")]
		public string HowSMMEBoosterFundingImproveProject { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string NumberOfBusinessesSupportedProject { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string NumberOfJobsCreated { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string NumberOfJobsSustained { get; set; }

		[Column(TypeName = "nvarchar(MAX)")]
		public string PleaseExplain { get; set; }

		[Column(TypeName = "nvarchar(MAX)")]
		public string JobsCreatedSustainedExplanation { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string NumberOfYearsExisted { get; set; }

		[Column(TypeName = "nvarchar(MAX)")]
		public string SupportGivenToBusinesses { get; set; }

		[Column(TypeName = "nvarchar(MAX)")]
		public string BusinessBenefitThroughProject { get; set; }

		[Column(TypeName = "nvarchar(MAX)")]
		public string InfrastructureProjectType { get; set; }

		[Column(TypeName = "nvarchar(MAX)")]
		public string StatusOfImplementationToDate { get; set; }

		[Column(TypeName = "nvarchar(MAX)")]
		public string HowFundingImproveProject { get; set; }

		[Column(TypeName = "nvarchar(MAX)")]
		public string SupportGivenToBusinessesFromInfrastructure { get; set; }

		[Column(TypeName = "nvarchar(MAX)")]
		public string NumberOfBusinessesSupportedIntervention { get; set; }

		[Column(TypeName = "nvarchar(MAX)")]
		public string BusinessesSupported { get; set; }

		[Column(TypeName = "nvarchar(MAX)")]
		public string SelectionCriteriaUsed { get; set; }

		public virtual List<ProjectDescriptionSectorGrouping> SectorGroupingMappings { get; set; } = new List<ProjectDescriptionSectorGrouping>();

		public virtual List<BusinessesSupportedList> BusinessesSupportedList { get; set; } = new List<BusinessesSupportedList>();

		#endregion
	}
}
