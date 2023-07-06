using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Domain.Entities
{
    [Table("FundAppDocuments", Schema = "fa")]
    public class FundAppDocuments : BaseEntity
    {
        public int ID { get; set; }
        public int? npoProfileId { get; set; }

        public int? FundingApplicationDetailId { get; set; }

        public string Name { get; set; }
        public string DocumentType { get; set; }

        public string Url { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? DateCreated { get; set; }

        public bool? IsActive { get; set; }

        public string FileSize { get; set; }

        [Column(TypeName = "nvarchar(1000)")]
        public string Description { get; set; }

        public bool? IsCompulsory { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(255)")]
        public string Location { get; set; }

        public int? CreatedUserId { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public int? UpdatedUserId { get; set; }

        public DateTime? UpdatedDateTime { get; set; }
    }
}
