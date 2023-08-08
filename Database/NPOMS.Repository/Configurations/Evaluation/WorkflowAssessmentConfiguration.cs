using NPOMS.Domain.Evaluation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NPOMS.Repository.Configurations.Evaluation
{
	public class WorkflowAssessmentConfiguration : IEntityTypeConfiguration<WorkflowAssessment>
	{
		public void Configure(EntityTypeBuilder<WorkflowAssessment> builder)
		{
			builder.HasIndex(x => new { x.QuestionCategoryId }).IsUnique();
			builder.Property("IsActive").HasDefaultValueSql("1");
			builder.Property("CreatedUserId").HasDefaultValueSql("1");
			builder.Property("CreatedDateTime").HasDefaultValueSql("GetDate()");

			builder.HasData(
				new WorkflowAssessment { Id = 1, QuestionCategoryId = 1, NumberOfAssessments = 1 },
				new WorkflowAssessment { Id = 2, QuestionCategoryId = 2, NumberOfAssessments = 4 },
				new WorkflowAssessment { Id = 3, QuestionCategoryId = 3, NumberOfAssessments = 4 }
			);
		}
	}
}
