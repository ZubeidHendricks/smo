using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPOMS.Domain.Dropdown;

namespace NPOMS.Repository.Configurations.Dropdown
{
    public class CalculationTypeConfiguration : IEntityTypeConfiguration<CalculationType>
    {
        public void Configure(EntityTypeBuilder<CalculationType> builder)
        {
            builder.Property("IsActive").HasDefaultValueSql("1");
            builder.Property("CreatedUserId").HasDefaultValueSql("1");
            builder.Property("CreatedDateTime").HasDefaultValueSql("GetDate()");

            builder.HasData(
                new CalculationType { Id = 1, Name = "Detailed", SystemName = "Detailed" },
                new CalculationType { Id = 2, Name = "Summary", SystemName = "Summary" }
            );
        }
    }
}