using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.FundingManagement
{
    [Table("PaymentSchedules", Schema = "fm")]
    public class PaymentSchedule : BaseEntity
    {
        public int FundingCaptureId { get; set; }

        public double? AllocatedAmountTotal { get; set; }

        public double? ApprovedAmountTotal { get; set; }

        public double? PaidAmountTotal { get; set; }

        public double? AllocatedAmountBalance { get; set; }

        public double? ApprovedAmountBalance { get; set; }

        public double? PaidAmountBalance { get; set; }

        public bool IsActive { get; set; }

        public int CreatedUserId { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public int? UpdatedUserId { get; set; }

        public DateTime? UpdatedDateTime { get; set; }

        public List<PaymentScheduleItem> PaymentScheduleItems { get; set; } = new List<PaymentScheduleItem>();
    }
}
