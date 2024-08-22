using NPOMS.Domain.Dropdown;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.FundingManagement
{
    [Table("SDAs", Schema = "fm")]
    public class SDA : BaseEntity
    {
        public int FundingCaptureId { get; set; }

        public int ServiceDeliveryAreaId { get; set; }

        public int PlaceId { get; set; }

        public bool IsActive { get; set; }

        public int CreatedUserId { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public int? UpdatedUserId { get; set; }

        public DateTime? UpdatedDateTime { get; set; }

        public FundingCapture FundingCapture { get; set; }

        public Place Place { get; set; }
    }
}
