using NPOMS.Domain.Dropdown;
using NPOMS.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;


namespace NPOMS.Domain.Mapping
{
    [Table("ProgrameServiceDeliveryAreas", Schema = "mapping")]
    public class ProgrameServiceDeliveryArea : BaseEntity
    {
        public bool IsActive { get; set; }
        public int ProgrameServiceDeliveryId { get; set; }
        public virtual ProgrammeServiceDelivery ProgrameServiceDelivery { get; set; }
        public int ServiceDeliveryAreaId { get; set; }
        public virtual ServiceDeliveryArea ServiceDeliveryArea { get; set; }
    }
}
