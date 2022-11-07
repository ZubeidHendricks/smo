using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPOMS.Domain.Dropdown;

namespace NPOMS.Repository.Configurations.Dropdown
{
	public class ProgrammeConfiguration : IEntityTypeConfiguration<Programme>
	{
		public void Configure(EntityTypeBuilder<Programme> builder)
		{
			builder.Property("IsActive").HasDefaultValueSql("1");
			builder.Property("CreatedUserId").HasDefaultValueSql("1");
			builder.Property("CreatedDateTime").HasDefaultValueSql("GetDate()");

			builder.HasData(
				new Programme
				{
					Id = 1,
					Name = "All Programmes",
					Description = "All Programmes",
					DepartmentId = 1
				},
				new Programme
				{
					Id = 2,
					Name = "Chronic Diseases and Non-Communicable Diseases",
					Description = "Chronic Diseases and Non-Communicable Diseases",
					DepartmentId = 11
				},
				new Programme
				{
					Id = 3,
					Name = "HIV/AIDS, TB, STI",
					Description = "HIV/AIDS, TB, STI",
					DepartmentId = 11
				},
				new Programme
				{
					Id = 4,
					Name = "Maternal, Women and Child Health",
					Description = "Maternal, Women and Child Health",
					DepartmentId = 11
				},
				new Programme
				{
					Id = 5,
					Name = "Theatre, Surgery and Aneasthetics",
					Description = "Theatre, Surgery and Aneasthetics",
					DepartmentId = 11
				},
				new Programme
				{
					Id = 6,
					Name = "Mental Health",
					Description = "Mental Health",
					DepartmentId = 11
				},
				new Programme
				{
					Id = 7,
					Name = "Emergency Centre Presures",
					Description = "Emergency Centre Presures",
					DepartmentId = 11
				},
				new Programme
				{
					Id = 8,
					Name = "Care and Support to Families",
					Description = "Care and Support to Families",
					DepartmentId = 7,
					DirectorateId = 1
				},
				new Programme
				{
					Id = 9,
					Name = "Child Care and Protection Services",
					Description = "Child Care and Protection Services",
					DepartmentId = 7,
					DirectorateId = 1
				},
				new Programme
				{
					Id = 10,
					Name = "Crime Prevention",
					Description = "Crime Prevention",
					DepartmentId = 7,
					DirectorateId = 7
				},
				new Programme
				{
					Id = 11,
					Name = "ECD & Partial Care",
					Description = "ECD & Partial Care",
					DepartmentId = 7,
					DirectorateId = 3
				},
				new Programme
				{
					Id = 12,
					Name = "EPWP",
					Description = "EPWP",
					DepartmentId = 7,
					DirectorateId = 2
				},
				new Programme
				{
					Id = 13,
					Name = "Facility Managment",
					Description = "Facility Managment",
					DepartmentId = 7,
					DirectorateId = 4
				},
				new Programme
				{
					Id = 14,
					Name = "Institutional Capacity Building",
					Description = "Institutional Capacity Building",
					DepartmentId = 7,
					DirectorateId = 5
				},
				new Programme
				{
					Id = 15,
					Name = "Care and Services to Older Persons",
					Description = "Care and Services to Older Persons",
					DepartmentId = 7,
					DirectorateId = 8
				},
				new Programme
				{
					Id = 16,
					Name = "Services to persons with Disabilities",
					Description = "Services to persons with Disabilities",
					DepartmentId = 7,
					DirectorateId = 8
				},
				new Programme
				{
					Id = 17,
					Name = "Substance Abuse",
					Description = "Substance Abuse",
					DepartmentId = 7,
					DirectorateId = 8
				},
				new Programme
				{
					Id = 18,
					Name = "Sustainable Livelihood",
					Description = "Sustainable Livelihood",
					DepartmentId = 7,
					DirectorateId = 2
				},
				new Programme
				{
					Id = 19,
					Name = "Victim Empowerment",
					Description = "Victim Empowerment",
					DepartmentId = 7,
					DirectorateId = 7
				},
				new Programme
				{
					Id = 20,
					Name = "Youth Development",
					Description = "Youth Development",
					DepartmentId = 7,
					DirectorateId = 2
				},
				new Programme
				{
					Id = 21,
					Name = "Child and Youth Care Centres",
					Description = "Child and Youth Care Centres",
					DepartmentId = 7,
					DirectorateId = 4
				},
				new Programme
				{
					Id = 22,
					Name = "ECD Conditional Grant",
					Description = "ECD Conditional Grant",
					DepartmentId = 7,
					DirectorateId = 3
				}
			);
		}
	}
}
