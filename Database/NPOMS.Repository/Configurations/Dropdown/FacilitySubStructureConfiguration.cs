
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPOMS.Domain.Dropdown;

namespace NPOMS.Repository.Configurations.Dropdown
{
    public class FacilitySubStructureConfiguration : IEntityTypeConfiguration<FacilitySubStructure>
    {
        public void Configure(EntityTypeBuilder<FacilitySubStructure> builder)
        {
            builder.Property("IsActive").HasDefaultValueSql("1");
            builder.Property("CreatedUserId").HasDefaultValueSql("1");
            builder.Property("CreatedDateTime").HasDefaultValueSql("GetDate()");

            builder.HasData(
                new FacilitySubStructure
                {
                    Id = 1,
                    FacilityDistrictId = 1,
                    Name = "Cape Winelands"
                },
                new FacilitySubStructure
                {
                    Id = 2,
                    FacilityDistrictId = 2,
                    Name = "Cape Winelands"
                }        
            );
        }
    }
}

