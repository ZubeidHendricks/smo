using NPOMS.Domain.Core;
using System;

namespace NPOMS.Domain.Entities
{
    public class IncomeReportAudit : BaseEntity
    {
        public int IncomeAndExpenditureReportId { get; set; }

        public string StatusName { get; set; }

        public string CreatedUser { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public IncomeAndExpenditureReport IncomeAndExpenditureReports { get; set; }
    }
}
