using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPOMS.Domain.Dropdown;

namespace NPOMS.Repository.Configurations.Dropdown
{
	public class SubProgrammeConfiguration : IEntityTypeConfiguration<SubProgramme>
	{
		public void Configure(EntityTypeBuilder<SubProgramme> builder)
		{
			builder.Property("IsActive").HasDefaultValueSql("1");
			builder.Property("CreatedUserId").HasDefaultValueSql("1");
			builder.Property("CreatedDateTime").HasDefaultValueSql("GetDate()");

			builder.HasData(
				new SubProgramme
				{
					Id = 1,
					Name = "All Sub-Programmes",
					SystemName = "ALL",
					ProgrammeId = 1
				},
				new SubProgramme
				{
					Id = 2,
					Name = "Chronic Diseases",
					SystemName = "CD",
					ProgrammeId = 2
				},
				new SubProgramme
				{
					Id = 3,
					Name = "NCDs",
					SystemName = "NCDs",
					ProgrammeId = 2
				},
				new SubProgramme
				{
					Id = 4,
					Name = "HIV/AIDS",
					SystemName = "HIV",
					ProgrammeId = 3
				},
				new SubProgramme
				{
					Id = 5,
					Name = "TB",
					SystemName = "TB",
					ProgrammeId = 3
				},
				new SubProgramme
				{
					Id = 6,
					Name = "STI",
					SystemName = "STI",
					ProgrammeId = 3
				},
				new SubProgramme
				{
					Id = 7,
					Name = "Maternal Health",
					SystemName = "MH",
					ProgrammeId = 4
				},
				new SubProgramme
				{
					Id = 8,
					Name = "Women's Health",
					SystemName = "WH",
					ProgrammeId = 4
				},
				new SubProgramme
				{
					Id = 9,
					Name = "Child and Adolescent Helath",
					SystemName = "CAH",
					ProgrammeId = 4
				},
				new SubProgramme
				{
					Id = 10,
					Name = "Theatre",
					SystemName = "Theatre",
					ProgrammeId = 5
				},
				new SubProgramme
				{
					Id = 11,
					Name = "Surgery",
					SystemName = "Surgery",
					ProgrammeId = 5
				},
				new SubProgramme
				{
					Id = 12,
					Name = "Anaethetics",
					SystemName = "Anaethetics",
					ProgrammeId = 5
				},
				new SubProgramme
				{
					Id = 13,
					Name = "Mental Health",
					SystemName = "MH",
					ProgrammeId = 6
				},
				new SubProgramme
				{
					Id = 14,
					Name = "Emerency Centre Pressures",
					SystemName = "ECP",
					ProgrammeId = 7
				}
			);
		}
	}
}
