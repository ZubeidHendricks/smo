using NPOMS.Domain.Core;
using NPOMS.Domain.Dropdown;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.FundingManagement
{
    [Table("FundingDetails", Schema = "fm")]
    public class FundingDetail : BaseEntity
    {
        public int FundingCaptureId { get; set; }

        public int FinancialYearId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? StartDate { get; set; }

        public int FundingTypeId { get; set; }

        public int? FrequencyId { get; set; }

        public bool AllowVariableFunding { get; set; }

        public bool AllowClaims { get; set; }

        public int ProgrammeId { get; set; }

        public int SubProgrammeId { get; set; }

        public int SubProgrammeTypeId { get; set; }

        public double? AmountAwarded { get; set; }

        public int CalculationTypeId { get; set; }

        public bool IsAddendum { get; set; }

        public bool IsActive { get; set; }

        public int CreatedUserId { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public int? UpdatedUserId { get; set; }

        public DateTime? UpdatedDateTime { get; set; }

        public FundingCapture FundingCapture { get; set; }

        public FinancialYear FinancialYear { get; set; }

        public FundingType FundingType { get; set; }

        public Frequency Frequency { get; set; }

        public Programme Programme { get; set; }

        public SubProgramme SubProgramme { get; set; }

        public SubProgrammeType SubProgrammeType { get; set; }

        public CalculationType CalculationType { get; set; }
    }
}
