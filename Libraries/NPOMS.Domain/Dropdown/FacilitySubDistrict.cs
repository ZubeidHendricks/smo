using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Dropdown
{
	[Table("FacilitySubDistricts", Schema = "dropdown")]
	public class FacilitySubDistrict : BaseEntity
	{
		[Required]
		public int FacilityDistrictId { get; set; }

		[Required]
		[Column(TypeName = "nvarchar(255)")]
		public string Name { get; set; }

		public bool IsActive { get; set; }

		public int CreatedUserId { get; set; }

		public DateTime CreatedDateTime { get; set; }

		public int? UpdatedUserId { get; set; }

		public DateTime? UpdatedDateTime { get; set; }

		public FacilityDistrict FacilityDistrict { get; set; }
	}
}
