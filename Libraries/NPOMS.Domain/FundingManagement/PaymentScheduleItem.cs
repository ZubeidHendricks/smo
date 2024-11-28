using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.FundingManagement
{
    [Table("PaymentScheduleItems", Schema = "fm")]
    public class PaymentScheduleItem : BaseEntity
    {
        public int PaymentScheduleId { get; set; }
        
        public int? CompliantCycleId { get; set; }
        
        public int? CycleNumber { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? PaymentDate { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? PaymentStatus { get; set; }
        
        public double? AllocatedAmount { get; set; }
        
        public double? ApprovedAmount { get; set; }
        
        public double? PaidAmount { get; set; }

        public bool IsCompliant { get; set; }

        public bool IsActive { get; set; }

        public bool IsAddendum { get; set; }

        public int CreatedUserId { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public int? UpdatedUserId { get; set; }

        public DateTime? UpdatedDateTime { get; set; }
    }
}
