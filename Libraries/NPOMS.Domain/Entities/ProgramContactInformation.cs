using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Entities
{
    [Table("ProgramContactInformation", Schema = "dbo")]
    public class ProgramContactInformation : BaseEntity
    {
        public int ProgrammeId { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string EmailAddress { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Telephone { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Cellphone { get; set; }

        [Column(TypeName = "nvarchar(1000)")]
        public string Comments { get; set; }

        public bool? IsPrimaryContact { get; set; }
        public bool? IsDisabled { get; set; }
        public string AddressInformation { get; set; }
        public bool IsActive { get; set; }
        public int CreatedUserId { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int? UpdatedUserId { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
    }
}
