using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPOMS.Domain.Core;
using NPOMS.Domain.Entities;
using System;

namespace NPOMS.Repository.Configurations.Entities
{
    public class SourceOfInformationConfiguration : IEntityTypeConfiguration<SourceOfInformation>
    {
        public void Configure(EntityTypeBuilder<SourceOfInformation> builder)
        {
        }
    }
}
