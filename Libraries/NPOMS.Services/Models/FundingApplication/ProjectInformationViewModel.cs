using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Services.Models.FundingApplication
{
    public class ProjectInformationViewModel
    {
        public int Id { get; set; }
        public string InitiatedQuestion { get; set; }
        public string considerQuestion { get; set; }
        public string purposeQuestion { get; set; }
    }
}
