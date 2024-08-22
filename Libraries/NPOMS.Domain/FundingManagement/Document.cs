using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.FundingManagement
{
    [Table("Documents", Schema = "fm")]
    public class Document : BaseEntity
    {
        public int FundingCaptureId { get; set; }

        [Column(TypeName = "nvarchar(2000)")]
        public string TPALink { get; set; }

        public bool IsActive { get; set; }

        public int CreatedUserId { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public int? UpdatedUserId { get; set; }

        public DateTime? UpdatedDateTime { get; set; }

        public FundingCapture FundingCapture { get; set; }
    }
}
