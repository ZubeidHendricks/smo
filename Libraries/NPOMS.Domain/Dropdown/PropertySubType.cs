using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Domain.Dropdown
{
    [Table("PropertySubTypes", Schema = "dropdown")]
    public class PropertySubType : BaseEntity
    {
        public int PropertyTypeID { get; set; }
        public string Name { get; set; }
        public bool HaveComment { get; set; }
        public bool Repeatable { get; set; }
        public Nullable<int> Frequency { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int CreatedUserID { get; set; }
        public Nullable<int> UpdatedUserID { get; set; }
        public System.DateTime CreatedDateTime { get; set; }
        public Nullable<System.DateTime> UpdatedDateTime { get; set; }
        public virtual PropertyType PropertyType { get; set; }
    }
}
