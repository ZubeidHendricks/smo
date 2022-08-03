using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPOMS.Domain.Entities;

namespace NPOMS.Repository.Configurations.Entities
{
	public class TrainingMaterialConfiguration : IEntityTypeConfiguration<TrainingMaterial>
	{
		public void Configure(EntityTypeBuilder<TrainingMaterial> builder)
		{
			builder.HasIndex(x => x.Name).IsUnique();
			builder.Property("IsActive").HasDefaultValueSql("1");
			builder.Property("CreatedUserId").HasDefaultValueSql("1");
			builder.Property("CreatedDateTime").HasDefaultValueSql("GetDate()");

			builder.HasData(
				new TrainingMaterial
				{
					Id = 1,
					Name = "Applicant Guide",
					Description = "This guide illustrates how to capture workplans",
					Link = "https://www.westerncape.gov.za/dept/health"
				},
				new TrainingMaterial
				{
					Id = 2,
					Name = "Reviewer Guide",
					Description = "This guide illustrates how to review workplans",
					Link = "https://www.westerncape.gov.za/dept/health"
				}
			);
		}
	}
}
