
using NPOMS.Domain.Dropdown;
using NPOMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NPOMS.Domain.Mapping
{
    [Table("FundAppSDADetail_Regions", Schema = "mapping")]
    public class FundAppSDADetail_Region : BaseEntity
    {
        public bool IsActive { get; set; }
        public int FundAppSDADetailId { get; set; }
        public int RegionId { get; set; }
        public virtual Region Region { get; set; }
    }
}
