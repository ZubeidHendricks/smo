using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Core
{
	[Table("DocumentStores", Schema = "core")]
	public class DocumentStore : BaseEntity
	{
		[Required]
		[Column(TypeName = "char(15)")]
		public string RefNo { get; set; }

		public int? DocumentTypeId { get; set; }

		[Required]
		public int EntityTypeId { get; set; }

		[Required]
		public int EntityId { get; set; }

		[Required]
		[Column(TypeName = "nvarchar(50)")]
		public string Entity { get; set; }

		[Required]
		[Column(TypeName = "nvarchar(255)")]
		public string Name { get; set; }

		[Required]
		[Column(TypeName = "nvarchar(80)")]
		public string ResourceId { get; set; }

		[Required]
		[Column(TypeName = "nvarchar(50)")]
		public string FileSize { get; set; }

		public bool IsActive { get; set; }

		public int CreatedUserId { get; set; }

		public DateTime CreatedDateTime { get; set; }

		public int? UpdatedUserId { get; set; }

		public DateTime? UpdatedDateTime { get; set; }

		public virtual DocumentType DocumentType { get; set; }
	}
}
