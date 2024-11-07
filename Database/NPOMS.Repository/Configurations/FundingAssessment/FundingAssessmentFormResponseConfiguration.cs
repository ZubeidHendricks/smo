using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.FundingAssessment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Configurations.FundingAssessment
{
    public class FundingAssessmentFormResponseConfiguration : IEntityTypeConfiguration<FundingAssessmentFormResponse>
    {
        public void Configure(EntityTypeBuilder<FundingAssessmentFormResponse> builder)
        {
            builder.HasOne(x => x.FundingAssessmentForm).WithMany(x=>x.FundingAssessmentFormResponses).HasForeignKey(x => x.FundingAssessmentFormId).OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.QuestionId).IsRequired(true);
            builder.Property(x => x.ResponseOptionId).IsRequired(false);
            builder.Property(x => x.ResponseOptionSystemType).HasMaxLength(255);
            builder.Property(x => x.RatingValue).IsRequired(false);
            builder.Property(x => x.Comment).HasMaxLength(2000);

            builder.Property(x => x.UpdatedDateTime).IsRequired(false);
            builder.Property(x => x.UpdatedUserId).IsRequired(false);

            builder.Property("CreatedUserId").HasDefaultValueSql("1");
            builder.Property("CreatedDateTime").HasDefaultValueSql("GetDate()");
        }
    }
}
