using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPOMS.Domain.Dropdown;

namespace NPOMS.Repository.Configurations.Dropdown
{
	public class ActivityTypeConfiguration : IEntityTypeConfiguration<ActivityType>
	{
		public void Configure(EntityTypeBuilder<ActivityType> builder)
		{
			builder.Property("IsActive").HasDefaultValueSql("1");
			builder.Property("CreatedUserId").HasDefaultValueSql("1");
			builder.Property("CreatedDateTime").HasDefaultValueSql("GetDate()");

			builder.HasData(
				new ActivityType
				{
					Id = 1,
					Name = "New",
					SystemName = "New"
				},
				new ActivityType
				{
					Id = 2,
					Name = "Ongoing",
					SystemName = "Ongoing"
				}
			);
		}
	}
}
