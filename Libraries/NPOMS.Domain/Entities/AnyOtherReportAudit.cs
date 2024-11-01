using NPOMS.Domain.Core;
using System;

namespace NPOMS.Domain.Entities
{
    public class AnyOtherReportAudit : BaseEntity
    {
        public int AnyOtherInformationReportId { get; set; }

        public string StatusName { get; set; }

        public string CreatedUser { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public AnyOtherInformationReport AnyOtherInformationReport { get; set; } 
    }
}
