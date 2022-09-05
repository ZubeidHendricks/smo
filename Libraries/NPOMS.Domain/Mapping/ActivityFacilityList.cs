using NPOMS.Domain.Entities;
using NPOMS.Domain.Lookup;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Mapping
{
	[Table("Activities_FacilityLists", Schema = "mapping")]
	public class ActivityFacilityList : BaseEntity
	{
		public int ActivityId { get; set; }

		public int FacilityListId { get; set; }

		public bool IsActive { get; set; }

		//public Activity Activity { get; set; }

		public FacilityList FacilityList { get; set; }
	}
}
