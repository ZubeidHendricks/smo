﻿using NPOMS.Domain.Evaluation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NPOMS.Repository.Configurations.Evaluation
{
	public class QuestionCategoryConfiguration : IEntityTypeConfiguration<QuestionCategory>
	{
		public void Configure(EntityTypeBuilder<QuestionCategory> builder)
		{
			builder.HasIndex(x => new { x.FundingTemplateTypeId, x.Name }).IsUnique();
			builder.Property("IsActive").HasDefaultValueSql("1");
			builder.Property("CreatedUserId").HasDefaultValueSql("1");
			builder.Property("CreatedDateTime").HasDefaultValueSql("GetDate()");

			builder.HasData(
				new QuestionCategory { Id = 1, FundingTemplateTypeId = 1, Name = "Pre-evaluation" },
				new QuestionCategory { Id = 2, FundingTemplateTypeId = 1, Name = "Evaluation" },
				new QuestionCategory { Id = 3, FundingTemplateTypeId = 1, Name = "Adjudication" }
			);
		}
	}
}