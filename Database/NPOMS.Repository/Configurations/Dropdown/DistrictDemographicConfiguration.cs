using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Dropdown;

namespace NPOMS.Repository.Configurations.Dropdown
{
    public class DistrictDemographicConfiguration : IEntityTypeConfiguration<DistrictDemographic>
    {
        public void Configure(EntityTypeBuilder<DistrictDemographic> builder)
        {
            builder.Property("IsActive").HasDefaultValueSql("1");
            builder.Property("CreatedUserId").HasDefaultValueSql("1");
            builder.Property("CreatedDateTime").HasDefaultValueSql("GetDate()");

            builder.HasData(
                new DistrictDemographic
                {
                    Id = 1,
                    Name = "MHS"
                },
                new DistrictDemographic
                {
                    Id = 2,
                    Name = "RHS"
                }
            );
        }
    }
}
