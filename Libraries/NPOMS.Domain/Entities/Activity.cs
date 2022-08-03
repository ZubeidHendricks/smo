using NPOMS.Domain.Dropdown;
using NPOMS.Domain.Lookup;
using NPOMS.Domain.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NPOMS.Domain.Entities
{
	[Table("Activities", Schema = "dbo")]
	public class Activity : BaseEntity
	{
		public int ApplicationId { get; set; }

		public int ObjectiveId { get; set; }

		public int ActivityListId { get; set; }

		public int ActivityTypeId { get; set; }

		[Column(TypeName = "nvarchar(50)")]
		public string TimelineStartDate { get; set; }

		[Column(TypeName = "nvarchar(50)")]
		public string TimelineEndDate { get; set; }

		public int Target { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string SuccessIndicator { get; set; }

		public bool IsActive { get; set; }

		public int CreatedUserId { get; set; }

		public DateTime CreatedDateTime { get; set; }

		public int? UpdatedUserId { get; set; }

		public DateTime? UpdatedDateTime { get; set; }

		public bool? ChangesRequired { get; set; }

		public virtual Objective Objective { get; set; }

		public virtual ActivityType ActivityType { get; set; }

		public virtual List<ActivitySubProgramme> ActivitySubProgrammes { get; set; } = new List<ActivitySubProgramme>();

		public virtual ActivityList ActivityList { get; set; }

		public virtual List<ActivityFacilityList> ActivityFacilityLists { get; set; } = new List<ActivityFacilityList>();
	}
}
