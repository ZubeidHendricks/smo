using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Entities
{
	[Table("AuditLogs", Schema = "dbo")]
	public class AuditLog : BaseEntity
	{
		[Column(TypeName = "nvarchar(255)")]
		public string TableName { get; set; }

		public int TablePrimaryKey { get; set; }

		[Column(TypeName = "nvarchar(255)")]
		public string AuditType { get; set; }

		[Column(TypeName = "nvarchar(MAX)")]
		public string AffectedColumns { get; set; }

		[Column(TypeName = "nvarchar(MAX)")]
		public string OldValue { get; set; }

		[Column(TypeName = "nvarchar(MAX)")]
		public string NewValue { get; set; }

		public int CreatedUserId { get; set; }

		public DateTime CreatedDateTime { get; set; }
	}
}
