using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPOMS.Domain.Dropdown;

namespace NPOMS.Repository.Configurations.Dropdown
{
	public class RecipientTypeConfiguration : IEntityTypeConfiguration<RecipientType>
	{
		public void Configure(EntityTypeBuilder<RecipientType> builder)
		{
			builder.Property("IsActive").HasDefaultValueSql("1");
			builder.Property("CreatedUserId").HasDefaultValueSql("1");
			builder.Property("CreatedDateTime").HasDefaultValueSql("GetDate()");

			builder.HasData(
				new RecipientType
				{
					Id = 1,
					Name = "Primary",
					SystemName = "Primary"
				},
				new RecipientType
				{
					Id = 2,
					Name = "Sub-Recipient",
					SystemName = "SubRecipient"
				}
			);
		}
	}
}
