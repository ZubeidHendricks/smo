namespace NPOMS.Services.Models.FundingManagement
{
    public class SDAViewModel
    {
        public int Id { get; set; }
        public int FundingCaptureId { get; set; }
        public int? ServiceDeliveryAreaId { get; set; }
        public string? ServiceDeliveryAreaName { get; set; }
        public int? PlaceId { get; set; }
        public string? PlaceName { get; set; }
        public bool IsActive { get; set; }
    }
}
