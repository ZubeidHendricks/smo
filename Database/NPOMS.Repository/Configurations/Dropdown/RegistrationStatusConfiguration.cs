using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPOMS.Domain.Dropdown;

namespace NPOMS.Repository.Configurations.Dropdown
{
	public class RegistrationStatusConfiguration : IEntityTypeConfiguration<RegistrationStatus>
	{
		public void Configure(EntityTypeBuilder<RegistrationStatus> builder)
		{
			builder.Property("IsActive").HasDefaultValueSql("1");
			builder.Property("CreatedUserId").HasDefaultValueSql("1");
			builder.Property("CreatedDateTime").HasDefaultValueSql("GetDate()");

			builder.HasData(
				new RegistrationStatus { Id = 1, Name = "Registered", SystemName = "Registered" },
				new RegistrationStatus { Id = 2, Name = "Not Registered", SystemName = "NotRegistered" },
				new RegistrationStatus { Id = 3, Name = "In Progress", SystemName = "InProgress" }
			);
		}
	}
}
