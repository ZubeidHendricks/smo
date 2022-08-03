using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPOMS.Domain.Dropdown;

namespace NPOMS.Repository.Configurations.Dropdown
{
	public class FacilityTypeConfiguration : IEntityTypeConfiguration<FacilityType>
	{
		public void Configure(EntityTypeBuilder<FacilityType> builder)
		{
			builder.Property("IsActive").HasDefaultValueSql("1");
			builder.Property("CreatedUserId").HasDefaultValueSql("1");
			builder.Property("CreatedDateTime").HasDefaultValueSql("GetDate()");

			builder.HasData(
				new FacilityType
				{
					Id = 1,
					Name = "Facility"
				},
				new FacilityType
				{
					Id = 2,
					Name = "Community Place"
				}
			);
		}
	}
}
