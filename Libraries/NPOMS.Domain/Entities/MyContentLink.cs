using NPOMS.Domain.Core;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Entities
{
	[Table("MyContentLinks", Schema = "fa")]
	public class MyContentLink : BaseEntity
	{
		public int ApplicationId { get; set; }

		public int DocumentTypeId { get; set; }

		[Required]
		[Column(TypeName = "nvarchar(MAX)")]
		public string Url { get; set; }

		public bool IsActive { get; set; }

		public int CreatedUserId { get; set; }

		public DateTime CreatedDateTime { get; set; }

		public int? UpdatedUserId { get; set; }

		public DateTime? UpdatedDateTime { get; set; }

		public User CreatedUser { get; set; }
	}
}
