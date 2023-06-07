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
    public class RaceConfiguration : IEntityTypeConfiguration<Race>
    {
        public void Configure(EntityTypeBuilder<Race> builder)
        {
            builder.Property("IsActive").HasDefaultValueSql("1");
            builder.Property("CreatedUserId").HasDefaultValueSql("1");
            builder.Property("CreatedDateTime").HasDefaultValueSql("GetDate()");

            builder.HasData(
                new Race
                {
                    Id = 1,
                    Name = "African"
                },
                new Race
                {
                    Id = 2,
                    Name = "Asian"
                },
                new Race
                {
                    Id = 3,
                    Name = "Coloured"
                },
                new Race
                {
                    Id = 4,
                    Name = "White"
                }               
            );
        }
    }
}