using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPOMS.Domain.Dropdown;

namespace NPOMS.Repository.Configurations.Dropdown
{
	public class AllocationTypeConfiguration : IEntityTypeConfiguration<AllocationType>
	{
		public void Configure(EntityTypeBuilder<AllocationType> builder)
		{
			builder.Property("IsActive").HasDefaultValueSql("1");
			builder.Property("CreatedUserId").HasDefaultValueSql("1");
			builder.Property("CreatedDateTime").HasDefaultValueSql("GetDate()");

			builder.HasData(
				new AllocationType
				{
					Id = 1,
					Name = "Province",
					SystemName = "Province"
				},
				new AllocationType
				{
					Id = 2,
					Name = "City of Cape Town",
					SystemName = "CoCT"
				}
			);
		}
	}
}
