using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Services.Models.FundingApplication
{
    public class PropertySubTypeViewModel
    {
        public int Id { get; set; }
        public int PropertyTypeID { get; set; }
        public string Name { get; set; }
        public bool HaveComment { get; set; }
        public bool Repeatable { get; set; }
        public int? Frequency { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int CreatedUserID { get; set; }
        public int? UpdatedUserID { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
    }
}
