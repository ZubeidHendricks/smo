using NPOMS.Domain.Dropdown;
using NPOMS.Domain.Mapping;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Entities
{
	[Table("ImplementationTimelines", Schema = "dbo")]
	public class ImplementationTimeline : BaseEntity
	{
		#region Properties

		public int FundingApplicationId { get; set; }

		public int? Year { get; set; }

		[Column(TypeName = "nvarchar(MAX)")]
		public string Activity { get; set; }

		public int? TaskTypeId { get; set; }

		public bool AprilSelected { get; set; }

		public bool MaySelected { get; set; }

		public bool JuneSelected { get; set; }

		public bool JulySelected { get; set; }

		public bool AugustSelected { get; set; }

		public bool SeptemberSelected { get; set; }

		public bool OctoberSelected { get; set; }

		public bool NovemberSelected { get; set; }

		public bool DecemberSelected { get; set; }

		public bool JanuarySelected { get; set; }

		public bool FebruarySelected { get; set; }

		public bool MarchSelected { get; set; }

		public DateTime? CreatedDateTime { get; set; }

		public bool IsActive { get; set; }

		public virtual FoundationalEnergyStudyTimeline FoundationalEnergyStudyTimelineMapping { get; set; }

		public virtual TaskType TaskType { get; set; }

		#endregion
	}
}
