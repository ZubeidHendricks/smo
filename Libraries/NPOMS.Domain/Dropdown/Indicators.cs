using System.ComponentModel.DataAnnotations.Schema;

namespace NPOMS.Domain.Dropdown
{
    [Table("Indicator", Schema = "dropdown")]
    public class Indicators: BaseEntity
    {
        public int SubProgrammeTypeId { get; set; }  // Foreign Key
        public string IndicatorValue { get; set; }
        public string Year { get; set; }
        public bool IsActive { get; set; }  
        public string AnnualTarget { get; set; }
        public string Q1 { get; set; }
        public string Q2 { get; set; }
        public string Q3 { get; set; }
        public string Q4 { get; set; }
        public string ShortDefinition { get; set; }
        public string Purpose { get; set; }
        public string KeyBeneficiaries { get; set; }
        public string SourceOfData { get; set; }
        public string DataLimitations { get; set; }
        public string Assumptions { get; set; }
        public string MeansOfVerification { get; set; }
        public string MethodOfCalculation { get; set; }
        public string CalculationType { get; set; }
        public string ReportingCycle { get; set; }
        public string DesiredPerformance { get; set; }
        public string TypeOfIndicatorServiceDelivery { get; set; }
        public string TypeOfIndicatorDemandDriven { get; set; }
        public string TypeOfIndicatorStandard { get; set; }
        public string SpatialLocationOfIndicator { get; set; }
        public string IndicatorResponsibility { get; set; }
        public string SpatialTransformation { get; set; }
        public string DisaggregationOfBeneficiaries { get; set; }
        public string PSIP { get; set; }
        public string ImplementationData { get; set; }
    }

}
