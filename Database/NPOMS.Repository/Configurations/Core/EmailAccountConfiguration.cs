using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPOMS.Domain.Core;

namespace NPOMS.Repository.Configurations.Core
{
	public class EmailAccountConfiguration : IEntityTypeConfiguration<EmailAccount>
	{
		public void Configure(EntityTypeBuilder<EmailAccount> builder)
		{
			builder.Property("CreatedUserId").HasDefaultValueSql("1");
			builder.Property("CreatedDateTime").HasDefaultValueSql("GetDate()");

			builder.HasData(
				new EmailAccount
				{
					Id = 1,
					Description = "default account",
					FromDisplayName = "NPO Management System",
					FromEmail = "no-reply@westerncape.gov.za",
					Host = "https://wa-taps-smtp-nonprod-zan.azurewebsites.net/api/user/EmailSend",
					Port = 25,
					EnableSSL = false
				}
			);
		}
	}
}
