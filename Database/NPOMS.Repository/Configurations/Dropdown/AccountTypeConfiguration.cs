using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPOMS.Domain.Dropdown;

namespace NPOMS.Repository.Configurations.Dropdown
{
	public class AccountTypeConfiguration : IEntityTypeConfiguration<AccountType>
	{
		public void Configure(EntityTypeBuilder<AccountType> builder)
		{
			builder.Property("IsActive").HasDefaultValueSql("1");
			builder.Property("CreatedUserId").HasDefaultValueSql("1");
			builder.Property("CreatedDateTime").HasDefaultValueSql("GetDate()");

			builder.HasData(
				new AccountType
				{
					Id = 1,
					Name = "SAVINGS",
					SystemName = null
				},
				new AccountType
				{
					Id = 2,
					Name = "CURRENT",
					SystemName = null
				},
				new AccountType
				{
					Id = 3,
					Name = "TRANSMISSION",
					SystemName = null
				},
				new AccountType
				{
					Id = 4,
					Name = "Subscription Share",
					SystemName = null
				},
				new AccountType
				{
					Id = 5,
					Name = "BOND",
					SystemName = null
				}
			);
		}
	}
}