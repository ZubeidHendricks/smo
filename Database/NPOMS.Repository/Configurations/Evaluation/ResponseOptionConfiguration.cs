using NPOMS.Domain.Evaluation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NPOMS.Repository.Configurations.Evaluation
{
	public class ResponseOptionConfiguration : IEntityTypeConfiguration<ResponseOption>
	{
		public void Configure(EntityTypeBuilder<ResponseOption> builder)
		{
			builder.HasIndex( x => new { x.Name }).IsUnique();
			builder.Property("IsActive").HasDefaultValueSql("1");
			builder.Property("CreatedUserId").HasDefaultValueSql("1");
			builder.Property("CreatedDateTime").HasDefaultValueSql("GetDate()");

			builder.HasOne(x=>x.ResponseType).WithMany().HasForeignKey(x=>x.ResponseTypeId).OnDelete(DeleteBehavior.NoAction);

			builder.HasData(
				new ResponseOption { Id = 1, ResponseTypeId = 1, Name = "Yes", SystemName = "Yes" },
				new ResponseOption { Id = 2, ResponseTypeId = 1, Name = "No", SystemName = "No" },
				new ResponseOption { Id = 3, ResponseTypeId = 1, Name = "Not Applicable", SystemName = "N/A" },
				new ResponseOption { Id = 4, ResponseTypeId = 2, Name = "1", SystemName = "1" },
				new ResponseOption { Id = 5, ResponseTypeId = 2, Name = "2", SystemName = "2" },
				new ResponseOption { Id = 6, ResponseTypeId = 2, Name = "3", SystemName = "3" },
				new ResponseOption { Id = 7, ResponseTypeId = 2, Name = "4", SystemName = "4" },
				new ResponseOption { Id = 8, ResponseTypeId = 2, Name = "5", SystemName = "5" },

//Assessments & Evaluation
new ResponseOption { Id = 50, ResponseTypeId = 10, Name = "Approved", SystemName = "Option", IsActive = true, CreatedUserId = 1 },
new ResponseOption { Id = 51, ResponseTypeId = 10, Name = "Approved with conditions", SystemName = "Option", IsActive = true, CreatedUserId = 1 },
new ResponseOption { Id = 52, ResponseTypeId = 10, Name = "Not Approved", SystemName = "Option", IsActive = true, CreatedUserId = 1 },
new ResponseOption { Id = 53, ResponseTypeId = 11, Name = "Approved", SystemName = "Option", IsActive = true, CreatedUserId = 1 },
new ResponseOption { Id = 54, ResponseTypeId = 11, Name = "Not Approved", SystemName = "Option", IsActive = true, CreatedUserId = 1 },

new ResponseOption { Id = 55, ResponseTypeId = 12, Name = "Voluntary Association (VA)", SystemName = "Option", IsActive = true, CreatedUserId = 1 },
new ResponseOption { Id = 56, ResponseTypeId = 12, Name = "Non-Profit Company (NPC)", SystemName = "Option", IsActive = true, CreatedUserId = 1 },
new ResponseOption { Id = 57, ResponseTypeId = 12, Name = "Trust", SystemName = "Option", IsActive = true, CreatedUserId = 1 },
new ResponseOption { Id = 58, ResponseTypeId = 12, Name = "Non-Profit Organisation (NPO)", SystemName = "Option", IsActive = true, CreatedUserId = 1 },
new ResponseOption { Id = 59, ResponseTypeId = 12, Name = "Public Benefit Organisation (PBO and 18A)", SystemName = "Option", IsActive = true, CreatedUserId = 1 },
new ResponseOption { Id = 60, ResponseTypeId = 12, Name = "1 - Not Registered", SystemName = "Rating", IsActive = true, CreatedUserId = 1 },
new ResponseOption { Id = 61, ResponseTypeId = 12, Name = "2 - Registration in process ? acceptable proof/evidence provided", SystemName = "Rating", IsActive = true, CreatedUserId = 1 },
new ResponseOption { Id = 62, ResponseTypeId = 12, Name = "3 - Fully Registered", SystemName = "Rating", IsActive = true, CreatedUserId = 1 },

new ResponseOption { Id = 63, ResponseTypeId = 13, Name = "Older Persons Act, No 13 of 2006", SystemName = "Option", IsActive = true, CreatedUserId = 1 },
new ResponseOption { Id = 64, ResponseTypeId = 13, Name = "Children?s Act, No 38 of 2005", SystemName = "Option", IsActive = true, CreatedUserId = 1 },
new ResponseOption { Id = 65, ResponseTypeId = 13, Name = "Prevention and Treatment for Substance Abuse Act, No 70 of 2008", SystemName = "Option", IsActive = true, CreatedUserId = 1 },
new ResponseOption { Id = 66, ResponseTypeId = 13, Name = "Other", SystemName = "Option", IsActive = true, CreatedUserId = 1 },
new ResponseOption { Id = 67, ResponseTypeId = 13, Name = "0 - Not Applicable", SystemName = "Rating", IsActive = true, CreatedUserId = 1 },
new ResponseOption { Id = 68, ResponseTypeId = 13, Name = "1 - Not Registered", SystemName = "Rating", IsActive = true, CreatedUserId = 1 },
new ResponseOption { Id = 69, ResponseTypeId = 13, Name = "2 - Registration in Progress", SystemName = "Rating", IsActive = true, CreatedUserId = 1 },
new ResponseOption { Id = 70, ResponseTypeId = 13, Name = "3 - Fully Registered", SystemName = "Rating", IsActive = true, CreatedUserId = 1 },

new ResponseOption { Id = 71, ResponseTypeId = 14, Name = "Annual Financial Statement", SystemName = "Option", IsActive = true, CreatedUserId = 1 },
new ResponseOption { Id = 72, ResponseTypeId = 14, Name = "Certified Financial Statement", SystemName = "Option", IsActive = true, CreatedUserId = 1 },
new ResponseOption { Id = 73, ResponseTypeId = 14, Name = "Independent Review", SystemName = "Option", IsActive = true, CreatedUserId = 1 },
new ResponseOption { Id = 74, ResponseTypeId = 14, Name = "0 - Not Submitted", SystemName = "Rating", IsActive = true, CreatedUserId = 1 },
new ResponseOption { Id = 75, ResponseTypeId = 14, Name = "1 - Extension Granted", SystemName = "Rating", IsActive = true, CreatedUserId = 1 },
new ResponseOption { Id = 76, ResponseTypeId = 14, Name = "2 - Submitted", SystemName = "Rating", IsActive = true, CreatedUserId = 1 },

new ResponseOption { Id = 77, ResponseTypeId = 15, Name = "Full M&E report as per 3 - year cycle", SystemName = "Option", IsActive = true, CreatedUserId = 1 },
new ResponseOption { Id = 78, ResponseTypeId = 15, Name = "Comprehensive monitoring report including Quality Assurance", SystemName = "Option", IsActive = true, CreatedUserId = 1 },
new ResponseOption { Id = 79, ResponseTypeId = 15, Name = "Desktop monitoring Assessment including self-assessment", SystemName = "Option", IsActive = true, CreatedUserId = 1 },
new ResponseOption { Id = 80, ResponseTypeId = 15, Name = "Full M&E report with a SDIP and progress report", SystemName = "Option", IsActive = true, CreatedUserId = 1 },
new ResponseOption { Id = 81, ResponseTypeId = 15, Name = "Report resulting from allegations of fraud and/or corruption", SystemName = "Option", IsActive = true, CreatedUserId = 1 },
new ResponseOption { Id = 82, ResponseTypeId = 15, Name = "1 - No or minimal performance. Assess risk to partnership.", SystemName = "Rating", IsActive = true, CreatedUserId = 1 },
new ResponseOption { Id = 83, ResponseTypeId = 15, Name = "2 - Below competent performance. Assess risk to partnership.", SystemName = "Rating", IsActive = true, CreatedUserId = 1 },
new ResponseOption { Id = 84, ResponseTypeId = 15, Name = "3 - Competent performance as per the Business Plan submitted.", SystemName = "Rating", IsActive = true, CreatedUserId = 1 },
new ResponseOption { Id = 85, ResponseTypeId = 15, Name = "4 - Good performance. Commend partner for performance.", SystemName = "Rating", IsActive = true, CreatedUserId = 1 },
new ResponseOption { Id = 86, ResponseTypeId = 15, Name = "5 - Excellent performance. Consider for best practice standard", SystemName = "Rating", IsActive = true, CreatedUserId = 1 },

new ResponseOption { Id = 87, ResponseTypeId = 16, Name = "Q1", SystemName = "Option", IsActive = true, CreatedUserId = 1 },
new ResponseOption { Id = 88, ResponseTypeId = 16, Name = "Q2", SystemName = "Option", IsActive = true, CreatedUserId = 1 },
new ResponseOption { Id = 89, ResponseTypeId = 16, Name = "Q3", SystemName = "Option", IsActive = true, CreatedUserId = 1 },
new ResponseOption { Id = 90, ResponseTypeId = 16, Name = "Q4", SystemName = "Option", IsActive = true, CreatedUserId = 1 },
new ResponseOption { Id = 91, ResponseTypeId = 16, Name = "5 - Yes", SystemName = "Rating", IsActive = true, CreatedUserId = 1 },
new ResponseOption { Id = 92, ResponseTypeId = 16, Name = "1 - No", SystemName = "Rating", IsActive = true, CreatedUserId = 1 },

new ResponseOption { Id = 93, ResponseTypeId = 17, Name = "Q1", SystemName = "Option", IsActive = true, CreatedUserId = 1 },
new ResponseOption { Id = 94, ResponseTypeId = 17, Name = "Q2", SystemName = "Option", IsActive = true, CreatedUserId = 1 },
new ResponseOption { Id = 95, ResponseTypeId = 17, Name = "Q3", SystemName = "Option", IsActive = true, CreatedUserId = 1 },
new ResponseOption { Id = 96, ResponseTypeId = 17, Name = "Q4", SystemName = "Option", IsActive = true, CreatedUserId = 1 },
new ResponseOption { Id = 97, ResponseTypeId = 17, Name = "0 - Not Applicable", SystemName = "Rating", IsActive = true, CreatedUserId = 1, CreatedDateTime=DateTime.UtcNow },
new ResponseOption { Id = 98, ResponseTypeId = 17, Name = "1 - No", SystemName = "Rating", IsActive = true, CreatedUserId = 1 },
new ResponseOption { Id = 99, ResponseTypeId = 17, Name = "5 - Yes", SystemName = "Rating", IsActive = true, CreatedUserId = 1 },

new ResponseOption { Id = 100, ResponseTypeId = 18, Name = "None", SystemName = "None", IsActive = true, CreatedUserId = 1, CreatedDateTime = DateTime.UtcNow },

new ResponseOption { Id = 101, ResponseTypeId = 19, Name = "Not Funded", SystemName = "Option", IsActive = true, CreatedUserId = 1, CreatedDateTime = DateTime.UtcNow },
new ResponseOption { Id = 102, ResponseTypeId = 19, Name = "Funded with conditions (proceed)", SystemName = "Option", IsActive = true, CreatedUserId = 1, CreatedDateTime = DateTime.UtcNow },
new ResponseOption { Id = 103, ResponseTypeId = 19, Name = "Fund NPO (proceed)", SystemName = "Option", IsActive = true, CreatedUserId = 1, CreatedDateTime = DateTime.UtcNow }
            );
		}
	}
}
