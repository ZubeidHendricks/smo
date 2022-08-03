using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPOMS.Domain.Core;

namespace NPOMS.Repository.Configurations.Core
{
	public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
	{
		public void Configure(EntityTypeBuilder<Department> builder)
		{
			builder.Property("IsActive").HasDefaultValueSql("1");
			builder.Property("CreatedUserId").HasDefaultValueSql("1");
			builder.Property("CreatedDateTime").HasDefaultValueSql("GetDate()");

			builder.HasData(
				new Department
				{
					Id = 1,
					Name = "All Departments",
					Abbreviation = "ALL",
					IsActive = true
				},
				new Department
				{
					Id = 2,
					Name = "Economic Development and Tourism",
					Abbreviation = "DEDAT",
					IsActive = false
				},
				new Department
				{
					Id = 3,
					Name = "Transport and Public Works",
					Abbreviation = "DTPW",
					IsActive = false
				},
				new Department
				{
					Id = 4,
					Name = "Education",
					Abbreviation = "WCED",
					IsActive = false
				},
				new Department
				{
					Id = 5,
					Name = "Premier",
					Abbreviation = "DotP",
					IsActive = false
				},
				new Department
				{
					Id = 6,
					Name = "Provincial Treasury",
					Abbreviation = "PT",
					IsActive = false
				},
				new Department
				{
					Id = 7,
					Name = "Social Development",
					Abbreviation = "DSD",
					IsActive = false
				},
				new Department
				{
					Id = 8,
					Name = "Agriculture",
					Abbreviation = "DoA",
					IsActive = false
				},
				new Department
				{
					Id = 9,
					Name = "Community Safety",
					Abbreviation = "DCS",
					IsActive = false
				},
				new Department
				{
					Id = 10,
					Name = "Cultural Affairs and Sport",
					Abbreviation = "DCAS",
					IsActive = false
				},
				new Department
				{
					Id = 11,
					Name = "Health",
					Abbreviation = "DoH",
					IsActive = true
				},
				new Department
				{
					Id = 12,
					Name = "Human Settlements",
					Abbreviation = "DHS",
					IsActive = false
				},
				new Department
				{
					Id = 13,
					Name = "Local Government",
					Abbreviation = "DLG",
					IsActive = false
				},
				new Department
				{
					Id = 14,
					Name = "Provincial Parliament",
					Abbreviation = "WCPP",
					IsActive = false
				},
				new Department
				{
					Id = 15,
					Name = "Environmental Affairs and Development Planning",
					Abbreviation = "DEA&DP",
					IsActive = false
				},
				new Department
				{
					Id = 16,
					Name = "None",
					Abbreviation = "NONE",
					IsActive = true
				}
			);
		}
	}
}
