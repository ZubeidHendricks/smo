using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPOMS.Domain.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NPOMS.Repository.Configurations.Mapping
{
    public class UserProgramMppingConfiguration : IEntityTypeConfiguration<UserProgramMapping>
    {
        public void Configure(EntityTypeBuilder<UserProgramMapping> builder)
        {
            builder.HasData(
                new UserProgramMapping { Id = 1, UserId = 1, ProgramId = 1 },
                new UserProgramMapping { Id = 2, UserId = 2, ProgramId = 1 }
            );
        }
    }
}
