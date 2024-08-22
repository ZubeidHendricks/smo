namespace NPOMS.Services.Models
{
    public class FundingDetailViewModel
    {
        public int Id { get; set; }
        public int FundingCaptureId { get; set; }
        public int FinancialYearId { get; set; }
        public string FinancialYearName { get; set; }
        public string StartDate { get; set; }
        public int FundingTypeId { get; set; }
        public string FundingTypeName { get; set; }
        public int FrequencyId { get; set; }
        public string FrequencyName { get; set; }
        public bool AllowVariableFunding { get; set; }
        public bool AllowClaims { get; set; }
        public int ProgrammeId { get; set; }
        public string ProgrammeName { get; set; }
        public int SubProgrammeId { get; set; }
        public string SubProgrammeName { get; set; }
        public int SubProgrammeTypeId { get; set; }
        public string SubProgrammeTypeName { get; set; }
        public double AmountAwarded { get; set; }
        public int CalculationTypeId { get; set; }
        public string CalculationTypeName { get; set; }
        public bool IsActive { get; set; }
    }
}
