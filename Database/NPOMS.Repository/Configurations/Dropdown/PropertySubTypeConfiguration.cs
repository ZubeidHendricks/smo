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
    public class PropertySubTypeConfiguration : IEntityTypeConfiguration<PropertySubType>
    {
        public void Configure(EntityTypeBuilder<PropertySubType> builder)
        {
            builder.HasData(
    new PropertySubType
    {
        Id = 1,
        PropertyTypeID = 3,
        Name = "Monthly",
        HaveComment = false,
        Repeatable = true,
        Frequency = 12,

        IsActive = true,
        IsDeleted = false,
        CreatedUserID = 3,
        CreatedDateTime = DateTime.Now,


    },
        new PropertySubType
        {
            Id = 2,
            PropertyTypeID = 3,
            Name = "Annually",
            HaveComment = false,
            Repeatable = true,
            Frequency = 1,

            IsActive = true,
            IsDeleted = false,
            CreatedUserID = 3,
            CreatedDateTime = DateTime.Now,


        },
        new PropertySubType
        {
            Id = 3,
            PropertyTypeID = 3,
            Name = "264 Days",
            HaveComment = false,
            Repeatable = true,
            Frequency = 264,

            IsActive = true,
            IsDeleted = false,
            CreatedUserID = 3,
            CreatedDateTime = DateTime.Now
        },
            new PropertySubType
            {
                Id = 4,
                PropertyTypeID = 3,
                Name = "240 Days",
                HaveComment = false,
                Repeatable = true,
                Frequency = 240,

                IsActive = true,
                IsDeleted = false,
                CreatedUserID = 3,
                CreatedDateTime = DateTime.Now
            });
        }
    }
}
