using NPOMS.Domain.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Entities
{
	[Table("NpoProfiles", Schema = "dbo")]
	public class NpoProfile : BaseEntity
	{
		public int NpoId { get; set; }

		[Column(TypeName = "char(15)")]
		public string RefNo { get; set; }

		public bool IsActive { get; set; }

		public int CreatedUserId { get; set; }

		public DateTime CreatedDateTime { get; set; }

		public int? UpdatedUserId { get; set; }

		public DateTime? UpdatedDateTime { get; set; }

		public virtual Npo Npo { get; set; }

		public virtual AddressInformation AddressInformation { get; set; }

		public virtual List<NpoProfileFacilityList> NpoProfileFacilityLists { get; set; } = new List<NpoProfileFacilityList>();
	}
}
