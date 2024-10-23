using NPOMS.Domain.Evaluation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NPOMS.Repository.Configurations.Evaluation
{
	public class ResponseOptionConfiguration : IEntityTypeConfiguration<ResponseOption>
	{
		public void Configure(EntityTypeBuilder<ResponseOption> builder)
		{
			builder.HasIndex(x => new { x.Name }).IsUnique();
			builder.Property("IsActive").HasDefaultValueSql("1");
			builder.Property("CreatedUserId").HasDefaultValueSql("1");
			builder.Property("CreatedDateTime").HasDefaultValueSql("GetDate()");

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
                new ResponseOption { Id = 50, ResponseTypeId = 10, Name = "Approved", SystemName = "Approved", IsActive=true, CreatedUserId=1, CreatedDateTime=DateTime.Now },
                new ResponseOption { Id = 51, ResponseTypeId = 10, Name = "Approved with conditions", SystemName = "ApprovedWithConditions" ,IsActive = true, CreatedUserId = 1, CreatedDateTime = DateTime.Now },
                new ResponseOption { Id = 52, ResponseTypeId = 10, Name = "No Approved", SystemName = "NotApproved", IsActive = true, CreatedUserId = 1, CreatedDateTime = DateTime.Now },
                new ResponseOption { Id = 53, ResponseTypeId = 11, Name = "Approved", SystemName = "Approved", IsActive = true, CreatedUserId = 1, CreatedDateTime = DateTime.Now },
                new ResponseOption { Id = 54, ResponseTypeId = 11, Name = "Not Approved", SystemName = "NotApproved", IsActive = true, CreatedUserId = 1, CreatedDateTime = DateTime.Now }
            );
		}
	}
}
