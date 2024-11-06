using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Dropdown;

namespace NPOMS.Repository.Configurations.Dropdown
{
    public class NPOIndicatorConfiguration : IEntityTypeConfiguration<NPOIndicators>
    {
        public void Configure(EntityTypeBuilder<NPOIndicators> builder)
        {

            builder.HasData(
                new NPOIndicators
                {
                    Id = 1,
                    Ccode = "3185",
                    OrganisationName = "ACVV Cape Town",
                    Programme = "Child care and protection services",
                    SubprogrammeType = "SERV ORGANISATION (CHILD CARE)",
                    IndicatorId = "3.3.1.1",
                    Year = "2024/25",
                    AnnualTarget = "4661",
                    Q1 = "10",
                    Q2 = "20",
                    Q3 = "30",
                    Q4 = "40",
          
           
                }
            );
        }
    }
}
