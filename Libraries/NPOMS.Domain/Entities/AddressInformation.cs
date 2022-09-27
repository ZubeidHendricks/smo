using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Entities
{
	[Table("AddressInformation", Schema = "dbo")]
	public class AddressInformation : BaseEntity
	{
		public int NpoProfileId { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string PhysicalAddress { get; set; }

		public bool? PostalSameAsPhysical { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string PostalAddress { get; set; }
	}
}
