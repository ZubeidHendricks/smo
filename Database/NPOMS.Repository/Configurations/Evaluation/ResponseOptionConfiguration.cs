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
				new ResponseOption { Id = 8, ResponseTypeId = 2, Name = "5", SystemName = "5" }
			);
		}
	}
}
