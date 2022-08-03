using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Core
{
	[Table("EmailAccounts", Schema = "core")]
	public class EmailAccount : BaseEntity
    {
        [Column(TypeName = "nvarchar(2000)")]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string FromDisplayName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string FromEmail { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string Host { get; set; }

        public int Port { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string UserName { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string Password { get; set; }

        public bool EnableSSL { get; set; }

        public int CreatedUserId { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public int? UpdatedUserId { get; set; }

        public DateTime? UpdatedDateTime { get; set; }
    }
}
