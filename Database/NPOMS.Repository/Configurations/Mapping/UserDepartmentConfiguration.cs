using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPOMS.Domain.Mapping;

namespace NPOMS.Repository.Configurations.Mapping
{
	public class UserDepartmentConfiguration : IEntityTypeConfiguration<UserDepartment>
	{
		public void Configure(EntityTypeBuilder<UserDepartment> builder)
		{
			builder.HasData(
				new UserDepartment { Id = 1, UserId = 1, DepartmentId = 1 },
				new UserDepartment { Id = 2, UserId = 2, DepartmentId = 1 }
			);
		}
	}
}
