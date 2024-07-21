using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace NPOMS.Domain.Entities
{
    [Table("Applications", Schema = "dbo")]
    public class Application : BaseEntity
    {
        [Column(TypeName = "char(15)")]
        public string RefNo { get; set; }

        public int NpoId { get; set; }

        public int ApplicationPeriodId { get; set; }

        public int StatusId { get; set; }

        public bool IsActive { get; set; }

        public int CreatedUserId { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public int? UpdatedUserId { get; set; }

        public DateTime? UpdatedDateTime { get; set; }

        public bool IsCloned { get; set; }

        public bool IsQuickCapture { get; set; }
        public int Step { get; set; }
        public int InitiateScorecard { get; set; }
        public int CloseScorecard { get; set; }
        public int ScorecardCount { get; set; }
        public Npo Npo { get; set; }
        public ApplicationPeriod ApplicationPeriod { get; set; }
        public Status Status { get; set; }
        public virtual List<NpoUserTracking> NpoUserTrackings { get; set; } = new List<NpoUserTracking>();
        public virtual List<NpoUserSatisfactionTracking> NpoUserSatisfactionTrackings { get; set; } = new List<NpoUserSatisfactionTracking>();
        public virtual List<NpoWorkPlanApproverTracking> NpoWorkPlanApproverTrackings { get; set; } = new List<NpoWorkPlanApproverTracking>();
    }
}
