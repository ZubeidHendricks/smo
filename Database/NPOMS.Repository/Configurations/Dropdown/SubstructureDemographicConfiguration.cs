using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Dropdown;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Configurations.Dropdown
{
    public class SubstructureDemographicConfiguration : IEntityTypeConfiguration<SubstructureDemographic>
    {
        public void Configure(EntityTypeBuilder<SubstructureDemographic> builder)
        {
            builder.Property("IsActive").HasDefaultValueSql("1");
            builder.Property("CreatedUserId").HasDefaultValueSql("1");
            builder.Property("CreatedDateTime").HasDefaultValueSql("GetDate()");

            builder.HasData(
                new SubstructureDemographic
                {
                    Id = 1,
                    Name = "KESS",
                    ManicipalityDemographicId = 1

                },
                new SubstructureDemographic
                {
                    Id = 2,
                    Name = "KMSS",
                    ManicipalityDemographicId = 1,

                },
                new SubstructureDemographic
                {
                    Id = 3,
                    Name = "NTSS",
                    ManicipalityDemographicId = 1
                },
                new SubstructureDemographic
                {
                    Id = 4,
                    Name = "SWSS",
                    ManicipalityDemographicId = 1
                },
                new SubstructureDemographic
                {
                    Id = 5,
                    Name = "Cape winelands",
                    ManicipalityDemographicId = 2
                },
                new SubstructureDemographic
                {
                    Id = 6,
                    Name = "Central Karoo",
                    ManicipalityDemographicId = 3
                },
                new SubstructureDemographic
                {
                    Id = 7,
                    Name = "Garden Route",
                    ManicipalityDemographicId = 4
                },
                new SubstructureDemographic
                {
                    Id = 8,
                    Name = "Overbrgg",
                    ManicipalityDemographicId = 5
                },
                 new SubstructureDemographic
                 {
                     Id = 9,
                     Name = "West Coast",
                     ManicipalityDemographicId = 6
                 }
            );
        }
    }
}
