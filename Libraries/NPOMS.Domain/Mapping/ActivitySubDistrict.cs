using NPOMS.Domain.Dropdown;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Domain.Mapping
{
    [Table("ActivitySubDistricts", Schema = "mapping")]
    public class ActivitySubDistrict : BaseEntity
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int ActivityDistrictId { get; set; }
        public ActivityDistrict ActivityDistrict { get; set; }
        public int FacilityDistrictId { get; set; }
        public FacilitySubDistrict FacilitySubDistrict { get; set; }
    }
}
