using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Services.Models
{
    public class dtoCfpApplication
    {
        public int id { get; set; }
        public string refNo { get; set; }
        public int npoId { get; set; }
        public int applicationPeriodId { get; set; }
        public int statusId { get; set; }
        public int step { get; set; }
        public int isActive { get; set; }
        public int isCloned { get; set; }
        public int isQuickCapture { get; set; }
        public int closeScorecard { get; set; }
        public int initiateScorecard { get; set; }
        public int scorecardCount { get; set; }
        public int rejectedScorecard { get; set; }
        public int submittedScorecard { get; set; }
        public int programmeId { get; set; }
        public int subProgrammeId { get; set; }
        public int subProgrammeTypeId { get; set; }
        public string purposeOfProject { get; set; }
    }
}
