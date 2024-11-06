using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPOMS.Domain.Dropdown;

namespace NPOMS.Repository.Configurations.Dropdown
{
    public class IndicatorConfiguration : IEntityTypeConfiguration<Indicators>
    {
        public void Configure(EntityTypeBuilder<Indicators> builder)
        {

            builder.HasData(
                new Indicators
                {
                    Id = 1,
                    Year = "2024/25",
                    SubProgrammeTypeId = 1,
                    IndicatorValue = "2.2.1.1",
                    IndicatorDesc = "Number of subsidised beds in residential care facilities for Older Persons.",
                    OutputTitle = "Residential care services/facilities are available for Older Persons.",
                    AnnualTarget = "4661",
                    Q1 = "4661",
                    Q2 = "4661",
                    Q3 = "4661",
                    Q4 = "4661",
                    ShortDefinition = "The indicator counts the total number of subsidies transferred by the DSD to NPO residential facilities for Older Persons (i.e. 60 years and older) during the reporting period.",
                    Purpose = "Residential facilities provide for the care of Older Persons.",
                    KeyBeneficiaries = "Older Persons in accordance with the Older Persons Act (13/2006).",
                    SourceOfData = "HOD approved NPO funding submission(s) for the Sub-directorate: Services to Older Persons.",
                    DataLimitations = "None.",
                    Assumptions = "Social worker assessments of Older Persons for take up into the residential facilities are completed timeously.",
                    MeansOfVerification = "BAS Reconciliation Reports.",
                    MethodOfCalculation = "Count and report on the number of subsidies for bed spaces transferred to funded NPOs. Annual output is the highest achieved across the quarters.",
                    CalculationType = "Non-Cumulative",
                    ReportingCycle = "Quarterly",
                    DesiredPerformance = "On Target",
                    TypeOfIndicatorServiceDelivery = "NO",
                    TypeOfIndicatorDemandDriven = "Yes",
                    TypeOfIndicatorStandard = "NO",
                    SpatialLocationOfIndicator = "Multiple Locations",
                    IndicatorResponsibility = "Director: Vulnerable Groups",
                    SpatialTransformation = "Services are provided in all six (6) DSD regions of the Province.",
                    DisaggregationOfBeneficiaries = "Target for Older persons",
                    PSIP = "Wellbeing",
                    ImplementationData = "See approved AOP-2.2.1.1."
                }
            );
        }
    }
}
