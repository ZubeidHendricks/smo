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
    public class ManicipalityDemographicConfiguration : IEntityTypeConfiguration<ManicipalityDemographic>
    {
        public void Configure(EntityTypeBuilder<ManicipalityDemographic> builder)
        {
            builder.Property("IsActive").HasDefaultValueSql("1");
            builder.Property("CreatedUserId").HasDefaultValueSql("1");
            builder.Property("CreatedDateTime").HasDefaultValueSql("GetDate()");

            builder.HasData(
                new ManicipalityDemographic
                {
                    Id = 1,
                    Name = "City of Cape Town Metropolitan Municipality",
                    DistrictDemographicId = 1,
                    SubParentiId = 3,
                    
                },
                new ManicipalityDemographic
                {
                    Id = 2,
                    Name = "Cape Winelands District Municipality",
                    DistrictDemographicId = 2,

                },
                 new ManicipalityDemographic
                 {
                     Id = 3,
                     Name = "Central Karoo District Municipality",
                     DistrictDemographicId = 2
                 },
                new ManicipalityDemographic
                {
                    Id = 4,
                    Name = "Garden Route District Municipality",
                    DistrictDemographicId = 2
                },
                 new ManicipalityDemographic
                 {
                      Id = 5,
                      Name = "Overberg District Municipality",
                      DistrictDemographicId = 2
                 },
                new ManicipalityDemographic
                {
                    Id = 6,
                    Name = "West Coast District Municipality",
                    DistrictDemographicId = 2
                }
            );
        }
    }
}
