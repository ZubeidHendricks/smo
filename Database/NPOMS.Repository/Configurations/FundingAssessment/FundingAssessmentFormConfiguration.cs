using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPOMS.Domain.Entities;
using NPOMS.Domain.FundingAssessment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Configurations.FundingAssessment
{
    public class FundingAssessmentFormConfiguration : IEntityTypeConfiguration<FundingAssessmentForm>
    {
        public void Configure(EntityTypeBuilder<FundingAssessmentForm> builder)
        {
            builder.HasOne(x=>x.Application).WithMany().HasForeignKey(x=>x.ApplicationId).OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.DOICapturerId).IsRequired(true);
            builder.Property(x => x.DOIApproverId).IsRequired(false);

            builder.Property(x => x.UpdatedDateTime).IsRequired(false);
            builder.Property(x => x.UpdatedUserId).IsRequired(false);

            builder.Property("CreatedUserId").HasDefaultValueSql("1");
            builder.Property("CreatedDateTime").HasDefaultValueSql("GetDate()");

        }
    }
}
