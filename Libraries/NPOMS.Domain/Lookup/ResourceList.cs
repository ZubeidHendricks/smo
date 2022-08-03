using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Lookup
{
	[Table("ResourceList", Schema = "lookup")]
	public class ResourceList : BaseEntity
	{
		[Required]
		[Column(TypeName = "nvarchar(50)")]
		public string Name { get; set; }

		[Column(TypeName = "nvarchar(1000)")]
		public string Description { get; set; }

		[Required]
		public int ResourceTypeId { get; set; }

		public bool IsActive { get; set; }

		public int CreatedUserId { get; set; }

		public DateTime CreatedDateTime { get; set; }

		public int? UpdatedUserId { get; set; }

		public DateTime? UpdatedDateTime { get; set; }
	}
}
