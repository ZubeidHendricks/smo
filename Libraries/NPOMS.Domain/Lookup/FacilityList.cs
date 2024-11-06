using NPOMS.Domain.Dropdown;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Lookup
{
	[Table("FacilityList", Schema = "lookup")]
	public class FacilityList : BaseEntity
	{
		public int FacilityTypeId { get; set; }

        public int FacilitySubDistrictId { get; set; }

		[Required]
		[Column(TypeName = "nvarchar(50)")]
		public string Name { get; set; }

		public int FacilityClassId { get; set; }

		[Column(TypeName = "nvarchar(50)")]
		public string Latitude { get; set; }

		[Column(TypeName = "nvarchar(50)")]
		public string Longitude { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string Address { get; set; }

		public bool IsNew { get; set; }

		public bool IsActive { get; set; }

		public int CreatedUserId { get; set; }

		public DateTime CreatedDateTime { get; set; }

		public int? UpdatedUserId { get; set; }

		public DateTime? UpdatedDateTime { get; set; }

		public FacilityType FacilityType { get; set; }

		public FacilitySubDistrict FacilitySubDistrict { get; set; }

		public FacilityClass FacilityClass { get; set; }
	}
}
