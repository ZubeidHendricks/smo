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
    public class AreaConfiguration : IEntityTypeConfiguration<Area>
    {
        public void Configure(EntityTypeBuilder<Area> builder)
        {
            builder.Property("IsActive").HasDefaultValueSql("1");
            builder.Property("CreatedUserId").HasDefaultValueSql("1");
            builder.Property("CreatedDateTime").HasDefaultValueSql("GetDate()");

            builder.HasData(
                new Area
                {
                    Id = 1,
                    Name = "Central",
                    DistrictId = 3

                },
                new Area
                {
                    Id = 2,
                    Name = "North",
                    DistrictId = 3,

                },
                 new Area
                 {
                     Id = 3,
                     Name = "East",
                     DistrictId = 3,
                 },
                new Area
                {
                    Id = 4,
                    Name = "South",
                    DistrictId = 3
                }
                
            );
        }
    }
}
