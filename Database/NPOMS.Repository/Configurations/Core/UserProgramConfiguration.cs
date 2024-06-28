using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPOMS.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Configurations.Core
{
    public class UserProgramConfiguration : IEntityTypeConfiguration<UserProgram>
    {
        public void Configure(EntityTypeBuilder<UserProgram> builder)
        {
            builder.HasData(
                new UserProgram
                {
                    Id = 1,
                    Name = "All",
                    DepartmentId = 7,
                    IsActive = true
                },
                new UserProgram
                {
                    Id = 2,
                    Name = "Care and Services to Older Persons",
                    DepartmentId = 7,
                    IsActive = true
                },
                new UserProgram
                {
                    Id = 3,
                    Name = "Care And Support to Families",
                    DepartmentId = 7,
                    IsActive = true
                },
                new UserProgram
                {
                    Id = 4,
                    Name = "Child Care and Protection Services",
                    DepartmentId = 7,
                    IsActive = true
                },
                new UserProgram
                {
                    Id = 5,
                    Name = "Crime Prevention",
                    DepartmentId = 7,
                    IsActive = true
                },
                new UserProgram
                {
                    Id = 6,
                    Name = "EPWP",
                    DepartmentId = 7,
                    IsActive = true
                },
                new UserProgram
                {
                    Id = 7,
                    Name = "Services to persons with Disabilities",
                    DepartmentId = 7,
                    IsActive = true
                },
                new UserProgram
                {
                    Id = 8,
                    Name = "Substance Abuse",
                    DepartmentId = 7,
                    IsActive = true
                },
                new UserProgram
                {
                    Id = 9,
                    Name = "Sustainable Livelihood",
                    DepartmentId = 7,
                    IsActive = true
                },
                new UserProgram
                {
                    Id = 10,
                    Name = "Youth Development",
                    DepartmentId = 7,
                    IsActive = true
                },
                new UserProgram
                {
                    Id = 11,
                    Name = "Facility Management",
                    DepartmentId = 7,
                    IsActive = true
                },
                new UserProgram
                {
                    Id = 12,
                    Name = "Victim Empowerment",
                    DepartmentId = 7,
                    IsActive = true
                },
                new UserProgram
                {
                    Id = 13,
                    Name = "Facility Management",
                    DepartmentId = 7,
                    IsActive = true
                },
                new UserProgram
                {
                    Id = 14,
                    Name = "ECD & Partial Care",
                    DepartmentId = 7,
                    IsActive = true
                },
                new UserProgram
                {
                    Id = 15,
                    Name = "ECD Conditional Grant",
                    DepartmentId = 7,
                    IsActive = true
                },
                new UserProgram
                {
                    Id = 16,
                    Name = "Not Available",
                    DepartmentId = 7,
                    IsActive = true
                },
                new UserProgram
                {
                    Id = 17,
                    Name = "None",
                    DepartmentId = 7,
                    IsActive = true
                }
            );
        }
    }
}
