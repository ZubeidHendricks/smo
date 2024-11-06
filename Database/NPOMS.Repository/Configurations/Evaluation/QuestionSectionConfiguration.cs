using NPOMS.Domain.Evaluation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NPOMS.Repository.Configurations.Evaluation
{
	public class QuestionSectionConfiguration : IEntityTypeConfiguration<QuestionSection>
	{
		public void Configure(EntityTypeBuilder<QuestionSection> builder)
		{
			builder.HasIndex(x => new { x.QuestionCategoryId, x.Name }).IsUnique();
			builder.Property("IsActive").HasDefaultValueSql("1");
			builder.Property("CreatedUserId").HasDefaultValueSql("1");
			builder.Property("CreatedDateTime").HasDefaultValueSql("GetDate()");

			builder.HasData(
				new QuestionSection { Id = 1, QuestionCategoryId = 1, Name = "Pre-evaluation", SortOrder = 1 },
				new QuestionSection { Id = 2, QuestionCategoryId = 2, Name = "Alignment of the proposal to the Fund objectives", SortOrder = 1 },
				new QuestionSection { Id = 3, QuestionCategoryId = 2, Name = "Experience and ability (success)", SortOrder = 2 },
				new QuestionSection { Id = 4, QuestionCategoryId = 2, Name = "Level of co-funding", SortOrder = 3 },
				new QuestionSection { Id = 5, QuestionCategoryId = 2, Name = "Impact on business sustainability and/or expansion", SortOrder = 4 },
				new QuestionSection { Id = 6, QuestionCategoryId = 2, Name = "Monitoring and Evaluation", SortOrder = 5 },
				new QuestionSection { Id = 7, QuestionCategoryId = 2, Name = "Financial sustainability of the organisation", SortOrder = 6 },
				new QuestionSection { Id = 8, QuestionCategoryId = 3, Name = "Adjudication", SortOrder = 1 },


                //Assessment & Evaluation
                new QuestionSection { Id = 30, QuestionCategoryId = 20, Name = "Legislative Compliance", SortOrder = 1 },
                new QuestionSection { Id = 31, QuestionCategoryId = 20, Name = "PFMA Compliance", SortOrder = 2 },
                new QuestionSection { Id = 32, QuestionCategoryId = 20, Name = "Analysis Of Performance", SortOrder = 3 },
                new QuestionSection { Id = 33, QuestionCategoryId = 20, Name = "Assessment Summary", SortOrder = 4, IsActive = true, CreatedUserId=1, CreatedDateTime=DateTime.UtcNow},
                new QuestionSection { Id = 34, QuestionCategoryId = 20, Name = "Final Approver Section", SortOrder = 5, IsActive = true, CreatedUserId = 1, CreatedDateTime = DateTime.UtcNow }
            );
		}
	}
}
