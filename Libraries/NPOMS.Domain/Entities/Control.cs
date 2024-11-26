using NPOMS.Domain.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Domain.Entities
{
    [Table("Control", Schema = "dbo")]
    public partial class Control
    {
        public int ControlID { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public int CreatedUserID { get; set; }
        public Nullable<int> UpdatedUserID { get; set; }
        public System.DateTime CreatedDateTimestamp { get; set; }
        public Nullable<System.DateTime> UpdatedDateTimestamp { get; set; }

        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
    }
}

