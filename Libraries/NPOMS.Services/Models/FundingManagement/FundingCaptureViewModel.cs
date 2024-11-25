using Microsoft.Graph;
using System.Collections.Generic;

namespace NPOMS.Services.Models.FundingManagement
{
    public class FundingCaptureViewModel
    {
        public int Id { get; set; }
        public string RefNo { get; set; }
        public int NpoId { get; set; }
        public int? FinancialYearId { get; set; }
        public string FinancialYearName { get; set; }
        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public bool IsActive { get; set; }

        public bool HasAddendum { get; set; }

        public string? ApproverUserName { get; set; }
        public string? ApprovedDate { get; set; }
        public string? ApproverComment { get; set; }

        public FundingDetailViewModel FundingDetailViewModel { get; set; }
        public SDAViewModel SDAViewModel { get; set; }
        public PaymentScheduleViewModel PaymentScheduleViewModel { get; set; }
        public BankDetailViewModel BankDetailViewModel { get; set; }
        public DocumentViewModel DocumentViewModel { get; set; }

        //List<FundingDetailViewModel> FundingDetailViewModels { get; set; }
    }
}
