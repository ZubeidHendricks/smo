using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPOMS.Domain.Dropdown;

namespace NPOMS.Repository.Configurations.Dropdown
{
	public class FrequencyPeriodConfiguration : IEntityTypeConfiguration<FrequencyPeriod>
	{
		public void Configure(EntityTypeBuilder<FrequencyPeriod> builder)
		{
			builder.Property("IsActive").HasDefaultValueSql("1");
			builder.Property("CreatedUserId").HasDefaultValueSql("1");
			builder.Property("CreatedDateTime").HasDefaultValueSql("GetDate()");

			builder.HasData(
				new FrequencyPeriod
				{
					Id = 1,
					FrequencyId = 1,
					Name = "Annual",
					SystemName = "Annual"
				},
				new FrequencyPeriod
				{
					Id = 2,
					FrequencyId = 2,
					Name = "April",
					SystemName = "Apr"
				},
				new FrequencyPeriod
				{
					Id = 3,
					FrequencyId = 2,
					Name = "May",
					SystemName = "May"
				},
				new FrequencyPeriod
				{
					Id = 4,
					FrequencyId = 2,
					Name = "June",
					SystemName = "Jun"
				},
				new FrequencyPeriod
				{
					Id = 5,
					FrequencyId = 2,
					Name = "July",
					SystemName = "Jul"
				},
				new FrequencyPeriod
				{
					Id = 6,
					FrequencyId = 2,
					Name = "August",
					SystemName = "Aug"
				},
				new FrequencyPeriod
				{
					Id = 7,
					FrequencyId = 2,
					Name = "September",
					SystemName = "Sep"
				},
				new FrequencyPeriod
				{
					Id = 8,
					FrequencyId = 2,
					Name = "October",
					SystemName = "Oct"
				},
				new FrequencyPeriod
				{
					Id = 9,
					FrequencyId = 2,
					Name = "November",
					SystemName = "Nov"
				},
				new FrequencyPeriod
				{
					Id = 10,
					FrequencyId = 2,
					Name = "December",
					SystemName = "Dec"
				},
				new FrequencyPeriod
				{
					Id = 11,
					FrequencyId = 2,
					Name = "January",
					SystemName = "Jan"
				},
				new FrequencyPeriod
				{
					Id = 12,
					FrequencyId = 2,
					Name = "February",
					SystemName = "Feb"
				},
				new FrequencyPeriod
				{
					Id = 13,
					FrequencyId = 2,
					Name = "March",
					SystemName = "Mar"
				},
				new FrequencyPeriod
				{
					Id = 14,
					FrequencyId = 3,
					Name = "Quarter1",
					SystemName = "Q1"
				},
				new FrequencyPeriod
				{
					Id = 15,
					FrequencyId = 3,
					Name = "Quarter2",
					SystemName = "Q2"
				},
				new FrequencyPeriod
				{
					Id = 16,
					FrequencyId = 3,
					Name = "Quarter3",
					SystemName = "Q3"
				},
				new FrequencyPeriod
				{
					Id = 17,
					FrequencyId = 3,
					Name = "Quarter4",
					SystemName = "Q4"
				}
			);
		}
	}
}
