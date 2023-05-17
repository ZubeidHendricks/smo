using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Services.Models.FundingApplication
{
    public class PropertyTypeViewModel
    {
        public PropertyTypeViewModel()
        {
            PropertySubTypes = PropertySubTypes ?? new List<PropertySubTypeViewModel>();

        }
        public int Id { get; set; }
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
        public int? UpdatedUserID { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public bool HaveFrequency { get; set; }
        public List<PropertySubTypeViewModel> PropertySubTypes { get; set; }
    }
}
