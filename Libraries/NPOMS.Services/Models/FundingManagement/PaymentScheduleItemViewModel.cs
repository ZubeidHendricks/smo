namespace NPOMS.Services.Models.FundingManagement
{
    public class PaymentScheduleItemViewModel
    {
        public int Id { get; set; }
        public int PaymentScheduleId { get; set; }
        public int? CompliantCycleId { get; set; }
        public int? CycleNumber { get; set; }
        public string? PaymentDate { get; set; }
        public string? PaymentStatus { get; set; }
        public double? AllocatedAmount { get; set; }
        public double? ApprovedAmount { get; set; }
        public double? PaidAmount { get; set; }
        public bool IsActive { get; set; }
    }
}
