using NPOMS.Domain.Dropdown;
using NPOMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Domain.Mapping
{
    [Table("ActivityDistricts", Schema = "core")]
    public class ActivityDistrict : BaseEntity
    {
        public int DemographicDistrictId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int ActivityId { get; set; }
        public Activity Activity { get; set; }
    }
}
