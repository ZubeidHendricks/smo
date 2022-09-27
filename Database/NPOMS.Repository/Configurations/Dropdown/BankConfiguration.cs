using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPOMS.Domain.Dropdown;

namespace NPOMS.Repository.Configurations.Dropdown
{
	public class BankConfiguration : IEntityTypeConfiguration<Bank>
	{
		public void Configure(EntityTypeBuilder<Bank> builder)
		{
			builder.Property("IsActive").HasDefaultValueSql("1");
			builder.Property("CreatedUserId").HasDefaultValueSql("1");
			builder.Property("CreatedDateTime").HasDefaultValueSql("GetDate()");

			builder.HasData(
				new Bank
				{
					Id = 1,
					Name = "ABSA Bank",
					Code = "632005"
				},
				new Bank
				{
					Id = 2,
					Name = "Capitec Bank",
					Code = "470010"
				},
				new Bank
				{
					Id = 3,
					Name = "First National Bank",
					Code = "250655"
				},
				new Bank
				{
					Id = 4,
					Name = "NedBank",
					Code = "198675"
				},
				new Bank
				{
					Id = 5,
					Name = "Standard Bank",
					Code = "051001"
				},
				new Bank
				{
					Id = 6,
					Name = "International Bank",
					Code = null
				},
				new Bank
				{
					Id = 7,
					Name = "Investec Bank",
					Code = "580105"
				},
				new Bank
				{
					Id = 8,
					Name = "Post Bank",
					Code = "460005"
				},
				new Bank
				{
					Id = 9,
					Name = "Default",
					Code = "000000"
				},
				new Bank
				{
					Id = 10,
					Name = "Bidvest",
					Code = null
				}
			);
		}
	}
}