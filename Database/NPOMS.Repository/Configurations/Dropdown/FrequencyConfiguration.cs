using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPOMS.Domain.Dropdown;

namespace NPOMS.Repository.Configurations.Dropdown
{
	public class FrequencyConfiguration : IEntityTypeConfiguration<Frequency>
	{
		public void Configure(EntityTypeBuilder<Frequency> builder)
		{
			builder.Property("IsActive").HasDefaultValueSql("1");
			builder.Property("CreatedUserId").HasDefaultValueSql("1");
			builder.Property("CreatedDateTime").HasDefaultValueSql("GetDate()");

			builder.HasData(
				new Frequency
				{
					Id = 1,
					Name = "Annually",
					SystemName = "Annually"
				},
				new Frequency
				{
					Id = 2,
					Name = "Monthly",
					SystemName = "Monthly"
				},
				new Frequency
				{
					Id = 3,
					Name = "Quarterly",
					SystemName = "Quarterly"
				}
			);
		}
	}
}
