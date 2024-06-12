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
            builder.Property("DenodoDepartmentName").HasDefaultValue("Not Applicable");

            builder.HasData(
				new Department
				{
					Id = 1,
					Name = "All Departments",
					Abbreviation = "ALL",
					DenodoDepartmentName = "Not Applicable",
					IsActive = true
				},
				new Department
				{
					Id = 2,
					Name = "Economic Development and Tourism",
					Abbreviation = "DEDAT",
                    DenodoDepartmentName = "Western Cape Economic Development And Tourism",
                    IsActive = false
				},
				new Department
				{
					Id = 3,
					Name = "Mobility",
					Abbreviation = "WCMD",
                    DenodoDepartmentName = "Western Cape Mobility",
                    IsActive = false
				},
				new Department
				{
					Id = 4,
					Name = "Education",
					Abbreviation = "WCED",
                    DenodoDepartmentName = "Western Cape Education",
                    IsActive = false
				},
				new Department
				{
					Id = 5,
					Name = "Premier",
					Abbreviation = "DOTP",
                    DenodoDepartmentName = "Western Cape Premier",
                    IsActive = false
				},
				new Department
				{
					Id = 6,
					Name = "Provincial Treasury",
					Abbreviation = "PT",
                    DenodoDepartmentName = "Western Cape Treasury",
                    IsActive = false
				},
				new Department
				{
					Id = 7,
					Name = "Social Development",
					Abbreviation = "DSD",
                    DenodoDepartmentName = "Western Cape Social Development",
                    IsActive = false
				},
				new Department
				{
					Id = 8,
					Name = "Agriculture",
					Abbreviation = "DOA",
                    DenodoDepartmentName = "Western Cape Agriculture",
                    IsActive = false
				},
				new Department
				{
					Id = 9,
					Name = "Police Oversight and Community Safety",
					Abbreviation = "DOCS",
                    DenodoDepartmentName = "Western Cape Police Oversight and Community Safety",
                    IsActive = false
				},
				new Department
				{
					Id = 10,
					Name = "Cultural Affairs and Sport",
					Abbreviation = "DCAS",
                    DenodoDepartmentName = "Western Cape Cultural Affairs And Sport",
                    IsActive = false
				},
				new Department
				{
					Id = 11,
					Name = "Health and Wellness",
					Abbreviation = "DOH",
                    DenodoDepartmentName = "Western Cape Government: Health and Wellness",
                    IsActive = true
				},
				new Department
				{
					Id = 12,
					Name = "Infrastructure",
					Abbreviation = "DOI",
                    DenodoDepartmentName = "Western Cape Infrastructure",
                    IsActive = false
				},
				new Department
				{
					Id = 13,
					Name = "Local Government",
					Abbreviation = "DLG",
                    DenodoDepartmentName = "Western Cape Local Government",
                    IsActive = false
				},
				new Department
				{
					Id = 14,
					Name = "Provincial Parliament",
					Abbreviation = "WCPP",
                    DenodoDepartmentName = "Not Applicable",
                    IsActive = false
				},
				new Department
				{
					Id = 15,
					Name = "Environmental Affairs and Development Planning",
					Abbreviation = "DEA&DP",
                    DenodoDepartmentName = "Western Cape Environmental Affairs Development Planning",
                    IsActive = false
				},
				new Department
				{
					Id = 16,
					Name = "None",
					Abbreviation = "NONE",
                    DenodoDepartmentName = "Not Applicable",
                    IsActive = true
				}
			);
		}
	}
}
