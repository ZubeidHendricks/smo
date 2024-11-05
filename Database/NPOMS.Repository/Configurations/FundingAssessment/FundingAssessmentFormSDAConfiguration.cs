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
    public class FundingAssessmentFormSDAConfiguration : IEntityTypeConfiguration<FundingAssessmentFormSDA>
    {
        public void Configure(EntityTypeBuilder<FundingAssessmentFormSDA> builder)
        {
            builder.HasOne(x => x.FundingAssessmentForm).WithMany().HasForeignKey(x => x.FundingAssessmentFormId).OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.ProgrameServiceDeliveryAreaId).IsRequired(true);
            builder.Property(x => x.IsSelected).IsRequired(true);

        }
    }
}
