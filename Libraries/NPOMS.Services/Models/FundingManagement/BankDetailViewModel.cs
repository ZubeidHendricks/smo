namespace NPOMS.Services.Models.FundingManagement
{
    public class BankDetailViewModel
    {
        public int Id { get; set; }
        public int FundingCaptureId { get; set; }
        public int ProgrammeBankDetailId { get; set; }
        public bool IsActive { get; set; }
    }
}
