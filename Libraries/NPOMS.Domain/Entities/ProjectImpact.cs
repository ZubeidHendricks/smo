using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Entities
{
	[Table("ProjectImpacts", Schema = "dbo")]
	public class ProjectImpact : BaseEntity
	{
		#region Properties

		public int FundingApplicationId { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string NumberOfJobCreated { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string NumberOfBusinessesSupported { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string NumberOfBusinessesAccommodatedExistingInfrastructure { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string NumberOfBusinessesAccommodatedNewInfrastructure { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string NumberOfJobsCreatedSinceInception { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string NumberOfJobsCreatedForNewProject { get; set; }

		[Column(TypeName = "nvarchar(MAX)")]
		public string BeneficiariesBenefits { get; set; }

		public virtual List<SuccessStory> SuccessStories { get; set; } = new List<SuccessStory>();

		#endregion
	}
}
