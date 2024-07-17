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
        public string FinancialYear { get; set; }
        public string Quarter { get; set; }

        public bool IsActive { get; set; }

		public int CreatedUserId { get; set; }

		public DateTime CreatedDateTime { get; set; }

		public int? UpdatedUserId { get; set; }

		public DateTime? UpdatedDateTime { get; set; }

		public bool? ChangesRequired { get; set; }

		public bool? IsNew { get; set; }

		public Objective Objective { get; set; }

		public ActivityType ActivityType { get; set; }

		public List<ActivitySubProgramme> ActivitySubProgrammes { get; set; } = new List<ActivitySubProgramme>();

		public ActivityList ActivityList { get; set; }

		public List<ActivityFacilityList> ActivityFacilityLists { get; set; } = new List<ActivityFacilityList>();

		public List<ActivityRecipient> ActivityRecipients { get; set; } = new List<ActivityRecipient>();

        public ActivityDistrict ActivityDistrict { get; set; } = new ActivityDistrict();
        //public List<ActivitySubDistrict> ActivitySubDistricts { get; set; } = new List<ActivitySubDistrict>();
        //public List<ActivitySubStructure> ActivitySubStructures { get; set; } = new List<ActivitySubStructure>();
    }
}

