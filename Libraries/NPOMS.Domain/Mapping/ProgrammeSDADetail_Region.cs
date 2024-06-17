using NPOMS.Domain.Dropdown;
using NPOMS.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Mapping
{
    [Table("ProgrammeSDADetail_Regions", Schema = "mapping")]
    public class ProgrammeSDADetail_Region : BaseEntity
    {
        public bool IsActive { get; set; }
        public int ProgrameServiceDeliveryId { get; set; }
        public virtual ProgrammeServiceDelivery ProgrameServiceDelivery { get; set; }
        public int RegionId { get; set; }
        public virtual Region Region { get; set; }
    }
}