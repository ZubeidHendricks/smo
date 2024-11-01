using NPOMS.Domain.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Entities
{
    public class SDIPReport : BaseEntity
    {
        public int StatusId { get; set; }

        public string StandardPerformanceArea { get; set; }
        public string CorrectiveAction { get; set; }

        public string Responsibility { get; set; }

        public string MeansOfVerification { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string TargetDate { get; set; }

        public int ApplicationId { get; set; }

        public string Progress { get; set; }

        public int QaurterId { get; set; }

        public bool IsActive { get; set; } = true;

        public int CreatedUserId { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public int? UpdatedUserId { get; set; }

        public DateTime? UpdatedDateTime { get; set; }

        public DateTime? ApprovalDateTime { get; set; }

        public User CreatedUser { get; set; }
        public Status Status { get; set; }

        public int FinancialYearId { get; set; }
        public string Comments { get; set; }

        public ICollection<SDIPReportAudit> SDIPReportAudits { get; set; }
    }
}
