using NPOMS.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Domain.Entities
{
    public class GovernanceAudit : BaseEntity
    {
        public int GovernanceReportId { get; set; }

        public string StatusName { get; set; }

        public string CreatedUser { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public GovernanceReport GovernanceReport { get; set; }
    }
}
