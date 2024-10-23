using NPOMS.Domain.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Domain.Entities
{
    public class SDIPReport : BaseEntity
    {
        public int StatusId { get; set; }

        public string StandardPerformanceArea { get; set; }
        public string CorrectiveAction { get; set; }

        public int Responsibility { get; set; }

        public string MeansOfVerification { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string TargetDate { get; set; }

        public int ApplicationId { get; set; }

        public int QaurterId { get; set; }

        public bool IsActive { get; set; } = true;

        public int CreatedUserId { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public int? UpdatedUserId { get; set; }

        public DateTime? UpdatedDateTime { get; set; }

        public DateTime? ApprovalDateTime { get; set; }

        public User CreatedUser { get; set; }
        public Status Status { get; set; }
    }
}
