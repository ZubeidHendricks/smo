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
					SystemName = "All",
					DepartmentId = 1
				},
				new Programme
				{
					Id = 2,
					Name = "Chronic Diseases and Non-Communicable Diseases",
					SystemName = "CNCD",
					DepartmentId = 11
				},
				new Programme
				{
					Id = 3,
					Name = "HIV/AIDS, TB, STI",
					SystemName = "HTS",
					DepartmentId = 11
				},
				new Programme
				{
					Id = 4,
					Name = "Maternal,Women and Child Health",
					SystemName = "MWCH",
					DepartmentId = 11
				},
				new Programme
				{
					Id = 5,
					Name = "Theatre, Surgery and Aneasthetics",
					SystemName = "TSA",
					DepartmentId = 11
				},
				new Programme
				{
					Id = 6,
					Name = "Mental Health",
					SystemName = "MH",
					DepartmentId = 11
				},
				new Programme
				{
					Id = 7,
					Name = "Emergency Centre Presures",
					SystemName = "ECP",
					DepartmentId = 11
				}
			);
		}
	}
}
