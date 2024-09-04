namespace NPOMS.Services.Models.FundingManagement
{
    public class BankDetailViewModel
    {
        public int Id { get; set; }
        public int FundingCaptureId { get; set; }
        public int? ProgramBankDetailsId { get; set; }
        public string? BankName { get; set; }
        public string? BranchName { get; set; }
        public string? AccountTypeName { get; set; }
        public string? AccountNumber { get; set; }
        public bool IsActive { get; set; }
    }
}
