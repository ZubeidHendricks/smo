using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPOMS.Domain.Entities;

namespace NPOMS.Repository.Configurations.Entities
{
	public class CompliantCycleRuleConfiguration : IEntityTypeConfiguration<CompliantCycleRule>
	{
		public void Configure(EntityTypeBuilder<CompliantCycleRule> builder)
		{
			builder.Property("IsActive").HasDefaultValueSql("1");
			builder.Property("CreatedUserId").HasDefaultValueSql("1");
			builder.Property("CreatedDateTime").HasDefaultValueSql("GetDate()");

			builder.HasData(
				new CompliantCycleRule
				{
					Id = 1,
					CycleNumber = 1
				},
				new CompliantCycleRule
				{
					Id = 2,
					CycleNumber = 2
				},
				new CompliantCycleRule
				{
					Id = 3,
					CycleNumber = 3
				},
				new CompliantCycleRule
				{
					Id = 4,
					CycleNumber = 4
				}
			);
		}
	}
}
