using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPOMS.Domain.Dropdown;

namespace NPOMS.Repository.Configurations.Dropdown
{
	public class SubProgrammeTypeConfiguration : IEntityTypeConfiguration<SubProgrammeType>
	{
		public void Configure(EntityTypeBuilder<SubProgrammeType> builder)
		{
			builder.Property("IsActive").HasDefaultValueSql("1");
			builder.Property("CreatedUserId").HasDefaultValueSql("1");
			builder.Property("CreatedDateTime").HasDefaultValueSql("GetDate()");

			builder.HasData(
				new SubProgrammeType
				{
					Id = 1,
					Name = "All Sub-Programme Types",
					Description = "All Sub-Programme Types",
					SubProgrammeId = 1
				},
				new SubProgrammeType
				{
					Id = 2,
					Name = "Chronic Diseases",
					Description = "Chronic Diseases",
					SubProgrammeId = 2
				},
				new SubProgrammeType
				{
					Id = 3,
					Name = "NCDs",
					Description = "NCDs",
					SubProgrammeId = 3
				},
				new SubProgrammeType
				{
					Id = 4,
					Name = "HIV/AIDS",
					Description = "HIV/AIDS",
					SubProgrammeId = 4
				},
				new SubProgrammeType
				{
					Id = 5,
					Name = "TB",
					Description = "TB",
					SubProgrammeId = 5
				},
				new SubProgrammeType
				{
					Id = 6,
					Name = "STI",
					Description = "STI",
					SubProgrammeId = 6
				},
				new SubProgrammeType
				{
					Id = 7,
					Name = "Maternal Health",
					Description = "Maternal Health",
					SubProgrammeId = 7
				},
				new SubProgrammeType
				{
					Id = 8,
					Name = "Women's Health",
					Description = "Women's Health",
					SubProgrammeId = 8
				},
				new SubProgrammeType
				{
					Id = 9,
					Name = "Child and Adolescent Health",
					Description = "Child and Adolescent Health",
					SubProgrammeId = 9
				},
				new SubProgrammeType
				{
					Id = 10,
					Name = "Theatre",
					Description = "Theatre",
					SubProgrammeId = 10
				},
				new SubProgrammeType
				{
					Id = 11,
					Name = "Surgery",
					Description = "Surgery",
					SubProgrammeId = 11
				},
				new SubProgrammeType
				{
					Id = 12,
					Name = "Anaethetics",
					Description = "Anaethetics",
					SubProgrammeId = 12
				},
				new SubProgrammeType
				{
					Id = 13,
					Name = "Mental Health",
					Description = "Mental Health",
					SubProgrammeId = 13
				},
				new SubProgrammeType
				{
					Id = 14,
					Name = "Emerency Centre Pressures",
					Description = "Emerency Centre Pressures",
					SubProgrammeId = 14
				},
				new SubProgrammeType
				{
					Id = 15,
					Name = "Shelter For Adults",
					Description = "Shelter For Adults",
					SubProgrammeId = 16
				},
				new SubProgrammeType
				{
					Id = 16,
					Name = "Social Service Organisation",
					Description = "Social Service Organisation",
					SubProgrammeId = 17
				},
				new SubProgrammeType
				{
					Id = 17,
					Name = "HIV",
					Description = "HIV",
					SubProgrammeId = 20
				},
				new SubProgrammeType
				{
					Id = 18,
					Name = "Social Service Organisation",
					Description = "Social Service Organisation",
					SubProgrammeId = 20
				},
				new SubProgrammeType
				{
					Id = 19,
					Name = "Childrens Homes",
					Description = "Childrens Homes",
					SubProgrammeId = 21
				},
				new SubProgrammeType
				{
					Id = 20,
					Name = "Drop In Centre",
					Description = "Drop In Centre",
					SubProgrammeId = 21
				},
				new SubProgrammeType
				{
					Id = 21,
					Name = "Organisation",
					Description = "Organisation",
					SubProgrammeId = 21
				},
				new SubProgrammeType
				{
					Id = 22,
					Name = "Shelter for Children",
					Description = "Shelter for Children",
					SubProgrammeId = 21
				},
				new SubProgrammeType
				{
					Id = 23,
					Name = "Organisations",
					Description = "Organisations",
					SubProgrammeId = 22
				},
				new SubProgrammeType
				{
					Id = 24,
					Name = "Projects",
					Description = "Projects",
					SubProgrammeId = 24
				},
				new SubProgrammeType
				{
					Id = 25,
					Name = "Social Service Organisation",
					Description = "Social Service Organisation",
					SubProgrammeId = 24
				},
				new SubProgrammeType
				{
					Id = 26,
					Name = "After School Centres",
					Description = "After School Centres",
					SubProgrammeId = 25
				},
				new SubProgrammeType
				{
					Id = 27,
					Name = "Creches",
					Description = "Creches",
					SubProgrammeId = 26
				},
				new SubProgrammeType
				{
					Id = 28,
					Name = "Social Service Organisation",
					Description = "Social Service Organisation",
					SubProgrammeId = 28
				},
				new SubProgrammeType
				{
					Id = 29,
					Name = "Social Service Organisation",
					Description = "Social Service Organisation",
					SubProgrammeId = 29
				},
				new SubProgrammeType
				{
					Id = 30,
					Name = "EPWP",
					Description = "EPWP",
					SubProgrammeId = 30
				},
				new SubProgrammeType
				{
					Id = 31,
					Name = "Social Service Organisation",
					Description = "Social Service Organisation",
					SubProgrammeId = 31
				},
				new SubProgrammeType
				{
					Id = 32,
					Name = "Social Service Organisation",
					Description = "Social Service Organisation",
					SubProgrammeId = 36
				},
				new SubProgrammeType
				{
					Id = 33,
					Name = "Assisted Living",
					Description = "Assisted Living",
					SubProgrammeId = 38
				},
				new SubProgrammeType
				{
					Id = 34,
					Name = "Independant Living",
					Description = "Independant Living",
					SubProgrammeId = 38
				},
				new SubProgrammeType
				{
					Id = 35,
					Name = "Residential Facilities",
					Description = "Residential Facilities",
					SubProgrammeId = 38
				},
				new SubProgrammeType
				{
					Id = 36,
					Name = "Social Service Organisation",
					Description = "Social Service Organisation",
					SubProgrammeId = 40
				},
				new SubProgrammeType
				{
					Id = 37,
					Name = "Service Centre",
					Description = "Service Centre",
					SubProgrammeId = 41
				},
				new SubProgrammeType
				{
					Id = 38,
					Name = "Home Based Care Services",
					Description = "Home Based Care Services",
					SubProgrammeId = 43
				},
				new SubProgrammeType
				{
					Id = 39,
					Name = "Service Centre",
					Description = "Service Centre",
					SubProgrammeId = 43
				},
				new SubProgrammeType
				{
					Id = 40,
					Name = "Residential Facilities",
					Description = "Residential Facilities",
					SubProgrammeId = 44
				},
				new SubProgrammeType
				{
					Id = 41,
					Name = "Protective Workshop",
					Description = "Protective Workshop",
					SubProgrammeId = 46
				},
				new SubProgrammeType
				{
					Id = 42,
					Name = "Day Care Centre",
					Description = "Day Care Centre",
					SubProgrammeId = 47
				},
				new SubProgrammeType
				{
					Id = 43,
					Name = "Social Service Organisation",
					Description = "Social Service Organisation",
					SubProgrammeId = 47
				},
				new SubProgrammeType
				{
					Id = 44,
					Name = "Special Day Care Centre",
					Description = "Special Day Care Centre",
					SubProgrammeId = 47
				},
				new SubProgrammeType
				{
					Id = 45,
					Name = "Special Day Care Centres",
					Description = "Special Day Care Centres",
					SubProgrammeId = 48
				},
				new SubProgrammeType
				{
					Id = 46,
					Name = "Day Care Centre",
					Description = "Day Care Centre",
					SubProgrammeId = 49
				},
				new SubProgrammeType
				{
					Id = 47,
					Name = "Residential Facilities",
					Description = "Residential Facilities",
					SubProgrammeId = 50
				},
				new SubProgrammeType
				{
					Id = 48,
					Name = "Projects",
					Description = "Projects",
					SubProgrammeId = 55
				},
				new SubProgrammeType
				{
					Id = 49,
					Name = "Aftercare",
					Description = "Aftercare",
					SubProgrammeId = 56
				},
				new SubProgrammeType
				{
					Id = 50,
					Name = "Awareness & Prevention",
					Description = "Awareness & Prevention",
					SubProgrammeId = 56
				},
				new SubProgrammeType
				{
					Id = 51,
					Name = "Community based treatment",
					Description = "Community based treatment",
					SubProgrammeId = 56
				},
				new SubProgrammeType
				{
					Id = 52,
					Name = "Early Intervention",
					Description = "Early Intervention",
					SubProgrammeId = 56
				},
				new SubProgrammeType
				{
					Id = 53,
					Name = "Social Service Organisation",
					Description = "Social Service Organisation",
					SubProgrammeId = 56
				},
				new SubProgrammeType
				{
					Id = 54,
					Name = "Youth Programmes",
					Description = "Youth Programmes",
					SubProgrammeId = 56
				},
				new SubProgrammeType
				{
					Id = 55,
					Name = "Community based treatment",
					Description = "Community based treatment",
					SubProgrammeId = 57
				},
				new SubProgrammeType
				{
					Id = 56,
					Name = "In patient",
					Description = "In patient",
					SubProgrammeId = 57
				},
				new SubProgrammeType
				{
					Id = 57,
					Name = "Out Patient",
					Description = "Out Patient",
					SubProgrammeId = 57
				},
				new SubProgrammeType
				{
					Id = 58,
					Name = "Earmarked Funding",
					Description = "Earmarked Funding",
					SubProgrammeId = 58
				},
				new SubProgrammeType
				{
					Id = 59,
					Name = "Equitable Share",
					Description = "Equitable Share",
					SubProgrammeId = 58
				},
				new SubProgrammeType
				{
					Id = 60,
					Name = "Social Service Organisation",
					Description = "Social Service Organisation",
					SubProgrammeId = 58
				},
				new SubProgrammeType
				{
					Id = 61,
					Name = "SRD",
					Description = "SRD",
					SubProgrammeId = 58
				},
				new SubProgrammeType
				{
					Id = 62,
					Name = "Targetted Feeding",
					Description = "Targetted Feeding",
					SubProgrammeId = 58
				},
				new SubProgrammeType
				{
					Id = 63,
					Name = "Programme focus",
					Description = "Programme focus",
					SubProgrammeId = 59
				},
				new SubProgrammeType
				{
					Id = 64,
					Name = "Shelter for Women and Children",
					Description = "Shelter for Women and Children",
					SubProgrammeId = 60
				},
				new SubProgrammeType
				{
					Id = 65,
					Name = "Victims of Crime/Violence/Fam members/significant",
					Description = "Victims of Crime/Violence/Fam members/significant",
					SubProgrammeId = 60
				},
				new SubProgrammeType
				{
					Id = 66,
					Name = "Service Provider",
					Description = "Service Provider",
					SubProgrammeId = 61
				},
				new SubProgrammeType
				{
					Id = 67,
					Name = "Social Service Organisation",
					Description = "Social Service Organisation",
					SubProgrammeId = 61
				},
				new SubProgrammeType
				{
					Id = 68,
					Name = "Projects",
					Description = "Projects",
					SubProgrammeId = 62
				},
				new SubProgrammeType
				{
					Id = 69,
					Name = "Social Service Organisation",
					Description = "Social Service Organisation",
					SubProgrammeId = 63
				},
				new SubProgrammeType
				{
					Id = 70,
					Name = "Youth Cafe",
					Description = "Youth Cafe",
					SubProgrammeId = 63
				},
				new SubProgrammeType
				{
					Id = 71,
					Name = "Childrens Homes",
					Description = "Childrens Homes",
					SubProgrammeId = 65
				}
			);
		}
	}
}
