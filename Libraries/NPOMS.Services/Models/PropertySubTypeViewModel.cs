using System;
using System.Collections.Generic;
using System.Text;

namespace NPOMS.Services.Models
{
    public class PropertySubTypeViewModel
    {
        public int Id { get; set; }
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
    }
}
