using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPOMS.Domain.Core;
using NPOMS.Domain.Entities;
using System;

namespace NPOMS.Repository.Configurations.Entities
{
    public class PreviousYearFinanceConfiguration : IEntityTypeConfiguration<PreviousYearFinance>
    {
        public void Configure(EntityTypeBuilder<PreviousYearFinance> builder)
        {
        }
    }
}
