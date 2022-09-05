using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Core
{
	[Table("EmailQueues", Schema = "core")]
	public class EmailQueue : BaseEntity
    {
        [Required]
        public int EmailTemplateId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string FromEmailName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string FromEmailAddress { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Message { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string Subject { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string RecipientName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string RecipientEmail { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public DateTime? SentDateTime { get; set; }

        public EmailTemplate EmailTemplate { get; set; }
    }
}
