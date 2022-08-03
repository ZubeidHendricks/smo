using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPOMS.Domain.Core;

namespace NPOMS.Repository.Configurations.Core
{
	public class UserConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.Property("IsActive").HasDefaultValueSql("1");
			builder.Property("IsB2C").HasDefaultValueSql("0");
			builder.Property("CreatedUserId").HasDefaultValueSql("1");
			builder.Property("CreatedDateTime").HasDefaultValueSql("GetDate()");

			builder.HasData(
				new User
				{
					Id = 1,
					Email = "npoms.admin@westerncape.gov.za",
					UserName = "npoms.admin@westerncape.gov.za",
					FirstName = "System",
					LastName = "User"
				},
				new User
				{
					Id = 2,
					Email = "Taariq.Kamaar@westerncape.gov.za",
					UserName = "Taariq.Kamaar@westerncape.gov.za",
					FirstName = "Taariq",
					LastName = "Kamaar"
				}
			);
		}
	}
}
