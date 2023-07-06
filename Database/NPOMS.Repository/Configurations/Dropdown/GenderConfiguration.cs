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
    public class GenderConfiguration : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.Property("IsActive").HasDefaultValueSql("1");
            builder.Property("CreatedUserId").HasDefaultValueSql("1");
            builder.Property("CreatedDateTime").HasDefaultValueSql("GetDate()");

            builder.HasData(
                new Gender
                {
                    Id = 1,
                    Name = "Female"
                },
                new Gender
                {
                    Id = 2,
                    Name = "Male"
                },
                new Gender
                {
                    Id = 3,
                    Name = "Other"
                }
            );
        }
    }
}