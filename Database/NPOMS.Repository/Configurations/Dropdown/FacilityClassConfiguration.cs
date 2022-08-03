using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPOMS.Domain.Dropdown;

namespace NPOMS.Repository.Configurations.Dropdown
{
	public class FacilityClassConfiguration : IEntityTypeConfiguration<FacilityClass>
	{
		public void Configure(EntityTypeBuilder<FacilityClass> builder)
		{
			builder.Property("IsActive").HasDefaultValueSql("1");
			builder.Property("CreatedUserId").HasDefaultValueSql("1");
			builder.Property("CreatedDateTime").HasDefaultValueSql("GetDate()");

			builder.HasData(
				new FacilityClass
				{
					Id = 1,
					Name = "Mobile Service"
				},
				new FacilityClass
				{
					Id = 2,
					Name = "Health Post"
				},
				new FacilityClass
				{
					Id = 3,
					Name = "Special School"
				},
				new FacilityClass
				{
					Id = 4,
					Name = "Non-medical Site"
				},
				new FacilityClass
				{
					Id = 5,
					Name = "Reproductive Health Centre"
				},
				new FacilityClass
				{
					Id = 6,
					Name = "Primary School"
				},
				new FacilityClass
				{
					Id = 7,
					Name = "Community Day Centre"
				},
				new FacilityClass
				{
					Id = 8,
					Name = "Intermediate Care"
				},
				new FacilityClass
				{
					Id = 9,
					Name = "Private Pharmacy"
				},
				new FacilityClass
				{
					Id = 10,
					Name = "Occupational Health Centre"
				},
				new FacilityClass
				{
					Id = 11,
					Name = "Clinic"
				},
				new FacilityClass
				{
					Id = 12,
					Name = "Independent Cons Rooms - General Practitioner"
				},
				new FacilityClass
				{
					Id = 13,
					Name = "Private Hospital"
				},
				new FacilityClass
				{
					Id = 14,
					Name = "Independent Cons Rooms - Registered Practitioner"
				},
				new FacilityClass
				{
					Id = 15,
					Name = "Community Health Centre"
				},
				new FacilityClass
				{
					Id = 16,
					Name = "Private Clinic"
				},
				new FacilityClass
				{
					Id = 17,
					Name = "Community Health Centre (After hours)"
				},
				new FacilityClass
				{
					Id = 18,
					Name = "Dental Clinic"
				},
				new FacilityClass
				{
					Id = 19,
					Name = "Day Care Centre"
				},
				new FacilityClass
				{
					Id = 20,
					Name = "Home Based Care"
				},
				new FacilityClass
				{
					Id = 21,
					Name = "Correctional Centre"
				},
				new FacilityClass
				{
					Id = 22,
					Name = "Hospice unit"
				},
				new FacilityClass
				{
					Id = 23,
					Name = "Satellite Clinic"
				},
				new FacilityClass
				{
					Id = 24,
					Name = "Specialised Rehabilitation Unit"
				},
				new FacilityClass
				{
					Id = 25,
					Name = "Specialised TB Hospital"
				},
				new FacilityClass
				{
					Id = 26,
					Name = "Community Health Centre / Clinic"
				},
				new FacilityClass
				{
					Id = 27,
					Name = "District Hospital"
				},
				new FacilityClass
				{
					Id = 28,
					Name = "Sickbay"
				},
				new FacilityClass
				{
					Id = 29,
					Name = "Pharmacy Depot"
				},
				new FacilityClass
				{
					Id = 30,
					Name = "Step Down Facility"
				},
				new FacilityClass
				{
					Id = 31,
					Name = "Environmental Health Office"
				},
				new FacilityClass
				{
					Id = 32,
					Name = "Health Promotion Service"
				},
				new FacilityClass
				{
					Id = 33,
					Name = "Special Clinic"
				},
				new FacilityClass
				{
					Id = 34,
					Name = "EMS Station"
				},
				new FacilityClass
				{
					Id = 35,
					Name = "Frail Care Centre"
				},
				new FacilityClass
				{
					Id = 36,
					Name = "Specialised Oral Health Centre"
				},
				new FacilityClass
				{
					Id = 37,
					Name = "Regional Hospital"
				},
				new FacilityClass
				{
					Id = 38,
					Name = "Medical Centre"
				},
				new FacilityClass
				{
					Id = 39,
					Name = "Forensic Pathology Service"
				},
				new FacilityClass
				{
					Id = 40,
					Name = "Specialised Hospital"
				},
				new FacilityClass
				{
					Id = 41,
					Name = "Midwife Obstetrics Unit"
				},
				new FacilityClass
				{
					Id = 42,
					Name = "Independent Cons Rooms - Specialist"
				},
				new FacilityClass
				{
					Id = 43,
					Name = "National Central Hospital"
				},
				new FacilityClass
				{
					Id = 44,
					Name = "Engineering services"
				},
				new FacilityClass
				{
					Id = 45,
					Name = "School Health Services Unit"
				},
				new FacilityClass
				{
					Id = 46,
					Name = "Early Childhood Development Centre"
				},
				new FacilityClass
				{
					Id = 47,
					Name = "Educare Centre"
				},
				new FacilityClass
				{
					Id = 48,
					Name = "Pre-primary School"
				},
				new FacilityClass
				{
					Id = 49,
					Name = "Creche"
				},
				new FacilityClass
				{
					Id = 50,
					Name = "Secondary School"
				},
				new FacilityClass
				{
					Id = 51,
					Name = "Combined School"
				},
				new FacilityClass
				{
					Id = 52,
					Name = "Intermediate School"
				},
				new FacilityClass
				{
					Id = 53,
					Name = "Preparatory School"
				},
				new FacilityClass
				{
					Id = 54,
					Name = "Military Hospital"
				},
				new FacilityClass
				{
					Id = 55,
					Name = "Specialised Psychiatric Hospital"
				},
				new FacilityClass
				{
					Id = 56,
					Name = "Tertiary Hospital"
				},
				new FacilityClass
				{
					Id = 57,
					Name = "Laundry Service"
				},
				new FacilityClass
				{
					Id = 58,
					Name = "Organisational unit"
				},
				new FacilityClass
				{
					Id = 59,
					Name = "Primary Distribution Site"
				},
				new FacilityClass
				{
					Id = 60,
					Name = "Records Repository"
				}
			);
		}
	}
}
