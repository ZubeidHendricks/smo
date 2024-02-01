using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPOMS.Domain.Core;
using System;

namespace NPOMS.Repository.Configurations.Core
{
    public class QuarterlyPeriodConfiguration : IEntityTypeConfiguration<QuarterlyPeriod>
    {
        public void Configure(EntityTypeBuilder<QuarterlyPeriod> builder)
        {
            builder.Property("IsActive").HasDefaultValueSql("1");
            builder.Property("CreatedUserId").HasDefaultValueSql("1");
            builder.Property("CreatedDateTime").HasDefaultValueSql("GetDate()");

            builder.HasData(
                new QuarterlyPeriod
                {
                    Id = 1,
                    Abbreviation = "Q1",
                    Name = "Quarter1",
                },
                 new QuarterlyPeriod
                 {
                     Id = 2,
                     Abbreviation = "Q2",
                     Name = "Quarter2",
                 },
                 new QuarterlyPeriod
                 {
                     Id = 3,
                     Abbreviation = "Q3",
                     Name = "Quarter3",
                 },
                 new QuarterlyPeriod
                 {
                     Id = 4,
                     Abbreviation = "Q4",
                     Name = "Quarter4",
                 }
            );
        }
    }
}
