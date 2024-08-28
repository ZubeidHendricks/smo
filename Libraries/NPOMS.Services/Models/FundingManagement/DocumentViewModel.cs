namespace NPOMS.Services.Models.FundingManagement
{
    public class DocumentViewModel
    {
        public int Id { get; set; }
        public int FundingCaptureId { get; set; }
        public string? TPALink { get; set; }
        public bool IsActive { get; set; }
    }
}
