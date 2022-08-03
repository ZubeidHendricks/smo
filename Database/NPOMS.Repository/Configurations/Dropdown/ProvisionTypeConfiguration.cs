using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPOMS.Domain.Dropdown;

namespace NPOMS.Repository.Configurations.Dropdown
{
	public class ProvisionTypeConfiguration : IEntityTypeConfiguration<ProvisionType>
	{
		public void Configure(EntityTypeBuilder<ProvisionType> builder)
		{
			builder.Property("IsActive").HasDefaultValueSql("1");
			builder.Property("CreatedUserId").HasDefaultValueSql("1");
			builder.Property("CreatedDateTime").HasDefaultValueSql("GetDate()");

			builder.HasData(
				new ProvisionType
				{
					Id = 1,
					Name = "Provided",
					SystemName = "Provided"
				},
				new ProvisionType
				{
					Id = 2,
					Name = "Required",
					SystemName = "Required"
				}
			);
		}
	}
}
