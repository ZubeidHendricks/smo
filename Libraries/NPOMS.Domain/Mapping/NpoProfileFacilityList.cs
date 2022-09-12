using NPOMS.Domain.Entities;
using NPOMS.Domain.Lookup;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Mapping
{
	[Table("NpoProfiles_FacilityLists", Schema = "mapping")]
	public class NpoProfileFacilityList : BaseEntity
	{
		public int NpoProfileId { get; set; }

		public int FacilityListId { get; set; }

		public bool IsActive { get; set; }

		//public NpoProfile NpoProfile { get; set; }

		public FacilityList FacilityList { get; set; }
	}
}
