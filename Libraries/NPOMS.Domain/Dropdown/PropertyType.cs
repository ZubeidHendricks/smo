using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Domain.Dropdown
{
    [Table("PropertyTypes", Schema = "dropdown")]
    public class PropertyType : BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public bool OnGeneralLevel { get; set; }
        public bool OnSubsidyLevel { get; set; }
        public bool CanDefineName { get; set; }
        public bool ValueOnGeneralLevel { get; set; }
        public bool ValueOnSybsidyLevel { get; set; }
        public bool HaveBreakDown { get; set; }
        public bool HaveRelatedProperty { get; set; }
        public bool IsBusinessRule { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int CreatedUserID { get; set; }
        public Nullable<int> UpdatedUserID { get; set; }
        public System.DateTime CreatedDateTime { get; set; }
        public Nullable<System.DateTime> UpdatedDateTime { get; set; }
        public bool HaveFrequency { get; set; }
        public virtual ICollection<PropertySubType> PropertySubTypes { get; set; }
    }
}