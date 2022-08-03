using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPOMS.Domain.Core;

namespace NPOMS.Repository.Configurations.Core
{
	public class EntityTypeConfiguration : IEntityTypeConfiguration<EntityType>
	{
		public void Configure(EntityTypeBuilder<EntityType> builder)
		{
			builder.Property("CreatedUserId").HasDefaultValueSql("1");
			builder.Property("CreatedDateTime").HasDefaultValueSql("GetDate()");

			builder.HasData(
				new EntityType
				{
					Id = 1,
					Name = "Supporting Documents",
					SystemName = "SupportingDocuments"
				},
				new EntityType
				{
					Id = 2,
					Name = "SLA",
					SystemName = "SLA"
				}
			);
		}
	}
}
