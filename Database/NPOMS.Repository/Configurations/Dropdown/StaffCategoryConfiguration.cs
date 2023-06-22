using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPOMS.Domain.Dropdown;

namespace NPOMS.Repository.Configurations.Dropdown
{
	public class StaffCategoryConfiguration : IEntityTypeConfiguration<StaffCategory>
	{
		public void Configure(EntityTypeBuilder<StaffCategory> builder)
		{
			builder.Property("IsActive").HasDefaultValueSql("1");
			builder.Property("CreatedUserId").HasDefaultValueSql("1");
			builder.Property("CreatedDateTime").HasDefaultValueSql("GetDate()");

			builder.HasData(
				new StaffCategory { Id = 1, Name = "Managers", SystemName = "Managers" },
				new StaffCategory { Id = 2, Name = "Professional staff", SystemName = "ProfessionalStaff" },
				new StaffCategory { Id = 3, Name = "Admin support", SystemName = "AdminSupport" },
				new StaffCategory { Id = 4, Name = "Part-time staff", SystemName = "PartTimeStaff" },
				new StaffCategory { Id = 5, Name = "Volunteers", SystemName = "Volunteers" },
				new StaffCategory { Id = 6, Name = "Other", SystemName = "Other" }
			);
		}
	}
}
