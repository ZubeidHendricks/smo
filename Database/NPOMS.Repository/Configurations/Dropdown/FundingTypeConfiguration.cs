using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Dropdown;

namespace NPOMS.Repository.Configurations.Dropdown
{
    public class FundingTypeConfiguration : IEntityTypeConfiguration<FundingType>
    {
        public void Configure(EntityTypeBuilder<FundingType> builder)
        {
            builder.Property("IsActive").HasDefaultValueSql("1");
            builder.Property("CreatedUserId").HasDefaultValueSql("1");
            builder.Property("CreatedDateTime").HasDefaultValueSql("GetDate()");

            builder.HasData(
                new FundingType { Id = 1, Name = "Adhoc", SystemName = "Adhoc" },
                new FundingType { Id = 2, Name = "Annual", SystemName = "Annual" }
            );
        }
    }
}