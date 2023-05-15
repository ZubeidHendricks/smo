using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPOMS.Domain.Dropdown;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Configurations.Dropdown
{
    public class DistrictCouncilConfiguration : IEntityTypeConfiguration<DistrictCouncil>
    {
        public void Configure(EntityTypeBuilder<DistrictCouncil> builder)
        {
            builder.Property("IsActive").HasDefaultValueSql("1");
            builder.Property("CreatedUserId").HasDefaultValueSql("1");
            builder.Property("CreatedDateTime").HasDefaultValueSql("GetDate()");

            builder.HasData(
                new DistrictCouncil
                {
                    Id = 1,
                    Name = "Cape Town"
                },
                new DistrictCouncil
                {
                    Id = 2,
                    Name = "West Coast"
                },
                new DistrictCouncil
                {
                    Id = 3,
                    Name = "Cape Winelands"
                },
                new DistrictCouncil
                {
                    Id = 4,
                    Name = "Overberg"
                },
                new DistrictCouncil
                {
                    Id = 5,
                    Name = "Eden"
                },
                new DistrictCouncil
                {
                    Id = 6,
                    Name = "Central Karoo"
                }
            );
        }
    }
}
