using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPOMS.Domain.Dropdown;

namespace NPOMS.Repository.Configurations.Dropdown
{
	public class FacilityDistrictConfiguration : IEntityTypeConfiguration<FacilityDistrict>
	{
		public void Configure(EntityTypeBuilder<FacilityDistrict> builder)
		{
			builder.Property("IsActive").HasDefaultValueSql("1");
			builder.Property("CreatedUserId").HasDefaultValueSql("1");
			builder.Property("CreatedDateTime").HasDefaultValueSql("GetDate()");

			builder.HasData(
				new FacilityDistrict
				{
					Id = 1,
					Name = "Cape Winelands District Municipality"
				},
				new FacilityDistrict
				{
					Id = 2,
					Name = "City of Cape Town Metropolitan Municipality"
				},
				new FacilityDistrict
				{
					Id = 3,
					Name = "West Coast District Municipality"
				},
				new FacilityDistrict
				{
					Id = 4,
					Name = "Overberg District Municipality"
				},
				new FacilityDistrict
				{
					Id = 5,
					Name = "Garden Route District Municipality"
				},
				new FacilityDistrict
				{
					Id = 6,
					Name = "Central Karoo District Municipality"
				}
			);
		}
	}
}
