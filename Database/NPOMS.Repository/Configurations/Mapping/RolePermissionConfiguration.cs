﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPOMS.Domain.Mapping;

namespace NPOMS.Repository.Configurations.Mapping
{
	public class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermission>
	{
		public void Configure(EntityTypeBuilder<RolePermission> builder)
		{
			builder.HasData(
				new RolePermission { RoleId = 1, PermissionId = 1 },
				new RolePermission { RoleId = 1, PermissionId = 2 },
				new RolePermission { RoleId = 1, PermissionId = 3 },
				new RolePermission { RoleId = 1, PermissionId = 4 },
				new RolePermission { RoleId = 1, PermissionId = 5 },
				new RolePermission { RoleId = 1, PermissionId = 6 },
				new RolePermission { RoleId = 1, PermissionId = 7 },
				new RolePermission { RoleId = 1, PermissionId = 8 },
				new RolePermission { RoleId = 1, PermissionId = 9 },
				new RolePermission { RoleId = 1, PermissionId = 10 },
				new RolePermission { RoleId = 1, PermissionId = 11 },
				new RolePermission { RoleId = 1, PermissionId = 12 },
				new RolePermission { RoleId = 1, PermissionId = 13 },
				new RolePermission { RoleId = 1, PermissionId = 14 },
				new RolePermission { RoleId = 1, PermissionId = 15 },
				new RolePermission { RoleId = 1, PermissionId = 16 },
				new RolePermission { RoleId = 1, PermissionId = 17 },
				new RolePermission { RoleId = 1, PermissionId = 18 },
				new RolePermission { RoleId = 1, PermissionId = 19 },
				new RolePermission { RoleId = 1, PermissionId = 20 },
				new RolePermission { RoleId = 1, PermissionId = 21 },
				new RolePermission { RoleId = 1, PermissionId = 22 },
				new RolePermission { RoleId = 1, PermissionId = 23 },
				new RolePermission { RoleId = 1, PermissionId = 24 },
				new RolePermission { RoleId = 1, PermissionId = 25 },
				new RolePermission { RoleId = 1, PermissionId = 26 },
				new RolePermission { RoleId = 1, PermissionId = 27 },
				new RolePermission { RoleId = 1, PermissionId = 28 },
				new RolePermission { RoleId = 1, PermissionId = 29 },
				new RolePermission { RoleId = 1, PermissionId = 30 },
				new RolePermission { RoleId = 1, PermissionId = 31 },
				new RolePermission { RoleId = 1, PermissionId = 32 },
				new RolePermission { RoleId = 1, PermissionId = 33 },
				new RolePermission { RoleId = 1, PermissionId = 34 },
				new RolePermission { RoleId = 1, PermissionId = 35 },
				new RolePermission { RoleId = 1, PermissionId = 36 },
				new RolePermission { RoleId = 1, PermissionId = 37 },
				new RolePermission { RoleId = 1, PermissionId = 38 },
				new RolePermission { RoleId = 1, PermissionId = 39 },
				new RolePermission { RoleId = 1, PermissionId = 40 },
				new RolePermission { RoleId = 1, PermissionId = 41 },
				new RolePermission { RoleId = 1, PermissionId = 42 },
				new RolePermission { RoleId = 1, PermissionId = 43 },
				new RolePermission { RoleId = 1, PermissionId = 44 },
				new RolePermission { RoleId = 1, PermissionId = 45 },
				new RolePermission { RoleId = 1, PermissionId = 46 },
				new RolePermission { RoleId = 1, PermissionId = 47 },
				new RolePermission { RoleId = 1, PermissionId = 48 },
				new RolePermission { RoleId = 1, PermissionId = 49 },
				new RolePermission { RoleId = 1, PermissionId = 50 },
				new RolePermission { RoleId = 1, PermissionId = 51 },
				new RolePermission { RoleId = 1, PermissionId = 52 },
				new RolePermission { RoleId = 1, PermissionId = 53 },
				new RolePermission { RoleId = 1, PermissionId = 54 },
				new RolePermission { RoleId = 1, PermissionId = 55 },
				new RolePermission { RoleId = 1, PermissionId = 56 },
				new RolePermission { RoleId = 1, PermissionId = 57 },
				new RolePermission { RoleId = 1, PermissionId = 58 },
				new RolePermission { RoleId = 1, PermissionId = 59 },
				new RolePermission { RoleId = 1, PermissionId = 60 },
				new RolePermission { RoleId = 1, PermissionId = 61 },
				new RolePermission { RoleId = 1, PermissionId = 62 },
				new RolePermission { RoleId = 1, PermissionId = 63 },
				new RolePermission { RoleId = 1, PermissionId = 64 },
				new RolePermission { RoleId = 1, PermissionId = 65 }
			);
		}
	}
}
