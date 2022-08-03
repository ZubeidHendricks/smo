using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Core
{
	[Table("EmbeddedReports", Schema = "core")]
	public class EmbeddedReport : BaseEntity
    {
        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(2000)")]
        public string Description { get; set; }

        public string ReportId { get; set; }

        public string WorkspaceId { get; set; }

        [Column(TypeName = "varchar(255)")]
        public string CategoryName { get; set; }

        public bool IsActive { get; set; }

        public int CreatedUserId { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public int? UpdatedUserId { get; set; }

        public DateTime? UpdatedDateTime { get; set; }
    }
}
