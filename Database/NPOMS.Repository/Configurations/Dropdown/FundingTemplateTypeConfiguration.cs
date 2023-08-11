﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Dropdown;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Configurations.Dropdown
{
    public class FundingTemplateTypeConfiguration   : IEntityTypeConfiguration<FundingTemplateType>
    {
        public void Configure(EntityTypeBuilder<FundingTemplateType> builder)
        {
            builder.Property("IsActive").HasDefaultValueSql("1");
            builder.Property("CreatedUserId").HasDefaultValueSql("1");
            builder.Property("CreatedDateTime").HasDefaultValueSql("GetDate()");

            builder.HasData(
                new FundingTemplateType
                {
                    Id = 1,
                    Name = "Funding Application Template",
                    SystemName= "FundingApplicationTemplate",
                    IsActive= true
                }
            );
        }
    }
}
