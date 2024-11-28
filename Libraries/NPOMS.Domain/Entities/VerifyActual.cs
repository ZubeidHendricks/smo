using NPOMS.Domain.Core;
using NPOMS.Domain.Dropdown;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Domain.Entities
{
    public class VerifyActual : BaseEntity
    {
        public int IndicatorReportId { get; set; }
        public int StatusId { get; set; }
        public int NPOReport { get; set; }
        public int Verified { get; set; }

        public int NotVerified { get; set; }

        public string QuarterlyTarget { get; set; }

        public string NotVerifiedReason { get; set; }

        public int TargetVariance { get; set; }

        public string TargetVarianceReason { get; set; }

        public int ApplicationId { get; set; }

        public int ServiceDeliveryAreaId { get; set; }

        public int QaurterId { get; set; }

        public bool IsActive { get; set; } = true;

        public int CreatedUserId { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public int? UpdatedUserId { get; set; }

        public DateTime? UpdatedDateTime { get; set; }

        public User CreatedUser { get; set; }

        public Status Status { get; set; }

    }
}