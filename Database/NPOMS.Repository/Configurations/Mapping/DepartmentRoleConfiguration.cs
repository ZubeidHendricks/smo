using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using NPOMS.Domain.Mapping;

namespace NPOMS.Repository.Configurations.Mapping
{
    public class DepartmentRoleConfiguration : IEntityTypeConfiguration<DepartmentRoleMapping>
    {
        public void Configure(EntityTypeBuilder<DepartmentRoleMapping> builder)
        {
            builder.Property("IsActive").HasDefaultValue(1);

            builder.HasData(
                new DepartmentRoleMapping { Id = 1, DepartmentId = 11, RoleId = 2 },
                new DepartmentRoleMapping { Id = 2, DepartmentId = 11, RoleId = 4 },
                new DepartmentRoleMapping { Id = 3, DepartmentId = 11, RoleId = 5 },
                new DepartmentRoleMapping { Id = 4, DepartmentId = 11, RoleId = 10 },
                new DepartmentRoleMapping { Id = 5, DepartmentId = 7, RoleId = 2 },
                new DepartmentRoleMapping { Id = 6, DepartmentId = 7, RoleId = 6 },
                new DepartmentRoleMapping { Id = 7, DepartmentId = 7, RoleId = 7 },
                new DepartmentRoleMapping { Id = 8, DepartmentId = 7, RoleId = 8 },
                new DepartmentRoleMapping { Id = 9, DepartmentId = 7, RoleId = 9 },
                new DepartmentRoleMapping { Id = 10, DepartmentId = 1, RoleId = 1 },
                new DepartmentRoleMapping { Id = 11, DepartmentId = 16, RoleId = 3 },
                new DepartmentRoleMapping { Id = 12, DepartmentId = 11, RoleId = 3 },
                new DepartmentRoleMapping { Id = 13, DepartmentId = 7, RoleId = 3 }
            );
        }
    }
}
