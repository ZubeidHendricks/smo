using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPOMS.Domain.Dropdown;

namespace NPOMS.Repository.Configurations.Dropdown
{
	public class ServiceTypeConfiguration : IEntityTypeConfiguration<ServiceType>
	{
		public void Configure(EntityTypeBuilder<ServiceType> builder)
		{
			builder.Property("IsActive").HasDefaultValueSql("1");
			builder.Property("CreatedUserId").HasDefaultValueSql("1");
			builder.Property("CreatedDateTime").HasDefaultValueSql("GetDate()");

			builder.HasData(
				new ServiceType
				{
					Id = 1,
					Name = "Direct Service Delivery",
					SystemName = "Direct"
				},
				new ServiceType
				{
					Id = 2,
					Name = "Non-Direct Service Delivery",
					SystemName = "Non-Direct"
				}
			);
		}
	}
}
