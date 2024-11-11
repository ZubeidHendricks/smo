using System.Collections.Generic;

namespace NPOMS.Services.Models.FundingManagement
{
    public class PaymentScheduleViewModel
    {
        public PaymentScheduleViewModel()
        {
            PaymentScheduleItemViewModels = PaymentScheduleItemViewModels ?? new List<PaymentScheduleItemViewModel>();
        }

        public int Id { get; set; }
        public int FundingCaptureId { get; set; }
        public double? AllocatedAmountTotal { get; set; }
        public double? ApprovedAmountTotal { get; set; }
        public double? PaidAmountTotal { get; set; }
        public double? AllocatedAmountBalance { get; set; }
        public double? ApprovedAmountBalance { get; set; }
        public double? PaidAmountBalance { get; set; }

        public bool IsCompliant { get; set; }
        public bool IsActive { get; set; }

        public List<PaymentScheduleItemViewModel> PaymentScheduleItemViewModels { get; set; }
    }
}
