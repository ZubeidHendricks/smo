using NPOMS.Domain.Core;
using System;

namespace NPOMS.Domain.Entities
{
    public class SDIPReportAudit : BaseEntity
    {
        public int SDIPReportId { get; set; }

        public string StatusName { get; set; }

        public string CreatedUser { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public SDIPReport SDIPReport { get; set; }
    }
}
