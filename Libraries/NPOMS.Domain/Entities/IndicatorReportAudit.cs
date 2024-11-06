using NPOMS.Domain.Core;
using System;

namespace NPOMS.Domain.Entities
{
    public class IndicatorReportAudit : BaseEntity
    {
        public int IndicatorReportId { get; set; }

        public string StatusName { get; set; }

        public string CreatedUser { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public IndicatorReport IndicatorReport { get; set; }
    }
}
