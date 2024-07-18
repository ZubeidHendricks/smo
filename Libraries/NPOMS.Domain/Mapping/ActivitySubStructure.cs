using NPOMS.Domain.Dropdown;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Domain.Mapping
{
    public class ActivitySubStructure : BaseEntity
    {
        public int ActivityDistrictId { get; set; }
        public string Name { get; set; }
        public int SubStructureid { get; set; }
        public bool IsActive { get; set; }
        public ActivityDistrict ActivityDistrict { get; set; }
    }
}
