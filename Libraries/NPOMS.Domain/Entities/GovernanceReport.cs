using NPOMS.Domain.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Domain.Entities
{
    [Table("GovernanceReports", Schema = "dbo")]
    public class GovernanceReport : BaseEntity
    {
        [Column(TypeName = "nvarchar(50)")]
        public string LastMeetingDate { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string LastSubmissionDateWC { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string LastSubmissionDateNat { get; set; }
        public int StatusId { get; set; }
        public string Comments { get; set; }
        public bool IsActive { get; set; } = true;

        public int QaurterId { get; set; }
        public int ApplicationId { get; set; }

        public int FinancialYearId { get; set; }
        
        public int CreatedUserId { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public int? UpdatedUserId { get; set; }

        public DateTime? UpdatedDateTime { get; set; }

        public DateTime? ApprovalDateTime { get; set; }

        public User CreatedUser { get; set; }
        public Status Status { get; set; }
        public string ReportComments { get; set; }

        public ICollection<GovernanceAudit> GovernanceAudits { get; set; }
    }
}
