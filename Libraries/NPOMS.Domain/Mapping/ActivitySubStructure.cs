using NPOMS.Domain.Dropdown;
using NPOMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Domain.Mapping
{
    public class ActivitySubStructure : BaseEntity
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int ActivityId { get; set; }
        public int MunicipalityId { get; set; }
        public Activity Activity { get; set; }
    }
}
