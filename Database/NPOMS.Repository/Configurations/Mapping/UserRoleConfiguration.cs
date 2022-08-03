using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPOMS.Domain.Mapping;

namespace NPOMS.Repository.Configurations.Mapping
{
	public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
	{
		public void Configure(EntityTypeBuilder<UserRole> builder)
		{
			builder.Property("IsActive").HasDefaultValueSql("1");

			builder.HasData(
				new UserRole { Id = 1, UserId = 1, RoleId = 1 },
				new UserRole { Id = 2, UserId = 2, RoleId = 1 }
			);
		}
	}
}
