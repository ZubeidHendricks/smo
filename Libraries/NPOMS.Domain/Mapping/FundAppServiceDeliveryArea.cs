
using NPOMS.Domain.Dropdown;
using NPOMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NPOMS.Domain.Mapping
{
    [Table("ServiceDeliveryAreas", Schema = "mapping")]
    public class FundAppServiceDeliveryArea : BaseEntity
    {
        public int FundAppSDADetailId { get; set; }
        public bool IsActive { get; set; }
        public virtual FundAppSDADetail FundAppSDADetail { get; set; }
        public int ServiceDeliveryAreaId { get; set; }
        public virtual ServiceDeliveryArea ServiceDeliveryArea {  get; set; }
    }
}
