using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Core
{
	[Table("EmailTemplates", Schema = "core")]
	public class EmailTemplate : BaseEntity
    {
        public int EmailAccountId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Body { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string Subject { get; set; }

        [Column(TypeName = "nvarchar(2000)")]
        public string Description { get; set; }

        public bool IsActive { get; set; }

        public EmailAccount EmailAccount { get; set; }
    }
}
