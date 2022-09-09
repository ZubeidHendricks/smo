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
					Description = "All Sub-Programmes",
					ProgrammeId = 1
				},
				new SubProgramme
				{
					Id = 2,
					Name = "Chronic Diseases",
					Description = "Chronic Diseases",
					ProgrammeId = 2
				},
				new SubProgramme
				{
					Id = 3,
					Name = "NCDs",
					Description = "NCDs",
					ProgrammeId = 2
				},
				new SubProgramme
				{
					Id = 4,
					Name = "HIV/AIDS",
					Description = "HIV/AIDS",
					ProgrammeId = 3
				},
				new SubProgramme
				{
					Id = 5,
					Name = "TB",
					Description = "TB",
					ProgrammeId = 3
				},
				new SubProgramme
				{
					Id = 6,
					Name = "STI",
					Description = "STI",
					ProgrammeId = 3
				},
				new SubProgramme
				{
					Id = 7,
					Name = "Maternal Health",
					Description = "Maternal Health",
					ProgrammeId = 4
				},
				new SubProgramme
				{
					Id = 8,
					Name = "Women's Health",
					Description = "Women's Health",
					ProgrammeId = 4
				},
				new SubProgramme
				{
					Id = 9,
					Name = "Child and Adolescent Health",
					Description = "Child and Adolescent Health",
					ProgrammeId = 4
				},
				new SubProgramme
				{
					Id = 10,
					Name = "Theatre",
					Description = "Theatre",
					ProgrammeId = 5
				},
				new SubProgramme
				{
					Id = 11,
					Name = "Surgery",
					Description = "Surgery",
					ProgrammeId = 5
				},
				new SubProgramme
				{
					Id = 12,
					Name = "Anaethetics",
					Description = "Anaethetics",
					ProgrammeId = 5
				},
				new SubProgramme
				{
					Id = 13,
					Name = "Mental Health",
					Description = "Mental Health",
					ProgrammeId = 6
				},
				new SubProgramme
				{
					Id = 14,
					Name = "Emerency Centre Pressures",
					Description = "Emerency Centre Pressures",
					ProgrammeId = 7
				},
				new SubProgramme
				{
					Id = 15,
					Name = "Projects",
					Description = "Projects",
					ProgrammeId = 8
				},
				new SubProgramme
				{
					Id = 16,
					Name = "Shelter For Adults",
					Description = "Shelter For Adults",
					ProgrammeId = 8
				},
				new SubProgramme
				{
					Id = 17,
					Name = "Social Service Organisation",
					Description = "Social Service Organisation",
					ProgrammeId = 8
				},
				new SubProgramme
				{
					Id = 18,
					Name = "Drop In Centres",
					Description = "Drop In Centres",
					ProgrammeId = 9
				},
				new SubProgramme
				{
					Id = 19,
					Name = "Projects",
					Description = "Projects",
					ProgrammeId = 9
				},
				new SubProgramme
				{
					Id = 20,
					Name = "Social Service Organisation",
					Description = "Social Service Organisation",
					ProgrammeId = 9
				},
				new SubProgramme
				{
					Id = 21,
					Name = "Shelter for Children",
					Description = "Shelter for Children",
					ProgrammeId = 9
				},
				new SubProgramme
				{
					Id = 22,
					Name = "HIV - Aids",
					Description = "HIV - Aids",
					ProgrammeId = 9
				},
				new SubProgramme
				{
					Id = 23,
					Name = "Projects",
					Description = "Projects",
					ProgrammeId = 10
				},
				new SubProgramme
				{
					Id = 24,
					Name = "Social Service Organisation",
					Description = "Social Service Organisation",
					ProgrammeId = 10
				},
				new SubProgramme
				{
					Id = 25,
					Name = "After School Centres",
					Description = "After School Centres",
					ProgrammeId = 11
				},
				new SubProgramme
				{
					Id = 26,
					Name = "Creches",
					Description = "Creches",
					ProgrammeId = 11
				},
				new SubProgramme
				{
					Id = 27,
					Name = "Projects",
					Description = "Projects",
					ProgrammeId = 11
				},
				new SubProgramme
				{
					Id = 28,
					Name = "Social Service Organisation",
					Description = "Social Service Organisation",
					ProgrammeId = 11
				},
				new SubProgramme
				{
					Id = 29,
					Name = "Projects",
					Description = "Projects",
					ProgrammeId = 12
				},
				new SubProgramme
				{
					Id = 30,
					Name = "EPWP - Conditional Grant",
					Description = "EPWP - Conditional Grant",
					ProgrammeId = 12
				},
				new SubProgramme
				{
					Id = 31,
					Name = "Social Service Organisation",
					Description = "Social Service Organisation",
					ProgrammeId = 12
				},
				new SubProgramme
				{
					Id = 32,
					Name = "Child and Youth Care Centres",
					Description = "Child and Youth Care Centres",
					ProgrammeId = 13
				},
				new SubProgramme
				{
					Id = 33,
					Name = "Projects",
					Description = "Projects",
					ProgrammeId = 13
				},
				new SubProgramme
				{
					Id = 34,
					Name = "Shelter for Childen",
					Description = "Shelter for Childen",
					ProgrammeId = 13
				},
				new SubProgramme
				{
					Id = 35,
					Name = "Projects",
					Description = "Projects",
					ProgrammeId = 14
				},
				new SubProgramme
				{
					Id = 36,
					Name = "Social Service Organisation",
					Description = "Social Service Organisation",
					ProgrammeId = 14
				},
				new SubProgramme
				{
					Id = 37,
					Name = "Assisted Living",
					Description = "Assisted Living",
					ProgrammeId = 15
				},
				new SubProgramme
				{
					Id = 38,
					Name = "Homes for the Aged",
					Description = "Homes for the Aged",
					ProgrammeId = 15
				},
				new SubProgramme
				{
					Id = 39,
					Name = "Projects",
					Description = "Projects",
					ProgrammeId = 15
				},
				new SubProgramme
				{
					Id = 40,
					Name = "Social Service Organisation",
					Description = "Social Service Organisation",
					ProgrammeId = 15
				},
				new SubProgramme
				{
					Id = 41,
					Name = "Service Centres",
					Description = "Service Centres",
					ProgrammeId = 15
				},
				new SubProgramme
				{
					Id = 42,
					Name = "Independent Living",
					Description = "Independent Living",
					ProgrammeId = 15
				},
				new SubProgramme
				{
					Id = 43,
					Name = "Community Based Care and Support Services",
					Description = "Community Based Care and Support Services",
					ProgrammeId = 15
				},
				new SubProgramme
				{
					Id = 44,
					Name = "Homes for the Disabled",
					Description = "Homes for the Disabled",
					ProgrammeId = 16
				},
				new SubProgramme
				{
					Id = 45,
					Name = "Projects",
					Description = "Projects",
					ProgrammeId = 16
				},
				new SubProgramme
				{
					Id = 46,
					Name = "Protective Workshops",
					Description = "Protective Workshops",
					ProgrammeId = 16
				},
				new SubProgramme
				{
					Id = 47,
					Name = "Social Service Organisation",
					Description = "Social Service Organisation",
					ProgrammeId = 16
				},
				new SubProgramme
				{
					Id = 48,
					Name = "Special Day Care Centres",
					Description = "Special Day Care Centres",
					ProgrammeId = 16
				},
				new SubProgramme
				{
					Id = 49,
					Name = "Day Care Centre",
					Description = "Day Care Centre",
					ProgrammeId = 16
				},
				new SubProgramme
				{
					Id = 50,
					Name = "Homes for the Aged",
					Description = "Homes for the Aged",
					ProgrammeId = 16
				},
				new SubProgramme
				{
					Id = 51,
					Name = "Aftercare",
					Description = "Aftercare",
					ProgrammeId = 17
				},
				new SubProgramme
				{
					Id = 52,
					Name = "Awareness",
					Description = "Awareness",
					ProgrammeId = 17
				},
				new SubProgramme
				{
					Id = 53,
					Name = "Community Based Treatment",
					Description = "Community Based Treatment",
					ProgrammeId = 17
				},
				new SubProgramme
				{
					Id = 54,
					Name = "Early Intervention",
					Description = "Early Intervention",
					ProgrammeId = 17
				},
				new SubProgramme
				{
					Id = 55,
					Name = "Projects",
					Description = "Projects",
					ProgrammeId = 17
				},
				new SubProgramme
				{
					Id = 56,
					Name = "Social Service Organisation",
					Description = "Social Service Organisation",
					ProgrammeId = 17
				},
				new SubProgramme
				{
					Id = 57,
					Name = "Treatment Centres",
					Description = "Treatment Centres",
					ProgrammeId = 17
				},
				new SubProgramme
				{
					Id = 58,
					Name = "Social Service Organisation",
					Description = "Social Service Organisation",
					ProgrammeId = 18
				},
				new SubProgramme
				{
					Id = 59,
					Name = "Projects",
					Description = "Projects",
					ProgrammeId = 19
				},
				new SubProgramme
				{
					Id = 60,
					Name = "Shelter For Victims of Violence",
					Description = "Shelter For Victims of Violence",
					ProgrammeId = 19
				},
				new SubProgramme
				{
					Id = 61,
					Name = "Social Service Organisation",
					Description = "Social Service Organisation",
					ProgrammeId = 19
				},
				new SubProgramme
				{
					Id = 62,
					Name = "Projects",
					Description = "Projects",
					ProgrammeId = 20
				},
				new SubProgramme
				{
					Id = 63,
					Name = "Social Service Organisation",
					Description = "Social Service Organisation",
					ProgrammeId = 20
				},
				new SubProgramme
				{
					Id = 64,
					Name = "Youth Cafe",
					Description = "Youth Cafe",
					ProgrammeId = 20
				},
				new SubProgramme
				{
					Id = 65,
					Name = "Childrens Homes",
					Description = "Childrens Homes",
					ProgrammeId = 21
				}
			);
		}
	}
}
