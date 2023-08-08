using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Entities
{
	[Table("SuccessStories", Schema = "dbo")]
	public class SuccessStory : BaseEntity
	{
		#region Properties

		public int ProjectImpactId { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string NameOfBusiness { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string BusinessAddress { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string BusinessEmailAddress { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string BusinessTelephone { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string BusinessCellphone { get; set; }

		[Column(TypeName = "nvarchar(MAX)")]
		public string DescriptionOfInterventionExecuted { get; set; }

		[Column(TypeName = "nvarchar(MAX)")]
		public string GrowthStatisticsOfBusiness { get; set; }

		[Column(TypeName = "nvarchar(MAX)")]
		public string OtherSuccessMetrices { get; set; }

		#endregion
	}
}
