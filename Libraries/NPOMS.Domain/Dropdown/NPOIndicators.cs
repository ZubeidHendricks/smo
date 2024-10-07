using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Domain.Dropdown
{
        [Table("NPOIndicator", Schema = "dropdown")]
        public class NPOIndicators : BaseEntity
        {
            public string Ccode { get; set; }  // Foreign Key
            public string OrganisationName { get; set; }
            public string Programme { get; set; }
            public string SubprogrammeType { get; set; }
            public string IndicatorId { get; set; }
            public string  Year { get; set; }
            public string AnnualTarget { get; set; }
            public string Q1 { get; set; }
            public string Q2 { get; set; }
            public string Q3 { get; set; }
            public string Q4 { get; set; }
            public bool IsActive { get; set; }
        }
}
