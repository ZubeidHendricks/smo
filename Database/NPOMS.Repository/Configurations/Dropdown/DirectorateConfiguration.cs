using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPOMS.Domain.Dropdown;

namespace NPOMS.Repository.Configurations.Dropdown
{
	public class DirectorateConfiguration : IEntityTypeConfiguration<Directorate>
	{
		public void Configure(EntityTypeBuilder<Directorate> builder)
		{
			builder.Property("IsActive").HasDefaultValueSql("1");
			builder.Property("CreatedUserId").HasDefaultValueSql("1");
			builder.Property("CreatedDateTime").HasDefaultValueSql("GetDate()");

			builder.HasData(
				new Directorate
				{
					Id = 1,
					Name = "Children and Families",
					Description = ""
				},
				new Directorate
				{
					Id = 2,
					Name = "Community Development",
					Description = ""
				},
				new Directorate
				{
					Id = 3,
					Name = "ECD & Partial Care",
					Description = ""
				},
				new Directorate
				{
					Id = 4,
					Name = "Facility Management",
					Description = ""
				},
				new Directorate
				{
					Id = 5,
					Name = "Partnership Development",
					Description = ""
				},
				new Directorate
				{
					Id = 6,
					Name = "Restorative Services",
					Description = "Restorative Services new 2021 VEP, CP, SA"
				},
				new Directorate
				{
					Id = 7,
					Name = "Social Crime Prevention",
					Description = ""
				},
				new Directorate
				{
					Id = 8,
					Name = "Special Programmes",
					Description = ""
				}
			);
		}
	}
}
