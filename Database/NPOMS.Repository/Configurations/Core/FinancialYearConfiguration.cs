using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPOMS.Domain.Core;
using System;

namespace NPOMS.Repository.Configurations.Core
{
	public class FinancialYearConfiguration : IEntityTypeConfiguration<FinancialYear>
	{
		public void Configure(EntityTypeBuilder<FinancialYear> builder)
		{
			builder.Property("IsActive").HasDefaultValueSql("1");
			builder.Property("CreatedUserId").HasDefaultValueSql("1");
			builder.Property("CreatedDateTime").HasDefaultValueSql("GetDate()");

			builder.HasData(
				new FinancialYear
				{
					Id = 1,
					Name = "2021/22",
					Year = 2021,
					StartDate = Convert.ToDateTime("2021-04-01 00:00:00.0000000"),
					EndDate = Convert.ToDateTime("2022-03-31 23:59:59.9999999")
				},
				new FinancialYear
				{
					Id = 2,
					Name = "2022/23",
					Year = 2022,
					StartDate = Convert.ToDateTime("2022-04-01 00:00:00.0000000"),
					EndDate = Convert.ToDateTime("2023-03-31 23:59:59.9999999")
				},
				new FinancialYear
				{
					Id = 3,
					Name = "2023/24",
					Year = 2023,
					StartDate = Convert.ToDateTime("2023-04-01 00:00:00.0000000"),
					EndDate = Convert.ToDateTime("2024-03-31 23:59:59.9999999")
				},
				new FinancialYear
				{
					Id = 4,
					Name = "2024/25",
					Year = 2024,
					StartDate = Convert.ToDateTime("2024-04-01 00:00:00.0000000"),
					EndDate = Convert.ToDateTime("2025-03-31 23:59:59.9999999")
				},
				new FinancialYear
				{
					Id = 5,
					Name = "2025/26",
					Year = 2025,
					StartDate = Convert.ToDateTime("2025-04-01 00:00:00.0000000"),
					EndDate = Convert.ToDateTime("2026-03-31 23:59:59.9999999")
				},
				new FinancialYear
				{
					Id = 6,
					Name = "2026/27",
					Year = 2026,
					StartDate = Convert.ToDateTime("2026-04-01 00:00:00.0000000"),
					EndDate = Convert.ToDateTime("2027-03-31 23:59:59.9999999")
				},
				new FinancialYear
				{
					Id = 7,
					Name = "2027/28",
					Year = 2027,
					StartDate = Convert.ToDateTime("2027-04-01 00:00:00.0000000"),
					EndDate = Convert.ToDateTime("2028-03-31 23:59:59.9999999")
				},
				new FinancialYear
				{
					Id = 8,
					Name = "2028/29",
					Year = 2028,
					StartDate = Convert.ToDateTime("2028-04-01 00:00:00.0000000"),
					EndDate = Convert.ToDateTime("2029-03-31 23:59:59.9999999")
				}
			);
		}
	}
}
