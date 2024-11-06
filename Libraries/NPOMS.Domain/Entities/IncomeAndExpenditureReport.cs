using NPOMS.Domain.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Domain.Entities
{
    [Table("IncomeAndExpenditureReports", Schema = "dbo")]
    public class IncomeAndExpenditureReport : BaseEntity
    {
        public int StatusId { get; set; }

        public string CostDrivers { get; set; }
        public int Income { get; set; }

        public int Expenditure { get; set; }

        public int Surplus { get; set; }

        public int Total { get; set; }

        public int ApplicationId { get; set; }
        public bool IsActive { get; set; } = true;

        public int QaurterId { get; set; }

        public int CreatedUserId { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public int? UpdatedUserId { get; set; }

        public DateTime? UpdatedDateTime { get; set; }

        public DateTime? ApprovalDateTime { get; set; }

        public User CreatedUser { get; set; }

        public Status Status { get; set; }

        public int FinancialYearId { get; set; }

        public string Comments { get; set; }

        public ICollection<IncomeReportAudit> IncomeReportAudits { get; set; }
    }
}
