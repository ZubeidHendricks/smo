using NPOMS.Domain.Core;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Entities
{
    [Table("IndicatorReports", Schema = "dbo")]
    public  class IndicatorReport : BaseEntity
    {
        public int ProgrammeId { get; set; }

        public int SubProgrammeId { get; set; }

        public int SubProgrammeTypeId { get; set; }

        public string IndicatorValue { get; set; }
        
        public string Group { get; set; }
      
        public string ServiceDeliveryArea { get; set; }

        public bool IsActive { get; set; } = true;

        public int FinancialYear { get; set; }

        public string OutputTitle { get; set; }
        public int Actual { get; set; }
        public int Targets { get; set; }

        public int IndicatorId { get; set; }

        public int  Variance { get; set; }

        public string DeviationReason { get; set; }

        public int? AdjustedActual { get; set; }

        public int? AdjustedVariance { get; set; }

        public int ApplicationId { get; set; }   

        public int QaurterId { get; set; }

        public int CreatedUserId { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public int? UpdatedUserId { get; set; }

        public DateTime? UpdatedDateTime { get; set; }

        public DateTime? ApprovalDateTime { get; set; }

        public User CreatedUser { get; set; }

    }
}
