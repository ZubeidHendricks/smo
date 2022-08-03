using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPOMS.Domain.Dropdown;

namespace NPOMS.Repository.Configurations.Dropdown
{
	public class ResourceTypeConfiguration : IEntityTypeConfiguration<ResourceType>
	{
		public void Configure(EntityTypeBuilder<ResourceType> builder)
		{
			builder.Property("IsActive").HasDefaultValueSql("1");
			builder.Property("CreatedUserId").HasDefaultValueSql("1");
			builder.Property("CreatedDateTime").HasDefaultValueSql("GetDate()");

			builder.HasData(
				new ResourceType
				{
					Id = 1,
					Name = "HR",
					SystemName = "HR"
				},
				new ResourceType
				{
					Id = 2,
					Name = "Other than HR",
					SystemName = "Other"
				}
			);
		}
	}
}
