using NPOMS.Domain.Evaluation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NPOMS.Repository.Configurations.Evaluation
{
	public class ResponseTypeConfiguration : IEntityTypeConfiguration<ResponseType>
	{
		public void Configure(EntityTypeBuilder<ResponseType> builder)
		{
			builder.HasIndex(x => new { x.Name }).IsUnique();
			builder.Property("IsActive").HasDefaultValueSql("1");
			builder.Property("CreatedUserId").HasDefaultValueSql("1");
			builder.Property("CreatedDateTime").HasDefaultValueSql("GetDate()");

			builder.HasData(
				new ResponseType
				{
					Id = 1,
					Name = "Close Ended",
					Description = "Yes, No and Not Applicable"
				},
				new ResponseType
				{
					Id = 2,
					Name = "Score",
					Description = "1, 2, 3, 4 and 5"
				}
			);
		}
	}
}
