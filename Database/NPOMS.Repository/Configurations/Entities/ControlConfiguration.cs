using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NPOMS.Domain.Entities;

namespace NPOMS.Repository.Configurations.Entities
{
    public class ControlConfiguration : IEntityTypeConfiguration<Control>
    {
        public void Configure(EntityTypeBuilder<Control> builder)
        {

            builder.Property("CreatedUserID").HasDefaultValueSql("1");
            builder.Property("CreatedDateTimestamp").HasDefaultValueSql("GetDate()");

        }
    }
}
